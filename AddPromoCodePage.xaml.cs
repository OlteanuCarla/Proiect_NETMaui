using Plugin.LocalNotification;
using System;

namespace Proiect_NETMaui;

public partial class AddPromoCodePage : ContentPage
{
        public AddPromoCodePage()
        {
            InitializeComponent();
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            string enteredCode = promoCodeEntry.Text.Trim();

            if (IsValidPromoCode(enteredCode))
            {
                // Configurarea notificării
                var notification = new NotificationRequest
                {
                    NotificationId = 100,
                    Title = "Congratulations!",
                    Description = "You have received a 15% discount at your favorite restaurant.",
                   
                };

            // Programarea notificării
                LocalNotificationCenter.Current.Show(notification);

                // Închide pagina
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Invalid promo code. Please try again.", "OK");
            }
        }

        bool IsValidPromoCode(string code)
        {
            // Verifică dacă codul introdus este unul dintre cele acceptate
            return code.Equals("Panoramic15", StringComparison.OrdinalIgnoreCase) ||
                code.Equals("Klausen15", StringComparison.OrdinalIgnoreCase) ||
                code.Equals("Baracca15", StringComparison.OrdinalIgnoreCase) ||
                code.Equals("Toulouse15", StringComparison.OrdinalIgnoreCase) ||
                code.Equals("LittleHanoi15", StringComparison.OrdinalIgnoreCase) ||
                code.Equals("KupajGourmet15", StringComparison.OrdinalIgnoreCase) ||
                   code.Equals("Samsara15", StringComparison.OrdinalIgnoreCase);
        }
    }
