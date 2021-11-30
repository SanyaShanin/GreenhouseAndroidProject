using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartGreenhouse4.Apis.Interfrface
{
    public interface ILog
    {
        void Write(string tag, string message);
    }

    public static class Log
    {
        public static void Write(string tag, string message)
        {
            DependencyService.Get<ILog>().Write(tag, message);
        }
    }
}
