using System;

namespace PocketChange.Helpers
{
    public class Config
    {
        // Adxmi AppId
        private static string AppId = "12fabad923e031bd"; // not mine

        // Adxmi AppSecret
        private static string AppSecret = "c8fd8e4f7b0d3730"; // not mine

        //Admob Interstitial ID
        public static string AdMobInterstitialAd = "ca-app-pub-6842345471060895/4307504164";

        // Server URL ie., Webpanel Hosted Url
        //private static string Base_Url = "http://169.254.80.80:80/pocket/"; // mine
        private static string Base_Url = "http://10.0.0.5/pocket/"; // mine

        //public static string Url_Login = "http://127.0.0.1/android_login_api/login.php";
        //public static string Url_Register = "http://127.0.0.1/android_login_api/register.php";

        // Daily Reward Points
        private static int daily_reward = 25;

        // Splash screen delay (milliseconds) 1500 = 1.5 seconds
        public static int splash_delay = 1500;

        // Google Analytics OPTIONAL
        public static string analytics_property_id = "UA-82833223-1"; // mine

        // Share text and link for Share Button
        private static string share_text = "Hello, look what a beautiful app that I found here:";
        private static string share_link = "https://play.google.com/store/apps/details?id=com.droidoxy.pocket"; // not mine

        // APP RATING
        static string rate_later = "Perhaps Later";
        static string rate_never = "No Thanks";
        static string rate_yes = "Rate Now";
        static string rate_message = "We hope you enjoy using %1$s. Would you like to help us by rating us in the Store?";
        static string rate_title = "Enjoying our app?";

        // Do not Edit Req_Url
        public static string Req_Url = Base_Url + "receive_req.php";
    }
}