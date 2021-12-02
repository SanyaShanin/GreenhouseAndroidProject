using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SmartGreenhouse4.Apis;
using SmartGreenhouse4.Apis.Models;

namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreenhouseControlPage : ContentPage
    {
        public GreenhouseControlPage()
        {
            InitializeComponent();
            Appearing += PageOnAppearing;
        }

        private void PageOnAppearing(object sender, EventArgs e)
        {
            Refresh();
        }

        private async void Refresh()
        {
            Title = App.CurrentGreenhouse.name;
            var result = await Backend.GetGreenhouse(App.session, App.CurrentGreenhouse.id);
            label.Text = result.content;
        }
    }
}