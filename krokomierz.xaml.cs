using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static App3.krokomierz;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class krokomierz : ContentPage
    {
        private double wartoscPoprzednia = 0;
        private int stepCount = 0;

        public krokomierz()
        {
            InitializeComponent();
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            if (Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);

       

        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {

            //while (true)
            //{

                //opoznienie pomiedzy krokami
                await Task.Delay(500);

                double x = e.Reading.Acceleration.X;
                double y = e.Reading.Acceleration.Y;
                double z = e.Reading.Acceleration.Z;

                //opoznienie pomiedzy krokami
                await Task.Delay(500);

                double wektorPrzyspieszenia = Math.Sqrt((x * x) + (y * y) + (z * z));
                double delta = (wektorPrzyspieszenia + wartoscPoprzednia) / 2;
                wartoscPoprzednia = wektorPrzyspieszenia;

                //stepCount++;

                if (delta > 1.5)
                {
                    stepCount++;
                }


                LabelX.Text = "Twoje polozenie X: " + e.Reading.Acceleration.X.ToString();
                LabelY.Text = "Twoje polozenie Y: " + e.Reading.Acceleration.Y.ToString();
                LabelZ.Text = "Twoje polozenie Z: " + e.Reading.Acceleration.Z.ToString();
                LabelWynik.Text = "Liczba twoich krokow: " + stepCount.ToString();

                //await Task.Delay(5000);

                /*LabelX.Text = e.Reading.Acceleration.X.ToString();
                LabelY.Text = e.Reading.Acceleration.Y.ToString();
                LabelZ.Text = e.Reading.Acceleration.Z.ToString();*/
            //}
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            if (!Accelerometer.IsMonitoring)
                return;
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            Accelerometer.Stop();
        }


        public class AccelerometerTest
        {
            // Set speed delay for monitoring changes.
            SensorSpeed speed = SensorSpeed.UI;

            public AccelerometerTest()
            {
                // Register for reading changes, be sure to unsubscribe when finished
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            }

            void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
            {
                var data = e.Reading;
                Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
                // Process Acceleration X, Y, and Z
            }

            public void ToggleAccelerometer()
            {
                try
                {
                    if (Accelerometer.IsMonitoring)
                        Accelerometer.Stop();
                    else
                        Accelerometer.Start(speed);
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
}