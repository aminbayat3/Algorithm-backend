﻿using algorithm.Data;
using algorithm.Models;
using algorithm.Models.Base;
using algorithm.Models.DTO;
using algorithm.Models.Status;
using algorithm.Utils;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace algorithm.Services.ChargeManagementService
{
    public class ChargeManagementService
    {
        public void legManager(Statuses statuses, int legNumber) // it should check if we have any plugin before this 
        {
            // first update the wallbox status
            readDataAndUpdateWallboxesStatuses(statuses, legNumber);

            // for each car that is connected to a wallbox, get Tanksize, Need and Expo
            var connectedCarStatuses = getDataFromConnectedCars(statuses, legNumber);

            int numOfConnectedCars = connectedCarStatuses.Count;

            // update the future in leg_status_wallboxes until all connected cars are full
            int counter = legNumber;

            while(connectedCarStatuses.FirstOrDefault(carStat => carStat.IsCarFull == false) != null)
            {
                foreach(var connectedCarStat in connectedCarStatuses)
                {
                    if(!connectedCarStat.IsCarFull) updateSocOfConnectedCar(connectedCarStat, statuses, counter, numOfConnectedCars); 
                   
                }
                
                counter++;
            }

        }

        private void readDataAndUpdateWallboxesStatuses(Statuses statuses, int legNumber)
        { 
           

            for (int i = 0; i < statuses.WallBoxLegs[legNumber].WallBoxStatuses.Count; i++)
            {
                statuses.WallBoxLegs[legNumber].WallBoxStatuses[i] = statuses.SimulatePiAndPo[legNumber].FutureWallBoxStatuses[i];
            }

            //Print where we can see if the injection was right or no

            //Console.WriteLine("counter: " + legNumber + " StartTime: " + statuses.WallBoxLegs[legNumber].StartTime + " EndTime: " + statuses.WallBoxLegs[legNumber].EndTime);
            //Console.WriteLine(statuses.WallBoxLegs[legNumber].ToString());

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

        private void updateSocOfConnectedCar(ConnectedCarStatus connectedCarStatus, Statuses statuses, int currentLegNumber, int numOfConnectedCars)
        {
            for(int i = 0; i < statuses.SocLegs[currentLegNumber].SocStatuses.Count; i++)
            {
                if ((statuses.SocLegs[currentLegNumber].SocStatuses[i].CarId == connectedCarStatus.CarId))
                {
                    var test = statuses.SocLegs[currentLegNumber - 1].SocStatuses[i].Soc + calculateSocIncreaseInOneLeg(connectedCarStatus.CarId, numOfConnectedCars);
                    statuses.SocLegs[currentLegNumber].SocStatuses[i].Soc = test;

                    if (test >= connectedCarStatus.Tanksize) connectedCarStatus.IsCarFull = true;
                }
                    
                    
            }
        }

        private double calculateSocIncreaseInOneLeg(string carId, int numOfConnectedCars)
        {
            double loadPerCar = Globals.Form.ConnectionLoad / numOfConnectedCars; 
            double acLimit = getAcLimitByCarId(carId); 

            double min = Math.Min(loadPerCar, acLimit);
            double socIncrease = (double)(Globals.Form.LegDuration / 60) * min;
            return socIncrease;
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
