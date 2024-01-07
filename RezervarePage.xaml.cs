using Plugin.LocalNotification;
using Proiect_NETMaui.Models;
using Xamarin.Essentials;
namespace Proiect_NETMaui;

public partial class RezervarePage : ContentPage
{
    private List<Rezervare> reservations = new List<Rezervare>();
    public RezervarePage()
	{
		InitializeComponent();
	}
    async void OnCompleteReservationClicked(object sender, EventArgs e)
    {
        // Check if the number of persons is entered correctly
        if (int.TryParse(numarPersoaneEntry.Text, out int numarPersoane) && numarPersoane >= 1 && numarPersoane <= 15)
        {
            // Save date, time, and number of persons in the reservation object
            DateTime selectedDate = datePicker.Date;
            TimeSpan selectedTime = timePicker.Time;
            // Check if the selected time is available
            if (!IsReservationTimeAvailable(selectedDate, selectedTime))
            {
                DisplayAlert("Error", "Reservation time not available. Please choose a different time.", "OK");
                return; // Stop execution if the time is not available
            }

            // Example: Save the data in a reservation object (assuming you have access to this object)
            Rezervare reservation = new Rezervare
            {
                Data = selectedDate,
                Ora = selectedTime,
                NumarPersoane = numarPersoane
                // Other attributes of the Reservation object can be set here
            };
            ScheduleNotificationAsync("Reservation Confirmation", $"Your reservation for {numarPersoane} persons on {selectedDate.ToLocalTime()} is confirmed.");

            // Schedule reminder notification one day before the reservation
            DateTime reminderDate = selectedDate.AddDays(-1);
            ScheduleNotificationAsync("Reservation Reminder", $"Don't forget your reservation for {numarPersoane} persons tomorrow at {reminderDate.ToLocalTime()}.");

            reservations.Add(reservation);
            // Navigate back to the previous page or perform other actions
            await Navigation.PushAsync(new MyReservationsPage(reservations));
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
    private bool IsReservationTimeAvailable(DateTime selectedDate, TimeSpan selectedTime)
    {
        // Verifică dacă există deja o rezervare la aceeași dată și oră
        return !reservations.Any(r => r.Data == selectedDate && r.Ora == selectedTime);
    }
}
