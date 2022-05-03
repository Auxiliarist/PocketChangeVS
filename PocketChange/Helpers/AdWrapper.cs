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
using Android.Gms.Ads;

namespace PocketChange.Helpers
{
    public static class AdWrapper
    {
        public static InterstitialAd ConstructFullPageAdd(Context con, string UnitID)
        {
            var ad = new InterstitialAd(con);
            ad.AdUnitId = UnitID;
            return ad;
        }

        public static InterstitialAd CustomBuild(this InterstitialAd ad)
        {
            var requestbuilder = new AdRequest.Builder().AddTestDevice(AdRequest.DeviceIdEmulator).AddTestDevice("0A76127E7C4244B5E3BF2B5F91D61704");
            ad.LoadAd(requestbuilder.Build());
            return ad;
        }
    }
}