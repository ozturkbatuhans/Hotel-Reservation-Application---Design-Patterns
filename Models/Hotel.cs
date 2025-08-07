using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservatieApp.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public ReservationBook ReservationBook { get; set; }

        public Hotel(string name)
        {
            Name = name;
            ReservationBook = new ReservationBook();
        }


    }
}
