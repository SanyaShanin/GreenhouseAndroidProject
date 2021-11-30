using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartGreenhouse4.Apis.Interfrface;

[assembly: Xamarin.Forms.Dependency(typeof(SmartGreenhouse4.Droid.ToastAndroid))]
namespace SmartGreenhouse4.Droid
{
    public class ToastAndroid : IToast
    {
        public void LongAlert(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}