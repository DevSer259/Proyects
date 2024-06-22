namespace AspNetCoreWebApi.Models
{
    public class Producto
    {
        public string SKU { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Etiquetas { get; set; }
        public decimal Precio { get; set; }
        public string UnidadMedida { get; set; }
    }
}
