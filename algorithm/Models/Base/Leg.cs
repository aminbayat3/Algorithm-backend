using algorithm.Models;
using algorithm.Models.Base;

namespace algorithm.Models.Base
{
    public abstract class Leg : Entity
    {
        public int Number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Leg(int number, DateTime startTime, DateTime endtime)
        {
            Number = number;
            StartTime = startTime;
            EndTime = endtime;
        }
    }
}


//Car leg =>  //List of cars // CarId  // Soc

    // WallBox  leg =>  // list of wb // isConnected  // carId  //  currentChargeload // need, full

   // Event manager => // fetch data, PI or Po // recalculation // check => expo and need

    //notify => Tn and Tf (time when the need met and time when the full event happend for each car)
    