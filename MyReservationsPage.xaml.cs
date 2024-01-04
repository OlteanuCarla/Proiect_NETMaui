using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class MyReservationsPage : ContentPage
{
    private List<Rezervare> reservations;

    public MyReservationsPage(List<Rezervare> reservations)
    {
        InitializeComponent();
        this.reservations = reservations;
        LoadReservations();
    }

    private void LoadReservations()
    {
        // Atribuie lista de rezervări la sursa de date a ListView-ului
        reservationsListView.ItemsSource = reservations;
    }
}