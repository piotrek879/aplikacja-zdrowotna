using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        private void Postepy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Postepy());
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

    }
}
