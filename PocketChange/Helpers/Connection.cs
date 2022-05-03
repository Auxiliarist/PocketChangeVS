using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;

namespace PocketChange.Helpers
{
    public class Connection
    {
        Context context;

        public Connection(Context context)
        {
            this.context = context;
        }

        public bool isConnectingToInternet()
        {
            ConnectivityManager cm = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            NetworkInfo info = cm.ActiveNetworkInfo;
            if(info != null)
            {
                return true;
            }
            return false;
        }
    }
}