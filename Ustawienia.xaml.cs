using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ustawienia : ContentPage
    {
        public Ustawienia()
        {
            InitializeComponent();
        }

        private async void AuthButton_Clicked(object sender, EventArgs e)
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
            }
            else
            {
                await DisplayAlert("Błąd", "Nie można zidentyfikować odcisku palca", "OK");
            }
        }
    }


}