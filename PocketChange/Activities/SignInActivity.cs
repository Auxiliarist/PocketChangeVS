using Android.App;
using Android.OS;

namespace PocketChange.Activities
{
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : BaseActivity
    {
        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.activity_signin;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}