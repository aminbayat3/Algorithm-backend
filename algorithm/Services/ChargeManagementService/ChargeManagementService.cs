using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Models.Status;
using algorithm.Utils;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace algorithm.Services.ChargeManagementService
{
    public class ChargeManagementService
    {
        public void legManager(Statuses statuses, int legNumber) // it should check if we have any plugin before this 
        {
            // first update the wallbox status
            readDataAndUpdateWallboxesStatuses(statuses, legNumber);

           updateFutureInWbLegs(statuses, legNumber);

        }

        private void readDataAndUpdateWallboxesStatuses(Statuses statuses, int legNumber)
        { 
           // **** Should we onlyy update one leg with the sim ??? because when we go to the future then we dont have any information??

            for (int i = 0; i < statuses.WallBoxLegs[legNumber].WallBoxStatuses.Count; i++)
            {
                statuses.WallBoxLegs[legNumber].WallBoxStatuses[i] = statuses.SimulatePiAndPo[legNumber].FutureWallBoxStatuses[i];
            }

            //Print where we can see if the injection was right or no

            //Console.WriteLine("counter: " + legNumber + " StartTime: " + statuses.WallBoxLegs[legNumber].StartTime + " EndTime: " + statuses.WallBoxLegs[legNumber].EndTime);
            //Console.WriteLine(statuses.WallBoxLegs[legNumber].ToString());

        }

        private void updateFutureInWbLegs(Statuses statuses, int legNumber)
        {
            // for each car that is connected to a wallbox, get Tanksize, Need and Expo
            var connectedCarStatuses = getDataFromConnectedCars(statuses, legNumber);

            int futureCounter = legNumber;

            //updating the current soc leg as well
            //if (futureCounter > 0) UpdateCurrentSocLegFullState(legNumber, statuses, connectedCarStatuses);

            connectedCarStatuses.RemoveAll(carStat => statuses.SocLegs[futureCounter - 1].SocStatuses.Any(socLeg => (socLeg.CarId == carStat.CarId) && socLeg.IsFull));

            UpdateSocOfNextLegWithCurrentOne(legNumber, statuses);

            // update the future in leg_status_wallboxes until all connected cars are full
            while (connectedCarStatuses.Count > 0)
            {
                // make update to wb statuses
                if(futureCounter > legNumber ) statuses.WallBoxLegs[futureCounter].WallBoxStatuses = statuses.WallBoxLegs[futureCounter - 1].WallBoxStatuses;

                //***** getting all the normal cars by filtering the ones that their need is met (we can move this logic to a method later)
                double totalChargeLoadForNormalCars = 0;

                var normalCarStatuses = connectedCarStatuses
                                          .Where(carStat => !statuses.SocLegs[futureCounter - 1].SocStatuses
                                          .Any(socLeg => (socLeg.CarId == carStat.CarId) && socLeg.IsNeedMet))
                                          .ToList();
                // updating all the normal cars' WB statuses
                foreach(var normalCarStat in  normalCarStatuses)
                {
                    var targetWbStat = getWBStatusByCarId(statuses, futureCounter, normalCarStat.CarId);
                    targetWbStat.CurrentChargeLoad = Math.Min((Globals.Form.ConnectionLoad / normalCarStatuses.Count), getAcLimitByCarId(normalCarStat.CarId));

                    totalChargeLoadForNormalCars += targetWbStat.CurrentChargeLoad;
                }

                //****** getting all car statuses which their need is met (we can move this logic to a method later)
                var needMetCars = connectedCarStatuses
                                          .Where(carStat => statuses.SocLegs[futureCounter - 1].SocStatuses
                                          .Any(socLeg => (socLeg.CarId == carStat.CarId) && socLeg.IsNeedMet))
                                          .ToList();
                // updating all the needMet cars' WB statuses
                foreach(var needMetCarStat in needMetCars)
                {
                    var targetWbStat = getWBStatusByCarId(statuses, futureCounter, needMetCarStat.CarId);
                    targetWbStat.CurrentChargeLoad = Math.Min(((Globals.Form.ConnectionLoad - totalChargeLoadForNormalCars) / needMetCars.Count), getAcLimitByCarId(needMetCarStat.CarId));
                }


                foreach (var connectedCarStat in connectedCarStatuses)
                {
                    updateSocOfConnectedCar(statuses, connectedCarStat, futureCounter);

                }
                connectedCarStatuses.RemoveAll(carStat => statuses.SocLegs[futureCounter].SocStatuses.Any(socLeg => (socLeg.CarId == carStat.CarId) && socLeg.IsFull));

                //UpdateSocOfNextLegWithCurrentOne(futureCounter, statuses);

                futureCounter++;
            }
            
        }

        private List<ConnectedCarStatus> getDataFromConnectedCars(Statuses statuses, int legNumber)
        {
            // getting all the status of connected wallboxes 
            List<WallBoxStatus> connectedWBStatuses = statuses.WallBoxLegs[legNumber].WallBoxStatuses.Where(stat => stat.IsConnected).ToList();

            var carStatuses = new List<ConnectedCarStatus>();

            // getting the status of all the connected cars
            foreach(var connectedStat in connectedWBStatuses)
            {
                var tanksize = getTanksizeByCarId(connectedStat.CarId);
                var expo = getExpoByCarId(connectedStat.CarId);

                carStatuses.Add(new ConnectedCarStatus(connectedStat.CarId, tanksize, connectedStat.NeededEnergy, expo));
            }

            return carStatuses;
        }

        private void updateSocOfConnectedCar(Statuses statuses, ConnectedCarStatus connectedCarStatus, int futureLegNumber)
        {
            for(int i = 0; futureLegNumber < 192 && i < statuses.SocLegs[futureLegNumber].SocStatuses.Count; i++)
            {
                if ((statuses.SocLegs[futureLegNumber].SocStatuses[i].CarId == connectedCarStatus.CarId))
                {
                    var newSoc = statuses.SocLegs[futureLegNumber - 1].SocStatuses[i].Soc + calculateSocIncreaseInOneLeg(statuses, futureLegNumber, connectedCarStatus.CarId);
                    if (newSoc >= connectedCarStatus.Tanksize)
                    {
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].Soc = connectedCarStatus.Tanksize;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsFull = true;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsNeedMet = true;

                        // update the ChargeLoad for Wb status for full car
                        var targetWbStat = getWBStatusByCarId(statuses, futureLegNumber, connectedCarStatus.CarId);
                        targetWbStat.CurrentChargeLoad = 0;

                    } else if(newSoc >= connectedCarStatus.NeededEnergy)
                    {
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].Soc = newSoc;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsNeedMet = true;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsFull = false;

                    } else
                    {
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].Soc = newSoc;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsNeedMet = false;
                        statuses.SocLegs[futureLegNumber].SocStatuses[i].IsFull = false;
                    }
                }
                      
            }
        }

        private void UpdateSocOfNextLegWithCurrentOne(int legNumber, Statuses statuses)
        {
            for(int i = 0; i < statuses.SocLegs[legNumber].SocStatuses.Count; i++)
            {
                statuses.SocLegs[legNumber].SocStatuses[i].Soc = statuses.SocLegs[legNumber - 1].SocStatuses[i].Soc;
                statuses.SocLegs[legNumber].SocStatuses[i].IsFull = statuses.SocLegs[legNumber - 1].SocStatuses[i].IsFull;
                statuses.SocLegs[legNumber].SocStatuses[i].IsNeedMet = statuses.SocLegs[legNumber - 1].SocStatuses[i].IsNeedMet;
            }
            
        }


        private void UpdateCurrentSocLegFullState(int legNumber, Statuses statuses, List<ConnectedCarStatus> connectedCarStatuses)
        {
            var socLegStats = statuses.SocLegs[legNumber - 1].SocStatuses.Where(socLegStat => connectedCarStatuses.Any(carStat => (carStat.CarId == socLegStat.CarId) && socLegStat.IsFull)).ToList();

            if (socLegStats.Count > 0)
            {
                var targetSocStats = statuses.SocLegs[legNumber].SocStatuses.Where(socStat => socLegStats.Any(socLegStat => socLegStat.CarId == socStat.CarId)).ToList();

                // foreach loop
                targetSocStats.ForEach(targetSocStat =>
                {
                    targetSocStat.IsFull = true;
                });
            }
        }


        private double calculateSocIncreaseInOneLeg(Statuses statuses, int legNumber, string carId)
        {
            var targetWbStatuses = getWBStatusByCarId(statuses, legNumber, carId);

            var chargeLoadInOneLeg = targetWbStatuses.CurrentChargeLoad * (Globals.Form.LegDuration / 60);

            return chargeLoadInOneLeg;
        }

        private double getTanksizeByCarId(string carId)
        {
            foreach(var car in CarDb.Cars)
            {
                if (car.Id.Equals(carId)) return car.TankSize;
            }

            return 0;
        }

        private double getAcLimitByCarId(string carId)
        {
            foreach (var car in CarDb.Cars)
            {
                if (car.Id.Equals(carId))
                {
                    var aclimit = car.MaxAcConnectionLoad;
                    return aclimit;
                }
            }

            return 0;
        }

        private WallBoxStatus getWBStatusByCarId(Statuses statuses, int legNumber, string carId)
        {
            foreach(var wbStat in statuses.WallBoxLegs[legNumber].WallBoxStatuses)
            {
                if(wbStat.CarId == carId) return wbStat;
            }
            return null;
        }

        private DateTime getExpoByCarId(string carId)
        {
            foreach(var reservation in ReservationDb.Reservations)
            {
                if(reservation.CarId.Equals(carId)) { return reservation.Expo; }
            }

            return DateTime.MinValue;
        }

        //private Leg ConvertLegNumberToPackageTime(int legNumber)
        //{
        //    DateTime startTime = StartTime.AddMinutes(LegDuration * (legNumber - 1));
        //    DateTime endTime = startTime.AddMinutes(LegDuration);

        //    return new Leg(legNumber, startTime, endTime);
        //}
    }
}
