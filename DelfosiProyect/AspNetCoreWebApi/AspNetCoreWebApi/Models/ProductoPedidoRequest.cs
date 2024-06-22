namespace AspNetCoreWebApi.Models
{
    public class ProductoPedidoRequest
    {
        public int PedidoId { get; set; }
        public string ProductoSKU { get; set; }
        public int Cantidad { get; set; }
    }
}
