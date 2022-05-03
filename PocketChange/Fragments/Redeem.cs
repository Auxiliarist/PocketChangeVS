using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Text;
using Java.Util;
using Org.Apache.Http;
using Org.Apache.Http.Client;
using Org.Apache.Http.Client.Entity;
using PocketChange.Helpers;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using NewString = Java.Lang.String;
using Java.Lang;
using Java.Net;
using PocketChange.Activities;
using Android.Content;

namespace PocketChange.Fragments
{
    public class Redeem : Fragment 
    {
        private float totalPoints;
        public CardView card_paypal;
        public CardView card_amazon;
        public CardView card_gplay;
        public CardView card_steam;
        public Snackbar snackbar;
        private Java.Lang.Class classs;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //CREATE CARDVIEWS, ADD BUTTON TO LAYOUT, ATTACH WITHDRAW METHOD TO BUTTON CLICK EVENT
            View view = inflater.Inflate(Resource.Layout.fragment_redeem, container, false);

            card_paypal = view.FindViewById<CardView>(Resource.Id.cardview_paypal);
            card_amazon = view.FindViewById<CardView>(Resource.Id.cardview_amazon);
            card_gplay = view.FindViewById<CardView>(Resource.Id.cardview_gplay);
            card_steam = view.FindViewById<CardView>(Resource.Id.cardview_steam);

            card_paypal.Click += Card_paypal_Click;
            card_amazon.Click += Card_amazon_Click;
            card_gplay.Click += Card_gplay_Click;
            card_steam.Click += Card_steam_Click;

            return view;
        }

        private void Card_steam_Click(object sender, EventArgs e)
        {
            card_steam.Selected = !card_steam.Selected;
            View view = sender as View;
            //snackbar = Snackbar.Make(view, "Steam Selected", Snackbar.LengthLong);

            if (card_paypal.Selected || card_gplay.Selected || card_amazon.Selected)
            {
                card_paypal.Selected = false;
                card_gplay.Selected = false;
                card_amazon.Selected = false;

            }
            
            if (card_steam.Selected == true)
            {
                Snackbar.Make(view, "Steam Wallet Card Selected", Snackbar.LengthLong).SetAction("Redeem Now", v =>
                     {
                         card_steam.Selected = false;

                         //Snackbar action
                         classs = new OfferWallActivity().Class;
                         Intent intent = new Intent(Activity.BaseContext, typeof(OfferWallActivity));
                         intent.PutExtra("card_steam.Selected", true);
                         StartActivity(intent);

                     }).Show();
                //snackbar.SetDuration(Snackbar.LengthLong).Show();

            }
            //snackbar.Dismiss();
        }

        private void Card_gplay_Click(object sender, EventArgs e)
        {
            card_gplay.Selected = !card_gplay.Selected;
            View view = sender as View;
            //snackbar = Snackbar.Make(view, "Google Play Card Selected", Snackbar.LengthLong);
            if (card_paypal.Selected || card_amazon.Selected || card_steam.Selected)
            {
                card_paypal.Selected = false;
                card_amazon.Selected = false;
                card_steam.Selected = false;
            }

            if (card_gplay.Selected == true)
            {
                Snackbar.Make(view, "Google Play Card Selected", Snackbar.LengthLong).SetAction("Redeem Now", v =>
                     {
                         card_gplay.Selected = false;

                         //Snackbar action
                         Intent intent = new Intent(Activity.BaseContext, typeof(OfferWallActivity));
                         intent.PutExtra("card_gplay.Selected", true);
                         StartActivity(intent);
                     }).Show();
                //snackbar.SetDuration(Snackbar.LengthLong).Show();

            }
        }

        private void Card_amazon_Click(object sender, EventArgs e)
        {
            card_amazon.Selected = !card_amazon.Selected;
            View view = sender as View;
            //snackbar = Snackbar.Make(view, "Amazon Selected", Snackbar.LengthLong);
            if (card_paypal.Selected || card_gplay.Selected || card_steam.Selected)
            {
                card_paypal.Selected = false;
                card_gplay.Selected = false;
                card_steam.Selected = false;
            }

            if (card_amazon.Selected == true)
            {
                Snackbar.Make(view, "Amazon Gift Card Selected", Snackbar.LengthLong).SetAction("Redeem Now", v =>
                     {
                         card_amazon.Selected = false;

                         //Action you want to run when user hits Confirm
                         Intent intent = new Intent(Context, typeof(OfferWallActivity));
                         intent.PutExtra("card_amazon.Selected", true);
                         StartActivity(intent);
                     }).Show();
                //snackbar.SetDuration(Snackbar.LengthLong).Show();

            }
        }

