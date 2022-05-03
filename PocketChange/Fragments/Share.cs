using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace PocketChange.Fragments
{
    public class Share : Fragment
    {
        private Android.Support.V7.Widget.Toolbar toolbar;
        private RecyclerView recyclerView;
        public WebView webview;
        private Android.App.ProgressDialog progressBar;
        private string url;
        private Uri uri;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_share, container, false);

            uri = new Uri("http://kazoolink.com/publisherapp?key=2100&userid={user_id}&headerhidden=1");
            webview = view.FindViewById<WebView>(Resource.Id.id_web);
            webview.ScrollBarStyle = ScrollbarStyles.OutsideOverlay;
            webview.Settings.JavaScriptEnabled = true;
            webview.SetLayerType(LayerType.Software, null);

            AlertDialog alertDialog = new AlertDialog.Builder(Context).Create();
            progressBar = Android.App.ProgressDialog.Show(Context, "Please Wait", "Loading...");
            WebViewClient client = new WebViewClient();
            if (uri != null && uri.ToString().StartsWith("http") || uri.ToString().EndsWith("sms:?"))
            {
                
               // Intent intent = new Intent(Context, System.Web.HttpUtility.ParseQueryString(uri.Query).GetType());
                //view.Context.StartActivity(intent);
                client.ShouldOverrideUrlLoading(webview, uri.ToString());
            }
            else if (uri.ToString().StartsWith("whatsapp"))
            {
                bool ok = checkWhatsapp("com.whatsapp");
                if (ok)
                {
                    //if you have whatsapp, start whatsapp

                    //Intent intent = new Intent((Context)Intent.ActionView, System.Web.HttpUtility.ParseQueryString(uri.Query).get);
                    //view.Context.StartActivity(intent);
                    client.ShouldOverrideUrlLoading(webview, uri.ToString());
                }
                else
                {
                    alertDialog.SetTitle("App is not installed");
                    alertDialog.SetButton(0, "OK", (o, e) => { });
                    alertDialog.Show();
                }
                alertDialog.Show();
            }
           // else { return (View)false; }

            client.OnPageFinished(webview, uri.ToString());
            

            client.OnReceivedError(webview, ClientError.UnsupportedScheme, "Unsupported Uri", "yeah");

            webview.LoadUrl("http://kazoolink.com/publisherapp?key=2100&userid={USERID}&headerhidden=1");
            webview.CanGoBack();
            
            

            if (progressBar.IsShowing)
                progressBar.Dismiss();

            return view;

        }

        

        private bool checkWhatsapp(string uri)
        {
            PackageManager pm = Activity.PackageManager;
            bool inst;
            try
            {
                pm.GetPackageInfo(uri, PackageInfoFlags.Activities);
                inst = true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                inst = false;
            }
            return inst;
        }

    }
}