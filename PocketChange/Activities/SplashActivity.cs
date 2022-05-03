using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Analytics;
using Android.OS;
using Android.Runtime;
using Java.Lang;
using PocketChange.Helpers;

namespace PocketChange.Activities
{
    [Activity(Label = "SplashActivity", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Theme = "@style/SplashTheme")]
    public class SplashActivity : Activity
    {
        //DO ANALYTICS
        private Tracker mTracker;

        private Thread splashThread = new Thread();
        private Class classs;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppAnalytics application = new AppAnalytics(Handle, JniHandleOwnership.DoNotRegister);
            mTracker = application.DefaultTracker;
            mTracker.SetScreenName("SplashActivity");
            mTracker.Send(new HitBuilders.ScreenViewBuilder().Build());

            splashThread.Run();
            try
            {
                int waited = 0;
                while (waited < Config.splash_delay)
                {
                    Thread.Sleep(100);
                    waited += 100;
                }
            }
            catch (InterruptedException e)
            {
                //do nothing
            }
            finally
            {
                Connection con = new Connection(this);
                bool connection = con.isConnectingToInternet();

                if (connection == true)
                {
                    //ADD SIGN IN CHECK HERE IF(BLAH BLAH BLAH)
                    //classs = new MainActivity().Class;
                    Intent intent = new Intent(BaseContext, typeof(MainActivity));
                    StartActivity(intent);
                    Finish();
                }
                else
                {
                    //classs = new RetryActivity().Class;
                    Intent intent = new Intent(BaseContext, typeof(RetryActivity));
                    StartActivity(intent);
                    Finish();
                }
            }

            splashThread.Start();
        }
    }
}