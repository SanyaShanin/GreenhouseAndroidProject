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

[assembly: Xamarin.Forms.Dependency(typeof(SmartGreenhouse4.Droid.LogAndroid))]
namespace SmartGreenhouse4.Droid
{
    public class LogAndroid : ILog
    {
        public void Write(string tag, string message)
        {
            Android.Util.Log.Debug(tag, message);
        }
    }
}