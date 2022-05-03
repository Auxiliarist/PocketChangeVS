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
using Java.Lang;
using PocketChange.Helpers;

namespace PocketChange.Activities
{
    [Activity(Label = "RetryActivity")]
    public class RetryActivity : BaseActivity
    {
        private TextView error;
        Button button;
        Class classs;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_retry;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            error = FindViewById<TextView>(Resource.Id.txt_retry);
            error.Text = "No Internet Connection!";

            button = FindViewById<Button>(Resource.Id.btn_retry);
            button.Click += (o, e) =>
            {
                retry();
            };
        }

        private void retry()
        {
            Connection con = new Connection(this);
            bool connection = con.isConnectingToInternet();

            if (connection == true)
            {
                classs = new MainActivity().Class;
                Intent intent = new Intent(BaseContext, classs);
                StartActivity(intent);
            }
            else
            {
                classs = new RetryActivity().Class;
                Intent intent = new Intent(BaseContext, classs);
                StartActivity(intent);
            }
        }
    }
}