using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using PocketChange.Activities;
using Java.Lang;
using Android.Content;
using Android.Gms.Ads;
using PocketChange.Helpers;
using PocketChange.Adapters;
using Android.Util;
using System.Threading.Tasks;

//ADD THREE CARD VIEWS: ONE INTERSTITIAL, ONE VIDEO, ONE OFFERWALL. HAVE A SEPARATE OFFERWALL ACTIVITY FOR NATIVE ADS

namespace PocketChange.Fragments
{
    public class Offers : Fragment
    {
        InterstitialAd mInterstitialAd;
        private Class classs;
        private Button signupTest;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public static Offers NewInstance()
        {
            var frag2 = new Offers { Arguments = new Bundle() };
            return frag2;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_offers, container, false);

     
            //load ad on diff thread
            //var finalAd = AdWrapper.ConstructFullPageAdd(Context, Config.InterstitialAd);
            //var listener = new AdEventListener();
            
            //listener.AdClosed += () =>
            //{
            //    finalAd.CustomBuild();
            //};
            //finalAd.AdListener = listener;
            //finalAd.CustomBuild();


            //signupTest = view.FindViewById<Button>(Resource.Id.testsdasd);
            //signupTest.Click += (o, e) =>
            //{
            //    classs = new SignInActivity().Class;
            //    Intent intent = new Intent(Context, classs);
            //    StartActivity(intent);

            //    if (finalAd.IsLoaded)
            //    {
            //        finalAd.Show();
            //    }
            //    else
            //    {
            //        Toast.MakeText(Context, "Ad not loaded, please try again", ToastLength.Short).Show();
            //    }


            //};
            
            //wrap offer onclick event with a signin check

            return view;
        }
    
    }
}