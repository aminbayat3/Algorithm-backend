using algorithm.Models;
using algorithm.Models.Base;

namespace algorithm.Data
{
    public static class ReservationDb
    {
        public static List<Reservation> Reservations { get; } = new List<Reservation>() { };

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
