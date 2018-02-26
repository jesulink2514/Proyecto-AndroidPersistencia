using Android.App;
using Android.OS;
using Android.Widget;

namespace AndroidPersistence
{
    [Activity(Label = "Persistencia con Android")]
    public class ContactListActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var contacts = this.GetSharedPreferences("contactos",Android.Content.FileCreationMode.Private);

            var name = contacts.GetString("nombre",null);
            var telefono = contacts.GetString("telefono",null);

            var contact = new Contacto(name,telefono);

            var contactList = new[] {contact};

            ListAdapter = new ArrayAdapter<Contacto>(this,Android.Resource.Layout.SimpleListItem1,contactList);
        }
    }
}