        private void Card_paypal_Click(object sender, EventArgs e)
        {
            card_paypal.Selected = !card_paypal.Selected;
            View view = sender as View;
            //snackbar = Snackbar.Make(view, "Paypal Selected", Snackbar.LengthLong);
            if (card_amazon.Selected || card_gplay.Selected || card_steam.Selected)
            {
                card_amazon.Selected = false;
                card_gplay.Selected = false;
                card_steam.Selected = false;
            }

            if (card_paypal.Selected == true)
            {
                Snackbar.Make(view, "PayPal Selected", Snackbar.LengthLong).SetAction("Redeem Now", v =>
                     {
                         //Snackbar action
                         Withdraw("PayPal", 1.00f , "$1", "Enter your PayPal Email");
                     }).Show();
                //snackbar.SetDuration(Snackbar.LengthLong).Show();
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
                AlertDialog.Builder alert = new AlertDialog.Builder(Activity);

                alert.SetTitle("PocketChange");
                alert.SetMessage(gift_message);

                // Set an EditText view to get user input
                EditText input = new EditText(Activity.BaseContext);
                input.SetTextColor(Android.Graphics.Color.Black);
                alert.SetView(input);

                alert.SetPositiveButton("Redeem Now", (dialog, whichbutton) =>
                {
                    string user_input = input.Text.ToString();
                    insert(user_input, gift_name, amount, points);

                    card_paypal.Selected = false;
                    card_amazon.Selected = false;
                    card_gplay.Selected = false;
                    card_steam.Selected = false;
                });

                alert.SetNegativeButton("Cancel", (dialog, whichbutton) =>
                {
                    //cancelled
                    card_paypal.Selected = false;
                    card_amazon.Selected = false;
                    card_gplay.Selected = false;
                    card_steam.Selected = false;
                });

                alert.Show();
            }
            else
            {
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

            //SendPostReqAsyncTask sendPostReqAsyncTask = new SendPostReqAsyncTask();
            //sendPostReqAsyncTask.Execute(dbUserInput, withdraw_Name);

            //NewString method = new NewString("register");
            //NewString userInput = new NewString(user_input);
            //NewString giftName = new NewString(gift_name);

            //btask.Execute(method, userInput, giftName);
        }

        private void Client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            System.Console.WriteLine("Working");
        }

        private class SendPostReqAsyncTask : AsyncTask<NewString, Java.Lang.Void, NewString>
        {

            NewString pls = null;
            Redeem redeem = new Redeem();
            protected override Java.Lang.String RunInBackground(params Java.Lang.String[] @params)
            {

                System.Collections.Generic.List<INameValuePair> nameValuePairs = new System.Collections.Generic.List<INameValuePair>();
                
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("user_input", redeem.dbUserInput));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("deviceName", redeem.dbDeviceName));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("deviceMan", redeem.dbDeviceMan));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("withdraw_name", redeem.dbWithdrawName));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("amount", redeem.dbWithdrawAmount));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("money", redeem.dbMo));
                //nameValuePairs.Add(new Org.Apache.Http.Message.BasicNameValuePair("Current_Date", redeem.dbCurrentDate));
                //ADD MORE 

                try
                {
                    IHttpClient client = new Org.Apache.Http.Impl.Client.DefaultHttpClient();
                    Org.Apache.Http.Client.Methods.HttpPost post = new Org.Apache.Http.Client.Methods.HttpPost(Helpers.Config.Req_Url); //edit url
                    post.Entity = new UrlEncodedFormEntity(nameValuePairs);
                   
                    IHttpResponse response = client.Execute(post);
                    IHttpEntity entity = response.Entity;
                }
                catch (ClientProtocolException e)
                {
                    e.PrintStackTrace();
                }
                catch(Java.IO.IOException e)
                {
                    e.PrintStackTrace();
                }
                //Java.Lang.String pls = (Java.Lang.String)"success";

                //jvmobj.ToArray<Java.Lang.String>();
                //jvmobj = pls;
                //Java.Lang.String.CopyValueOf(jvmobj);
                 pls = new NewString("success");

                return pls;
                
            }

            protected override void OnPostExecute(Java.Lang.String result)
            {
                base.OnPostExecute(result);

                if (result == pls)
                {
                    //PointsManager.getInstance(RedeemActivity.this).spendPoints(points);
                    //              new SweetAlertDialog(RedeemActivity.this, SweetAlertDialog.CUSTOM_IMAGE_TYPE)
                    //              .setTitleText("Great!")
                    //              .setContentText(points + " Points Successfully Redeemed for " + amount)
                    //                  .setCustomImage(R.drawable.custom_img)
                    //                  .setConfirmText("OK")
                    //                  .setConfirmClickListener(new SweetAlertDialog.OnSweetClickListener() {
                    //                      @Override

                    //                      public void onClick(SweetAlertDialog sDialog)
                    //      {
                    //          // reloading activity

                    //          Intent intent = getIntent();
                    //          finish();
                    //          startActivity(intent);

                    //      }
                    //  })
                    //.show();
                    System.Console.WriteLine("Working");
                }
                else
                {
                    //   new SweetAlertDialog(RedeemActivity.this, SweetAlertDialog.ERROR_TYPE)
                    //.setTitleText("Something's Wrong")
                    //.setContentText("Please Update the App to Redeem !!")
                    //.show();
                }
            }
        }

    }
}