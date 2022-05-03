using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using System.Net;
using Java.Util;
using Java.Text;
using System;
using PocketChange.Helpers;
using System.Collections.Specialized;

namespace PocketChange.Activities
{
    [Activity(Label = "OfferActivity")]
    public class OfferWallActivity : BaseActivity
    {
        private Toolbar mToolbar;
        private Android.Widget.Button amazontest;
        private AppCompatSpinner spinner;
        private Android.Widget.TextView amatext;

        private float totalPoints;

        bool steam = false;
        bool gplay = false;
        bool amazon = false;
        bool paypal = false;

        protected override int LayoutResource
        {
            get
            {
                //if (steam == true)
                //    return Resource.Layout.activity_history;
                //else if (gplay == true)
                //    return Resource.Layout.activity_about;
                //else
                    return Resource.Layout.activity_offerwall;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Toolbar = FindViewById<Toolbar>(Resource.Id.offerwallToolbar);
            //SetSupportActionBar(Toolbar);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            //paypal here
            amazon = Intent.GetBooleanExtra("card_amazon.Selected", false);
            gplay = Intent.GetBooleanExtra("card_gplay.Selected", false);
            steam = Intent.GetBooleanExtra("card_steam.Selected", false);

            //Paypal Here
            //if(paypal)
            //{

            //}


            if (amazon)
            {
                gplay = false;
                steam = false;

                View view = LayoutInflater.Inflate(Resource.Layout.redeem_amazon, null, false);
                attachToolbarToLayout(LayoutInflater, (ViewGroup)view, Resource.String.amazon_name);
                SetContentView(view);
                Window.SetSoftInputMode(SoftInput.StateHidden);

                amazontest = view.FindViewById<Android.Widget.Button>(Resource.Id.btn_redeem_amazon);
                //spinner = view.FindViewById<AppCompatSpinner>(Resource.Id.spinnernamehere);

                amazontest.Click += (o, e) => //this is gonna be the final redeem button underneath everything
                {
                    switch (spinner.SelectedItemPosition)
                    {
                        default:
                        case 0:
                            //Withdraw(..., 100, ..., ...);
                            break;
                        case 1:
                            //Withdraw(..., 500, ..., ...);
                            break;
                            //amatext.IsInputMethodTarget;
                            
                    }
                };
            }


            if (gplay)
            {
                steam = false;


                View view = LayoutInflater.Inflate(Resource.Layout.redeem_gplay, null, false);
                attachToolbarToLayout(LayoutInflater, (ViewGroup)view, Resource.String.gplay_name);
                SetContentView(view);

            }


            if (steam)
            {
                gplay = false;

                View view = LayoutInflater.Inflate(Resource.Layout.redeem_steam, null, false);
                attachToolbarToLayout(LayoutInflater, (ViewGroup)view, Resource.String.steam_name);
                SetContentView(view);

            }

        }


        public void Withdraw(string Gift_Name, float Points_To_Redeem, string Gift_Amount, string Gift_Message)
        {
            string gift_name = Gift_Name;
            float points = Points_To_Redeem;
            string amount = Gift_Amount;
            string gift_message = Gift_Message;
            totalPoints = 2.00f;

            if (totalPoints >= points)
            {
                //points = how much it actally costs, amount is the string for the database
                //user_input = email
                //EditText input = new EditText(Activity.BaseContext); CHANGE EDIT TEXT USING FINDVIEWID EDIT TEXTS
                //string user_input = input.Text.ToString();
                //insert(user_input, gift_name, amount, points); WHAT WE USE FOR THE DB
            }

        }

        public void insert(string user_input, string gift_name, string amount, float points)
        {
            string deviceName = Build.Model;
            string deviceMan = Build.Manufacturer;

            Calendar cal = Calendar.Instance;
            SimpleDateFormat dateFormat = new SimpleDateFormat("MM-dd-yyyy");
            string Current_Date = dateFormat.Format(cal.Time);

            string mo = "" + points;

            insertToDatabase(user_input, deviceName, deviceMan, gift_name, amount, points, mo, Current_Date);
        }

        public void insertToDatabase(string user_input, string deviceName, string deviceMan, string gift_name, string amount, float points, string po, string Current_Date)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(Config.Req_Url);
            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("user_input", user_input);
            parameters.Add("deviceName", deviceName);
            parameters.Add("deviceMan", deviceMan);
            parameters.Add("gift_name", gift_name);
            parameters.Add("amount", amount);
            parameters.Add("points", po);
            parameters.Add("Current_Date", Current_Date);

            client.UploadValuesAsync(uri, parameters);
            client.UploadValuesCompleted += Client_UploadValuesCompleted;

        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            //ADD ALERT DIALOG
            System.Console.WriteLine("Working");
        }

        private void attachToolbarToLayout(LayoutInflater inflater, ViewGroup parent, int toolbarName)
        {
            mToolbar = (Android.Support.V7.Widget.Toolbar)inflater.Inflate(Resource.Layout.toolbar, parent, false);
            mToolbar.Elevation = 10f;
            SetSupportActionBar(mToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetTitle(toolbarName);

            parent.AddView(mToolbar, 0);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:

                    Finish();
                    break;
            }
            return true;
        }
    }
}