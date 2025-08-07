using System.Configuration;
using System.Data;
using System.Windows;
using System;
using System.Windows;
using HotelReservatieApp.Models;
using HotelReservatieApp.ViewModels;

namespace HotelReservatieApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow mainWindow = new MainWindow();
        MainViewModel viewModel = new MainViewModel();

        viewModel.Hotel = new Hotel("My Hotel");

        RoomID room1 = new RoomID(1, 1);
        RoomID room2 = new RoomID(1, 2);
        



        var reservation1 = new Reservation(room1, "User1", DateTime.Today, DateTime.Today.AddDays(2));
        var reservation2 = new Reservation(room2, "User2", DateTime.Today.AddDays(1), DateTime.Today.AddDays(3));


        if (viewModel.Hotel.ReservationBook.AddReservation(reservation1))
            Console.WriteLine("Reservation 1 succesfully added!");
        else
            Console.WriteLine("Reservation conflict for reservation 1!");

        if (viewModel.Hotel.ReservationBook.AddReservation(reservation2))
            Console.WriteLine("Reservation 2 added.");
        else
            Console.WriteLine("Reservation conflict for reservation 2!");

        mainWindow.DataContext = viewModel;
        mainWindow.Show();
    }
}

