using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class PageGreenhouses : ContentPage
    {
        private ObservableCollection<Greenhouse> greenhouses;
        public ObservableCollection<Greenhouse> Greenhouses
        {
            get { return greenhouses; }
            set { greenhouses = value; }
        }
        public PageGreenhouses()
        {
            InitializeComponent();
            Greenhouses = new ObservableCollection<Greenhouse>() {};
            list.ItemsSource = Greenhouses;
            list.Refreshing += PageGreenhouses_Appearing;
            list.ItemTapped += OnGreenhouseClick;
            Appearing += PageGreenhouses_Appearing;
        }
        private void OnGreenhouseClick(object sender, ItemTappedEventArgs e)
        {
            App.CurrentGreenhouse = e.Item as Greenhouse;
            AppShell.Current.GoToAsync("///greenhouse");
        }
        private void PageGreenhouses_Appearing(object sender, EventArgs e)
        {
            Refresh();
        }
        private async void OnAddGreenhouse(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync("///add_greenhouse");
        }
        async void Refresh()
        {
            await App.loggedUser.Refresh(App.session);
            greenhouses.Clear();
            foreach(string id in App.loggedUser.greenhouses)
            {
                greenhouses.Add(new Greenhouse(id));
            }
            list.IsRefreshing = false;
        }
        
    }
}