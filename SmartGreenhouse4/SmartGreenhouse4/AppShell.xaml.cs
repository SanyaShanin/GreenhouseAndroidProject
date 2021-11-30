using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

using SmartGreenhouse4.Apis.Interfrface;
using SmartGreenhouse4.Apis.Models;

namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public static AppShell Instance;
        public AppShell()
        {
            Instance = this;
            InitializeComponent();
            App.onLogin += UpdateUser;
        }

        public async void OnLogout(object sender, EventArgs e)
        {
            App.loggedUser = null;
            App.Current.Properties["session"] = "";
            await Application.Current.SavePropertiesAsync();
            await AppShell.Current.Navigation.PushModalAsync(new LoginPage());
            Shell.Current.FlyoutIsPresented = false;
        }
        public void UpdateUser(User user)
        {
            login.Text = user.name;
        }
    }
}
