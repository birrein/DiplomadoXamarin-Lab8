using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab8
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //var ViewGroup = (Android.Views.ViewGroup)
            //    Window.DecorView.FindViewById(Android.Resource.Id.Content);
            //var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;

            //var HeaderImage = new ImageView(this);
            //HeaderImage.SetImageResource(Resource.Drawable.xamarin_diplomado_30);
            //MainLayout.AddView(HeaderImage);

            //var UserNameTextView = new TextView(this);
            //UserNameTextView.Text = GetString(Resource.String.UserName);
            //MainLayout.AddView(UserNameTextView);

            string EMail = "";
            string Password = "";
            string Device = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var UserNameResTextView = FindViewById<TextView>(Resource.Id.UserNameResTextView);
            var StatusResTextView = FindViewById<TextView>(Resource.Id.StatusResTextView);
            var TokenResTextView = FindViewById<TextView>(Resource.Id.TokenResTextView);

            Validate();

            async void Validate()
            {
                var ServiceClient = new SALLab08.ServiceClient();
                var SvcResult = await ServiceClient.ValidateAsync(EMail, Password, Device);

                UserNameResTextView.Text = SvcResult.Fullname;
                StatusResTextView.Text = SvcResult.Status.ToString();
                TokenResTextView.Text = SvcResult.Token;

                Result = $"{SvcResult.Status}\n{SvcResult.Fullname}\n{SvcResult.Token}";
            }
        }
    }
}

