using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservatieApp.Models
{
    public class RoomID
    {
        public int FloorNr { get; set; }
        public int RoomNr { get; set; }


        public RoomID(int floorNr, int roomNr)
        {
            FloorNr = floorNr;
            RoomNr = roomNr;
        }


        public override string ToString()
        {
            return $"Floor {FloorNr}, Room {RoomNr}";
        }
    }
}
