namespace AspNetCoreWebApi.Models
{
    public class CambiarEstadoPedidoRequest
    {
        public int PedidoId { get; set; }
        public int NuevoEstadoId { get; set; }
    }
}
