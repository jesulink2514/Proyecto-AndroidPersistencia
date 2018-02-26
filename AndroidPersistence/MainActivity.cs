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
            
            var guard = FindViewById<Button>(Resource.Id.guardar);

            guard.Click += (s, e) =>
            {
                var nombreText = FindViewById<EditText>(Resource.Id.nombreText);
                var telefonoText = FindViewById<EditText>(Resource.Id.telefonoText);

                var nombre = nombreText.Text;
                var telf = telefonoText.Text;

                var contacts = this.GetSharedPreferences("contactos",FileCreationMode.Private);
                var edit = contacts.Edit();
                edit.PutString("nombre",nombre);
                edit.PutString("telefono",telf);
                
                edit.Commit();
                
                nombreText.Text = "";
                telefonoText.Text = "";

                Toast.MakeText(this,"Contacto guardado",ToastLength.Short).Show();

            };


            var listButton = FindViewById<Button>(Resource.Id.Lista);
            listButton.Click+= (s, e) =>
            {
                var intent = new Intent(this,typeof(ContactListActivity));
                StartActivity(intent);
            };
        }
    }
}

