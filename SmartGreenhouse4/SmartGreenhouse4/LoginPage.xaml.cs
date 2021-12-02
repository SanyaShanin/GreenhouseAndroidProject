using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SmartGreenhouse4.Apis;
using SmartGreenhouse4.Apis.Interfrface;
using SmartGreenhouse4.Apis.Models;

using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;


namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {
            InitializeComponent();

            Shell.SetNavBarIsVisible(AppShell.Current, false);
            Shell.SetPresentationMode(this, PresentationMode.ModalAnimated);
        }

        public async Task<bool> LoginWithSession(string session)
        {
            var result = await Backend.GetUser(session);

            if (!result.success)
            {
                Toast.LongAlert("Error while logging in: " + result.content);
                return false;
            }

            Log.Write("fingerprint", "session saving: " + session);
            Application.Current.Properties["session"] = session;
            Log.Write("fingerprint", "session saving: " + Application.Current.Properties["session"]);
            await Application.Current.SavePropertiesAsync();

            var user = User.FromJSON(result.content);
            App.SetUser(user);
            App.session = session;

            return true;
        }

        public async void OnLogin(object sender, EventArgs args)
        {
            loading.IsRunning = true;
            string session = "";
            var result = await Backend.Login(login.Text, password.Text);
            loading.IsRunning = false;

            if (!result.success || result.content == "invalid")
            {
                Toast.LongAlert("Error while logging in: " + result.content);
                return;
            }
            session = result.content;

            await LoginWithSession(session);
            loading.IsRunning = false;

            await AppShell.Current.GoToAsync("///main");
        }
        private async void OnRegister(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new RegistrationPage());
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
