using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            //BEFORE
            //MainPage = new MainPage();
            //Now
            //We will launch the main page.
            MainPage = new NavigationPage(new MainPage());
        }

       


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
