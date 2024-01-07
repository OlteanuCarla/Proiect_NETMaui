using Proiect_NETMaui.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System;
namespace Proiect_NETMaui;

public partial class ProfilePage : ContentPage
{
    private ObservableCollection<Profile> profileList;

    public ProfilePage()
	{
		InitializeComponent();
        profileList = new ObservableCollection<Profile>();
        listView.ItemsSource = profileList;
    }
    async void OnProfileAddedClicked(object sender, EventArgs e)
    {
        if (profileList.Count == 0)
        {
            // Adăugați un nou profil
            //Profile newProfile = new Profile(); // poți încerca și await Navigation.PushAsync(new AddProfilePage());
            //AddProfilePage addProfilePage = new AddProfilePage { BindingContext = newProfile };
            //await Navigation.PushAsync(addProfilePage);
            var newProfile = new Profile();
            await Navigation.PushAsync(new AddProfilePage { BindingContext = newProfile });
            profileList.Add(newProfile);

        }
        else
        {
            // Afisați un mesaj sau luați măsuri corespunzătoare
            DisplayAlert("Attention", "You can only have one profile.", "OK");
        }

            // Dezactivați butonul după adăugarea profilului
            //(sender as ToolbarItem).IsEnabled = false;
    }
    async void OnProfileItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AddProfilePage
            {
                BindingContext = e.SelectedItem as Profile
            });
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProfileAsync();
    }

}