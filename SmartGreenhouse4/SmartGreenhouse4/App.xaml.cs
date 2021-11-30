using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SmartGreenhouse4.Apis.Models;

namespace SmartGreenhouse4
{
    public partial class App : Application
    {
        public static User loggedUser;
        public delegate void OnLogin(User user);
        public static OnLogin onLogin;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static void SetUser(User user)
        {
            loggedUser = user;
            onLogin.Invoke(user);
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

