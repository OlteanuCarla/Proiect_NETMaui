using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class AddReviewPage : ContentPage
{
	public AddReviewPage()
	{
		InitializeComponent();
        BindingContext = new Review();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        //double rating = ratingBar.Rating;
        var review = (Review)BindingContext;
        await App.Database.SaveReviewAsync(review);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        await App.Database.DeleteReviewAsync(review);
        await Navigation.PopAsync();
    }
}