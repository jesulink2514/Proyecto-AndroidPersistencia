using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AndroidPersistence
{
    [Activity(Label = "Persistencia con Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            


            var listButton = FindViewById<Button>(Resource.Id.Lista);
            listButton.Click+= (s, e) =>
            {
                var intent = new Intent(this,typeof(ContactListActivity));
                StartActivity(intent);
            };
        }
    }
}

