using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Views;
using PocketChange.Adapters;
using PocketChange.Fragments;

namespace PocketChange.Activities
{
    [Activity(Label = "History")]
    public class HistoryActivity : BaseActivity
    {
        private TabLayout tabLayout;
        private TabAdapter adapter;
        private ViewPager viewPager;
        public AppBarLayout appBar;

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_history;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Toolbar = FindViewById<Toolbar>(Resource.Id.historyToolbar);
            SetSupportActionBar(Toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //SupportActionBar.SetIcon(Resource.Drawable.ic_back_icon);
            SupportActionBar.SetTitle(Resource.String.history_name);

            //instantiate tab layout
            tabLayout = FindViewById<TabLayout>(Resource.Id.history_tab_layout);

            //instantiate viewpager
            viewPager = FindViewById<ViewPager>(Resource.Id.history_viewpager_layout);

            //instatiate AppBar
            appBar = FindViewById<AppBarLayout>(Resource.Id.history_toolbar_layout);

            //setup viewpager
            if (viewPager != null)
            {
                SetUpViewPager(viewPager);
            }

            //setup tab layout
            tabLayout.SetupWithViewPager(viewPager);
        }

        private void SetUpViewPager(ViewPager viewPager)
        {
            adapter = new TabAdapter(SupportFragmentManager);
            adapter.AddFragment(new HistoryOffers(), "Offers");
            adapter.AddFragment(new HistoryRedemption(), "Redemption");

            //tabLayout.TabSelected += TabLayout_TabSelected;
            //viewPager.PageScrolled += ViewPager_PageScrolled;
            //viewPager.PageSelected += ViewPager_PageSelected;
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