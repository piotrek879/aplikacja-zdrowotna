using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public object LabelX { get; private set; }

        public krokomierz()
        {
            InitializeComponent();
        }

        private void start_Clicked(object sender, EventArgs e)
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

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            
        }

        private void stop_Clicked(object sender, EventArgs e)
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