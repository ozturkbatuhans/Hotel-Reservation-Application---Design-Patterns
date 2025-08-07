using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservatieApp.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; set; }
        public string Username { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Reservation(RoomID roomID, string username, DateTime startDate, DateTime endDate )
        {
            RoomID = roomID;
            Username = username;
            StartDate = startDate;
            EndDate = endDate;
        }

        public override string ToString()
        {
            return $"{RoomID} reserved by {Username} from {StartDate.ToShortDateString()} to {EndDate.ToShortDateString()}";

        }
    }
}
