namespace AspNetCoreWebApi.Models
{
    public class Pedido
    {
        public int NroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int VendedorId { get; set; }
        public int RepartidorId { get; set; }
        public int EstadoId { get; set; }
        public List<ProductoPedidoRequest> Productos { get; set; }
    }
}
