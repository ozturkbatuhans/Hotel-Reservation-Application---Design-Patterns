using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservatieApp.Models;
using System.Windows;
using System.Windows.Input;
using HotelReservatieApp.Views;
using System.Collections.ObjectModel;

namespace HotelReservatieApp.ViewModels
{
    public class MainViewModel
    {
        public Hotel Hotel { get; set; }


        public ObservableCollection<string> Reservations { get; set; }

        public ICommand MakeReservationCommand { get; }
        public ICommand ViewReservationsCommand { get; }

        public ICommand AddNewReservationCommand { get; }


        public MainViewModel()
        {
            Hotel = new Hotel("Hotel Vives");

            Reservations = new ObservableCollection<string>();

            MakeReservationCommand = new RelayCommand(OpenMakeReservationView);
            ViewReservationsCommand = new RelayCommand(OpenViewReservationsView);
            AddNewReservationCommand = new RelayCommand(AddReservation);
        }

        private void OpenMakeReservationView(object parameter)
        {
            var reservationView = new MakeResservationView();
            reservationView.DataContext = this;
            reservationView.ShowDialog();
        }

        //private void MakeReservation(object parameter)
        //{
          //  MessageBox.Show("Make Reservation window for testing");
        //}

       // private void ViewReservations(object parameter)
        //{
          //  string reservations = string.Join("\n", Hotel.ReservationBook.GetReservations());

            //MessageBox.Show(reservations != "" ? reservations : "There is no reservation yet.");

      //  }

        private void OpenViewReservationsView(object parameter)
        {
            Reservations.Clear();

            foreach (var reservation in Hotel.ReservationBook.GetReservations())
            {
                Reservations.Add(reservation.ToString());
            }

            var viewReservationsView = new ViewReservationsView();
            viewReservationsView.DataContext = this;
            viewReservationsView.ShowDialog();
        }
        

        private void AddReservation(object parameter)
        {
            var reservationView = Application.Current.Windows
                .OfType<MakeResservationView>()
                .FirstOrDefault();


            if (reservationView != null)
            {
                string username = reservationView.txtUsername.Text;
                bool isFloorValid = int.TryParse(reservationView.txtFloorNumber.Text, out int floorNr);
                bool isRoomValid = int.TryParse(reservationView.txtRoomNumber.Text, out int roomNr);
                DateTime? startDate = reservationView.startDatePicker.SelectedDate;
                DateTime? endDate = reservationView.endDatePicker.SelectedDate;

                if (!string.IsNullOrEmpty(username) && isFloorValid && isRoomValid && startDate.HasValue && endDate.HasValue)
                {
                    Reservation reservation = new Reservation(
                        new RoomID(floorNr, roomNr),
                        username,
                        startDate.Value,
                        endDate.Value);

                    bool success = Hotel.ReservationBook.AddReservation(reservation);

                    reservationView.txtMessage.Text = success
                        ? "Reservation successfully added."
                        : "Conflict: Room already booked in this period.";

                    if (success)
                    {
                        MessageBox.Show("Your reservation has been succesfully made. Enjoy!");
                        reservationView.Close();
                    }
                    else
                            {
                        MessageBox.Show("Room already booked in this period.");
                        
                    }
                            

                    
                }
                else
                {
                    reservationView.txtMessage.Text = "Please fill all fields correctly.";
                }
            }
        }
    }
}
