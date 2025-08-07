# Hotel-Reservation-Application---Design-Patterns

This repository contains a simple **Hotel Reservation Application** built using **C#**, **WPF**, and the **MVVM (Model-View-ViewModel)** design pattern.  
It offers a user-friendly interface for making and managing room reservations.

---

### Features

- **Make a Reservation**  
  Users can input reservation details such as:
  - Username  
  - Room number  
  - Floor number  
  - Start and end dates of stay  

- **Conflict Detection**  
  The system automatically checks for date conflicts for the same room before accepting a new reservation.

- **View Reservations**  
  Easily view all current reservations in a list.

- **MVVM Architecture**  
  Clear separation of responsibilities:
  - **Model**: Business logic and data structures  
  - **View**: User interface  
  - **ViewModel**: Mediator between view and model, containing commands and data binding

---

## 🗂 Project Structure

### 🔹 Views
- `MainWindow.xaml`: Main window with navigation buttons  
- `MakeResservationView.xaml`: UI for creating new reservations  
- `ViewReservationsView.xaml`: UI for displaying current reservations  

### 🔹 ViewModels
- `MainViewModel.cs`: Handles commands and data binding for `MainWindow`  
- `RelayCommand.cs`: Reusable implementation of the `ICommand` interface to handle UI actions  

### 🔹 Models
- `Hotel.cs`: Represents the hotel and contains the reservation system  
- `ReservationBook.cs`: Core reservation logic; manages reservations and checks for conflicts  
- `Reservation.cs`: Represents an individual reservation (RoomID, Username, StartDate, EndDate)  
- `RoomID.cs`: Uniquely identifies a room using floor and room number  

---

##  Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/hotel-reservation-app.git
   ```

2. **Open the project:**
   - Open `HotelReservatieApp.csproj` in **Visual Studio**

3. **Build and run the project:**
   - Press `F5` or click **Start**

4. **Start using the app:**
   - Create new reservations or view existing ones using the navigation buttons.

---

## ⚙ How It Works

- **Startup Logic:**  
  `App.xaml.cs` contains the startup logic. The `OnStartup()` method creates a `MainViewModel` instance and sets it as the data context of `MainWindow`.

- **Making a Reservation:**  
  In `MakeResservationView`, when the user submits a reservation:
  - The `AddNewReservationCommand` in `MainViewModel` is triggered  
  - It uses the `ReservationBook` to check for date conflicts  
  - If there's a conflict, the user is notified; otherwise, the reservation is saved

- **Viewing Reservations:**  
  `ViewReservationsView` binds to the `Reservations` collection in `MainViewModel`, showing a live list of all bookings.

---

> This application was created as an educational project and demonstrates a clean implementation of MVVM in a WPF environment.
