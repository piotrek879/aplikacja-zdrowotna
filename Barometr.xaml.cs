using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Barometr : ContentPage
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;

        public Barometr()
        {
            InitializeComponent();
            // Register for reading changes.
            Barometer.ReadingChanged += Barometer_ReadingChanged;
        }

        private void Godzina_Clicked(object sender, EventArgs e)
        {
            string godzina = DateTime.Now.Hour.ToString();
            string minuty = DateTime.Now.Minute.ToString();
            string sekundy = DateTime.Now.Second.ToString();
            GodzinaLabel.Text = "Aktualnie mamy godzinę: " + godzina + ":" + minuty + ":" + sekundy;
        }

        private void Cisnienie_Clicked(object sender, EventArgs e)
        {
            if (Barometer.IsMonitoring)
                return;
            Barometer.ReadingChanged += Barometer_ReadingChanged;
            Barometer.Start(SensorSpeed.UI);

        }

        void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            var data = e.Reading;
            // Process Pressure
            Console.WriteLine($"Reading: Pressure: {data.PressureInHectopascals} hectopascals");

            BarometrWynik.Text = "Ciśnienie wynosi: " + e.Reading.PressureInHectopascals.ToString() + "hPa";


            if(data.PressureInHectopascals <= 1000)
            {
                Samopoczucie.TextColor = Color.Red;
                Samopoczucie.Text = "Twoje samopoczucie może ulec zmianie !!!!!";
                Tresc.Text =    "Ze względu na to, że ciśnienie wynosi: " + data.PressureInHectopascals.ToString() + ", może to u Ciebie powodować: " + '\n' +
                                "- osłabienie" + '\n' +
                                "- bóle głowy" + '\n' +
                                "- złe samopoczucie" + '\n' +
                                "- bóle kości, mięśni, stawów" + '\n' +
                                "- skoki ciśnienia tętniczego krwi" + '\n' +
                                "- nadmierna senność lub bezsenność" + '\n' +
                                "- spadek energii życiowej" + '\n' +
                                "- niechęć do aktywności fizycznej" + '\n' +
                                "- wahania nastrojów" + '\n' +
                                "- zaburzenia koncentracji" + '\n';
            }
            else
            {
                Samopoczucie.TextColor = Color.Green;
                Samopoczucie.Text = "Ciśnienie nie powinno mieć wpływu na twoje samopoczucie";
                Tresc.Text = "";
            }

            
        }

        public void ToggleBarometer()
        {
            try
            {
                if (Barometer.IsMonitoring)
                    Barometer.Stop();
                else
                    Barometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // urzadzenie nie obsluguje czujnika
            }
            catch (Exception ex)
            {
                // inne bledy
            }
        }
    }
}