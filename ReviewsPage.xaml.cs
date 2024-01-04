using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class ReviewsPage : ContentPage
{
	public ReviewsPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetReviewAsync();
    }
    async void OnReviewAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddReviewPage());
    }
    async void OnReviewSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Review selectedReview = e.SelectedItem as Review;

        // Crează o instanță a paginii de adăugare recenzie și setează BindingContext-ul cu recenzia selectată
        AddReviewPage addReviewPage = new AddReviewPage();
        addReviewPage.BindingContext = selectedReview;

        // Navighează către pagina de adăugare recenzie
        await Navigation.PushAsync(addReviewPage);
    }
}