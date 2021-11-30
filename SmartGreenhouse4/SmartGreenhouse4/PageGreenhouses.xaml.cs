using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGreenhouse4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGreenhouses : ContentPage
    {
        public PageGreenhouses()
        {
            InitializeComponent();

            Appearing += PageGreenhouses_Appearing;
        }

        private void PageGreenhouses_Appearing(object sender, EventArgs e)
        {
            Shell.SetNavBarIsVisible(AppShell.Instance, true);
        }
    }
}