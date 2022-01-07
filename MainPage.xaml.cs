using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

[assembly: ExportFont("ComicSansMS3.ttf")]
[assembly: ExportFont("FA5Regular.otf", Alias = "FontAwesome")]

namespace App3
{


    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Postepy_ClickedAsync(object sender, EventArgs e)
        {
            
            bool isFingerprintAvailable = await CrossFingerprint.Current.IsAvailableAsync(false);
            if (!isFingerprintAvailable)
            {
                await DisplayAlert("Błąd",
                    "Ustawienia biometryczne nie są dostępne lub nie zostały jeszcze skonfigurowane ", "OK");
                return;
            }

            AuthenticationRequestConfiguration conf =
                new AuthenticationRequestConfiguration("Zabezpieczenia",
                "Zabezpieczenie do Twoich danych");

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(conf);
            if (authResult.Authenticated)
            {
                //Success  
                await DisplayAlert("Sukces", "Tożsamość potwierdzona", "OK");
                Navigation.PushAsync(new Postepy());
            }
            else
            {
                await DisplayAlert("Błąd", "Nie można zidentyfikować odcisku palca", "OK");
            }

        }

        private void Ustawienia_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ustawienia());
        }

        private void Puls_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Puls());
        }

        private void Lokalizacja_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Lokalizacja());
        }

        private void Predkosc_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Predkosc());
        }

        private void krokomierz_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new krokomierz());
        }

        private void barometr_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Barometr());
        }


    }
}