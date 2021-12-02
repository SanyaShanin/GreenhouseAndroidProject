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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        public async void OnAccept(object sender, EventArgs args)
        {
            loading.IsRunning = true;

            if (rpassword.Text != password.Text)
            {
                Toast.LongAlert("Пароли не совпадают");
                return;
            }

            var result = await Backend.Register(login.Text, name.Text, password.Text);
            if (!result.success)
            {
                Toast.LongAlert("Error while registrating: " + result.content);
                return;
            }
            if (result.content == "login")
            {
                Toast.LongAlert("Длина логина должна быть от 4 до 40 символов");
                return;
            }
            if (result.content == "password")
            {
                Toast.LongAlert("Длина пароля должна быть от 4 до 40 символов");
                return;
            }
            if (result.content == "name")
            {
                Toast.LongAlert("Длина имени должна быть от 4 до 80 символов");
                return;
            }
            if (result.content == "exists")
            {
                Toast.LongAlert("Аккаунт с таким логином уже существует");
                return;
            }

            string session = result.content;

            await LoginWithSession(session);
            loading.IsRunning = false;

            await AppShell.Current.GoToAsync("///main");
        }
        private async void OnBack(object sender, EventArgs e)
        {
            await AppShell.Current.Navigation.PopAsync();
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
    }
}