using Proiect_NETMaui.Models;
namespace Proiect_NETMaui;

public partial class AddProfilePage : ContentPage
{
	public AddProfilePage()
	{
		InitializeComponent();
        BindingContext = new Profile();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var profile = (Profile)BindingContext;
        //slist.Name = Restaurant.Name;
        await App.Database.SaveProfileAsync(profile);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var profile = (Profile)BindingContext;
        System.Diagnostics.Debug.WriteLine($"Trying to delete profile: {profile.Nume} {profile.Prenume}");
        await App.Database.DeleteProfileAsync(profile);
        await Navigation.PopAsync();
    }
    async void OnAddPromoCodeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPromoCodePage());
    }
}