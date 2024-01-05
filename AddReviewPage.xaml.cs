using Proiect_NETMaui.Models;
using SQLite;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Proiect_NETMaui;

public partial class AddReviewPage : ContentPage
{
    private ReviewService _reviewService;
    public AddReviewPage()
	{
		InitializeComponent();
        string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "mydatabase.db");

        // Inițializează serviciul de bază de date cu calea
        var databaseService = new DatabaseService(dbPath);

        // Inițializează serviciul de recenzie cu conexiunea la baza de date
        _reviewService = new ReviewService(databaseService.GetConnection());

        //_reviewService = new ReviewService();
       BindingContext = new Review();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        //double rating = ratingBar.Rating;
        var review = (Review)BindingContext;
       // await App.Database.SaveReviewAsync(review);
       // await Navigation.PopAsync();
        try
        {
            // Validează și adaugă review-ul folosind serviciul
            _reviewService.ValidareReview(review);
            await App.Database.SaveReviewAsync(review);

            // Dacă nu sunt erori de validare, poți să faci alte acțiuni sau să închizi pagina
            // De exemplu, poți să utilizezi Navigation pentru a reveni la pagina anterioară
            await Navigation.PopAsync();
        }
        catch (ValidationException ex)
        {
            // Afișează mesajul de eroare în cazul unei erori de validare
            await DisplayAlert("Eroare de Validare", ex.Message, "OK");
        }
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        await App.Database.DeleteReviewAsync(review);
        await Navigation.PopAsync();
    }
}