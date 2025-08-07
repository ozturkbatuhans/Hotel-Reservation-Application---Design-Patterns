using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservatieApp.Models
{
    public class ReservationBook
    {
        private List<Reservation> reservations;

        public ReservationBook()
        {
            reservations = new List<Reservation>();
        }

        public bool AddReservation(Reservation reservation)
        {
            if (!HasConflict(reservation))
            {
                reservations.Add(reservation);
                return true;
            }
            return false;
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return reservations;
        }

        public bool HasConflict(Reservation newReservation)
        {
            return reservations.Any(r =>
               r.RoomID.FloorNr == newReservation.RoomID.FloorNr &&
               r.RoomID.RoomNr == newReservation.RoomID.RoomNr &&
               !(newReservation.EndDate <= r.StartDate || newReservation.StartDate >= r.EndDate));
        }
    }
}
