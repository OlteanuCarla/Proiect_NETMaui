using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class MyReservationsPage : ContentPage
{
    public List<Rezervare> Reservations { get; set; }

    public MyReservationsPage()
    {
        InitializeComponent();
        Reservations = new List<Rezervare>();
        LoadReservations();
    }

    private async void LoadReservations()
    {
        //reservations = await App.Database.GetReservationsAsync();
        Reservations = await App.Database.GetReservationsAsync(); 
        reservationsListView.ItemsSource = Reservations;
    }
}