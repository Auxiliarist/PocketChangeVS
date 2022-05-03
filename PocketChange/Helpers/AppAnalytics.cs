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
using Android.Gms.Analytics;

namespace PocketChange.Helpers
{
    class AppAnalytics : Application
    {
        Tracker mTracker;

        public Tracker DefaultTracker
        {
            get
            {
                if (mTracker == null)
                {
                    var analytics = GoogleAnalytics.GetInstance(this);
                    // Add your Tracking ID here
                    mTracker = analytics.NewTracker(Config.analytics_property_id);
                }
                return mTracker;
            }
        }

        public AppAnalytics(IntPtr handle, JniHandleOwnership ownerShip) : base (handle, ownerShip)
		{
        }

    }
}