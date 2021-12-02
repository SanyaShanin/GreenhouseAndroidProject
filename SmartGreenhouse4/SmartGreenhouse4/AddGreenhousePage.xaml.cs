using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SmartGreenhouse4.Apis.Interfrface;
using SmartGreenhouse4.Apis;

namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGreenhousePage : ContentPage
    {
        public AddGreenhousePage()
        {
            InitializeComponent();
        }
        private void OnAddGreenhouse(object sender, EventArgs e)
        {
            AddGreenhouse(id.Text);
        }
        private async void AddGreenhouse(string greenhouse)
        {
            var result = await Backend.UserAddGreenhouse(App.session, greenhouse);
            if (!result.success) { 
                Toast.LongAlert("Error on adding greenhouse: " + result.content);
            } else
            if (result.content == "session")
            {
                Toast.LongAlert("Сессия устарела, попробуйте перезапустить приложение");
            } else
            if (result.content == "greenhouse")
            {
                Toast.LongAlert("Идентификатор не найден в базе данных");
            } else
            if (result.content == "exists")
            {
                Toast.LongAlert("Эта теплица уже добавлена");
            }
            else
            {
                await AppShell.Current.GoToAsync("///main");
            }
        }
    }
}