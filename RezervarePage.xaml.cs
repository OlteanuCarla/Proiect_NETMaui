using Plugin.LocalNotification;
using Proiect_NETMaui.Models;
using Xamarin.Essentials;
namespace Proiect_NETMaui;

public partial class RezervarePage : ContentPage
{
    private List<Rezervare> reservations = new List<Rezervare>();
    private Rezervare reservation;

    public RezervarePage(Rezervare reservation)
    {
        InitializeComponent();
        this.reservation = reservation;
        // Utilizați obiectul reservation pentru a afișa informațiile în interfața utilizator
    }

    async void OnCompleteReservationClicked(object sender, EventArgs e)
    {
        // Check if the number of persons is entered correctly
        if (int.TryParse(numarPersoaneEntry.Text, out int numarPersoane))
        {
            // Save date, time, and number of persons in the reservation object
            DateTime selectedDate = datePicker.Date;
            TimeSpan selectedTime = timePicker.Time;

            // Example: Save the data in a reservation object (assuming you have access to this object)
            Rezervare newreservation = new Rezervare
            {
                Data = selectedDate,
                Ora = selectedTime,
                NumarPersoane = numarPersoane,
                RestaurantID = reservation.RestaurantID,
                Restaurant = reservation.Restaurant
                // Other attributes of the Reservation object can be set here
            };
            reservations.Add(newreservation);
            ScheduleNotificationAsync("Reservation Confirmation", $"Your reservation for {numarPersoane} persons on {selectedDate.ToLocalTime()} is confirmed.");

            // Schedule reminder notification one day before the reservation
            if (selectedDate == DateTime.Now.Date.AddDays(1))
            {
                ScheduleNotificationAsync("Reservation Reminder", $"Don't forget your reservation for {numarPersoane} persons tomorrow at {selectedDate.ToLocalTime()}.");
            }

            // Navigate back to the previous page or perform other actions
            //await Navigation.PushAsync(new MyReservationsPage(reservations));
            Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid number of persons.", "OK");
        }
     
    }
    private async Task ScheduleNotificationAsync(string title, string message)
    {
        var notification = new NotificationRequest
        {
            Title = title,
            Description = message,
        
        };

        LocalNotificationCenter.Current.Show(notification);

    }
}
