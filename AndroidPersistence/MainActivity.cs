using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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

                GuardarContacto(nombre,telf);

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

        private void GuardarContacto(string nombre, string telf)
        {
            var contacto = new Contacto(nombre,telf);
            
            var basePath = Application.Context.FilesDir.AbsolutePath;
            var filePath = Path.Combine(basePath,"contactos.json");

            var contacts = new List<Contacto>();
            if (File.Exists(filePath))
            {
                var contactsJson = File.ReadAllText(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contacto>>(contactsJson);
            }

            contacts.Add(contacto);

            var json = JsonConvert.SerializeObject(contacts);
        
            File.WriteAllText(filePath,json);
        }
    }
}

