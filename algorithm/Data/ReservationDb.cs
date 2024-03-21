using algorithm.Models;
using algorithm.Models.Base;

namespace algorithm.Data
{
    public static class ReservationDb
    {
        public static List<Reservation> Reservations { get; } = new List<Reservation>() 
        {
        new Reservation { CarId = "Car1", Expi = DateTime.Parse("2024-03-20T17:00:04.000Z"), Expo = DateTime.Parse("2024-03-21T07:00:04.000Z"), Id = "Rs1", NeededEnergy = 30, Priority = 0 },
        new Reservation { CarId = "Car2", Expi = DateTime.Parse("2024-03-20T07:00:04.000Z"), Expo = DateTime.Parse("2024-03-20T23:00:04.000Z"), Id = "Rs2", NeededEnergy = 60, Priority = 0 },
        new Reservation { CarId = "Car3", Expi = DateTime.Parse("2024-03-20T19:00:04.000Z"), Expo = DateTime.Parse("2024-03-21T11:00:04.000Z"), Id = "Rs3", NeededEnergy = 60, Priority = 0 },
        new Reservation { CarId = "Car4", Expi = DateTime.Parse("2024-03-20T09:00:04.000Z"), Expo = DateTime.Parse("2024-03-21T05:00:04.000Z"), Id = "Rs4", NeededEnergy = 70, Priority = 0 },
        };

        public static void AddReservations(List<Reservation> reservations)
        {
            foreach(var reservation in reservations)
            {
                Reservations.Add(reservation);
            }
        }

        public static List<Event> getSortedPluginEvents(List<Reservation> reservations) 
        {
            return reservations.Select(r => new Event { Time = r.Expi, CarId = r.CarId }).OrderBy(e => e.Time).ToList();
        }

        public static List<Event> getSortedPlugoutEvents(List<Reservation> reservations)
        {
            return reservations.Select(r => new Event { Time = r.Expo, CarId = r.CarId }).OrderBy(e => e.Time).ToList();
        }

       public static List<CarEnergyRequirement> getSortedNeededEnergy(List<Reservation> reservations)
        {
            return reservations.Select(r => new CarEnergyRequirement { CarId = r.CarId, NeededEnergy = r.NeededEnergy })
            .OrderBy(cer => cer.NeededEnergy)
            .ToList();
        }

    }
}
