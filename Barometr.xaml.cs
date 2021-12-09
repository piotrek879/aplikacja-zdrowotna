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

            BarometrWynik.Text = "Cisnienie wynosi: " + e.Reading.PressureInHectopascals.ToString();

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
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}