using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SmartGreenhouse4.Apis.Models;
using SmartGreenhouse4.Apis.Interfrface;
using SmartGreenhouse4.Apis;

namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(AppShell.Current, false);
            Process();
        }

        public async void Process()
        {
            if (await LoginWithSavedSession())
            {
                await AppShell.Current.GoToAsync("///main");
            }
            else
            {
                await AppShell.Current.Navigation.PushModalAsync(new LoginPage());
            }
        }

        public async Task<bool> LoginWithSavedSession()
        {
            string session = "";
            if (Application.Current.Properties.ContainsKey("session"))
            {
                session = Application.Current.Properties["session"] as string;
            }
            if (session == "")
            {
                return false;
            }

            var result = await Backend.GetUser(session);

            if (!result.success)
            {
                return false;
            }

            Application.Current.Properties["session"] = session;
            await Application.Current.SavePropertiesAsync();

            var user = User.FromJSON(result.content);
            App.loggedUser = user;

            return true;
        }
    }
}