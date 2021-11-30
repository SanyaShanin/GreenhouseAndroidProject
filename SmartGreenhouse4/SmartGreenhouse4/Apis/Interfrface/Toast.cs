using System;
using System.Collections.Generic;
using System.Text;
using Xamarin;
using Xamarin.Forms;

namespace SmartGreenhouse4.Apis.Interfrface
{
    public interface IToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }

    public static class Toast
    {
        public static void LongAlert(string message)
        {
            DependencyService.Get<IToast>().LongAlert(message);
        }
        public static void ShortAlert(string message)
        {
            DependencyService.Get<IToast>().ShortAlert(message);
        }
    }
}
