using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using PocketChange.Adapters;
using PocketChange.Fragments;

namespace PocketChange.Activities
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/Icon")]
    public class MainActivity : BaseActivity
    {
        #region References

        private DrawerLayout drawerLayout;
        private NavigationView navigationView;
        private TabLayout tabLayout;
        private TabAdapter adapter;
        private ViewPager viewPager;
        private FloatingActionButton fab;
        public AppBarLayout appBar;
        public TextView pointTextView;
        private int totalPoints;
        private const int REQUEST_READ_PHONE_STATE = 1;
        private Java.Lang.Class classs;

        #endregion References

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_main;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //instantiate drawer layout
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //instantiate navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //instantiate tab layout
            tabLayout = FindViewById<TabLayout>(Resource.Id.tab_layout);

            //instantiate viewpager
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager_layout);

            //instantiate floating action button
            //fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            //instatiate AppBar
            appBar = FindViewById<AppBarLayout>(Resource.Id.toolbar_layout);

            //setup navigation view
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            //setup viewpager
            if (viewPager != null)
            {
                SetUpViewPager(viewPager);
            }

            //setup tab layout
            tabLayout.SetupWithViewPager(viewPager);

            //Setup the status bar color
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.SetStatusBarColor(Resources.GetColor(Resource.Color.primaryDark));
            }

            // you can use this to get the current points
            //totalPoints = PointsManager.getInstance(this).queryPoints();

            //If you only use Video Ad,you need to save the points by yourself ,we provide an example for you
            //totalPoints = diyLoadVideoReward();
            //pointTextView.setText(getResources().getString(R.string.text_current_points) + totalPoints);

            // Common Initialization, invoke it when application launches. Parameters: appId, appSecret.
            //AdManager.getInstance(this).init(mAppId, mAppSecret);

            //initOfferWall();

            //initVideoAd();

            //checking wheather the permission of READ_PHONE_STATE is granted
            checkReadPhoneStatePermission();

            //floating action bar click event
            //fab.Click += (sender, e) =>
            //{
            //    View view = sender as View;
            //    Snackbar.Make(view, "Testing Snackbar", Snackbar.LengthLong).SetAction("Action", v =>
            //    {
            //        //Snackbar action
            //        //Intent intent = new Intent();
            //    }).Show();
            //};
        }

        private void checkReadPhoneStatePermission()
        {
            int permissionCheck = (int)ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.ReadPhoneState);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                if (permissionCheck == (int)Permission.Denied)
                {
                    requestReadPhoneStatePermission();
                }
            }
        }

        private void requestReadPhoneStatePermission()
        {
            //You can choose a more friendly notice text. And you can choose any view you like, such as dialog.
            Toast.MakeText(this, "Only grant the permission, can you start the mission!", ToastLength.Long).Show();
            ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.ReadPhoneState }, REQUEST_READ_PHONE_STATE);
        }

        //Callback for requestPermission
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            try
            {
                switch (requestCode)
                {
                    case REQUEST_READ_PHONE_STATE:
                        {
                            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                            {
                                Toast.MakeText(this, "The Permission has granted,you can get your mission now", ToastLength.Short).Show();
                            }
                            else
                            {
                                //had not get the permission
                                Toast.MakeText(this, "Not get the permission,so you cannot get your mission", ToastLength.Short).Show();
                            }
                            break;
                        }
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
        }

        //private void initOfferWall()
        //{
        //    // (Optional) Adxmi Android OfferWall can customize OfferWall Browser Top Title Config
        //    setOfferBrowserConfig();

        //    // If using rewarded OfferWall advertisement, remember to invoke the initialization of rewarded offerwall advertisement:
        //    OffersManager.getInstance(this).onAppLaunch();

        //    // (Optional) Register listener for OfferWall currency points, to get notification of currency points changing
        //    PointsManager.getInstance(this).registerNotify(this);

        //    // (Optional) Register listener for earning OfferWall currency points
        //    PointsManager.getInstance(this).registerPointsEarnNotify(this);

        //    // (Optional) If showing the successfully earning  OfferWall  currency points hint in notification bar. The default value is
        //    // true, which means enable. False means disable.
        //    PointsManager.setEnableEarnPointsNotification(true);

        //    // (Optional) If showing the Toast hint of earning  OfferWall currency points. The default value is true, which means
        //    // enable. False means disable.
        //    // PointsManager.setEnableEarnPointsToastTips(false);
        //}

        //    private void initVideoAd()
        //    {
        //        // (Optional) Register listener for OfferWall currency points, to get notification of currency points earn
        //        VideoAdManager.getInstance(this).registerRewards(this);

        //        // (Optional)If jump to WebView page when click close btn.The default value is true,which means
        //        //enable.False means disable
        //        //VideoAdManager.setCloseBtnToDetail(false);

        //        // (Optional) If showing the Toast hint of earning  Video currency points. The default value is true, which means
        //        // enable. False means disable.
        //        VideoAdManager.setEnableRewardsToastTips(true);

        //        //Loading video ads
        //        VideoAdManager.getInstance(this).requestVideoAd(new VideoAdRequestListener() {
        //            @Override

        //            public void onRequestSucceed()
        //    {
        //        Log.e("adxmi", "video request succeed");
        //    }

        //    @Override
        //            public void onRequestFail(int errorCode)
        //    {
        //        // Interpretation of the error code: -1 for the network connection fails,please check the network. -2007 for no ads, -3312
        //        //for the device number of plays of the day has been completed, additional error codes generally equipment problems.
        //        Log.e("adxmi", "video request fail");
        //    }
        //});

        //}

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //destroyOfferWall();

            //destroyVideoAd();
        }

        private void destroyOfferWall()
        {
            // Noticed: If register listener in OnCreate, please remember to cancel the listener in onDestroy by invoking
            // unRegisterNotify.
            //PointsManager.getInstance(this).unRegisterNotify(this);

            // (Optional) Cancel listener for earning currency points. If register listener in onCreate, remember to cancel
            // it.
            //PointsManager.getInstance(this).unRegisterPointsEarnNotify(this);

            // Remember to invoke the below code on application exit, to tell SDK that the application is closed, which can
            // make SDK release some resource.
            //OffersManager.getInstance(this).onAppExit();
        }

        private void destroyVideoAd()
        {
            // (Optional) Cancel listener for earning currency points. If register listener in onCreate, remember to cancel
            // it.
            //VideoAdManager.getInstance(this).unRegisterRewards(this);

            // Remember to invoke the below code on application exit, to tell SDK that the application is closed, which can
            // make SDK release some resource about video.
            //VideoAdManager.getInstance(this).onDestroy();
        }

        private void SetUpDrawerContent(NavigationView navView)
        {
            //handle navigation
            navView.NavigationItemSelected += (sender, e) =>
            {
                IMenuItem item = e.MenuItem;
                //Checking if the item is in checked state or not, if not make it in checked state
                if (e.MenuItem.IsChecked == true)
                {
                    e.MenuItem.SetChecked(false);
                }
                else { e.MenuItem.SetChecked(true); }

                //Check to see which item was being clicked and perform appropriate action
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        Snackbar.Make(drawerLayout, "You selected: " + e.MenuItem.TitleFormatted, Snackbar.LengthLong).Show();
                        break;

                    case Resource.Id.nav_history:
                        classs = new HistoryActivity().Class;
                        Intent historyIntent = new Intent(BaseContext, classs);
                        StartActivity(historyIntent);

                        break;

                    case Resource.Id.extra_about:

                        classs = new AboutActivity().Class;
                        Intent aboutIntent = new Intent(BaseContext, classs);
                        StartActivity(aboutIntent);
                        break;
                }

                //Closing drawer on item click
                drawerLayout.CloseDrawers();
            };
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new Offers(), "Offers");
            adapter.AddFragment(new Share(), "Share");
            adapter.AddFragment(new Redeem(), "Redeem");

            tabLayout.TabSelected += TabLayout_TabSelected;
            viewPager.PageScrolled += ViewPager_PageScrolled;
            viewPager.PageSelected += ViewPager_PageSelected;
            viewPager.Adapter = adapter;
        }

        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            appBar.SetExpanded(true, true);
        }

        private void ViewPager_PageScrolled(object sender, ViewPager.PageScrolledEventArgs e)
        {
            appBar.SetExpanded(true, true);
        }

        private void TabLayout_TabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            viewPager.CurrentItem = e.Tab.Position;
            appBar.SetExpanded(false, true);
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    //change main_compat_menu
        //    MenuInflater.Inflate(Resource.Menu.actionbar_menu, menu);

        //    TextView lol = FindViewById<TextView>(Resource.Id.txt_money);
        //    //lol.SetText("pls", TextView.BufferType.Normal);
        //    lol.Text = "pls";
        //    InvalidateOptionsMenu();
        //    return base.OnCreateOptionsMenu(menu);
        //}

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);//Android.Support.V4.View.GravityCompat.Start);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            if (isNavDrawerOpen())
            {
                drawerLayout.CloseDrawers();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        protected bool isNavDrawerOpen()
        {
            return drawerLayout != null && drawerLayout.IsDrawerOpen((int)GravityFlags.Left);
        }
    }
}