using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class AddReviewPage : ContentPage
{
	public AddReviewPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        review.Data = DateTime.UtcNow;
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