using Android.App;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AndroidPersistence
{
    [Activity(Label = "Persistencia con Android")]
    public class ContactListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var basePath = Application.Context.FilesDir.AbsolutePath;
            var filePath = Path.Combine(basePath, "contactos.json");

            var contacts = new List<Contacto>();

            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contacto>>(json);
            }
            
            ListAdapter = new ArrayAdapter<Contacto>(this,Android.Resource.Layout.SimpleListItem1, contacts);
        }
    }
}