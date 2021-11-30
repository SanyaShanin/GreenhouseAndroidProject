using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartGreenhouse4.Apis.Models;

namespace SmartGreenhouse4
{
    public partial class App : Application
    {
        public static User loggedUser;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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

