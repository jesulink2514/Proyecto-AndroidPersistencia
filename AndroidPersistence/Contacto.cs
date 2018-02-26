namespace AndroidPersistence
{
    public class Contacto
    {
        public Contacto()
        {
        }

        public Contacto(string nombre,string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }

        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - {Telefono}";
        }
    }
}