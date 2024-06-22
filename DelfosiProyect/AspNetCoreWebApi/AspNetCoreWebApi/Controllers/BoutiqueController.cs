using AspNetCoreWebApi.Data;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoutiqueController : ControllerBase
    {
        private readonly BoutiqueData _boutiqueData;
        public BoutiqueController(BoutiqueData boutiqueData)
        {
            _boutiqueData = boutiqueData;
        }


        // Método para creación de pedido
        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] CrearPedidoRequest request)
        {
            var pedido = new Pedido
            {
                FechaPedido = request.FechaPedido,
                FechaRecepcion = request.FechaRecepcion,
                FechaDespacho = request.FechaDespacho,
                FechaEntrega = request.FechaEntrega,
                VendedorId = request.VendedorId,
                RepartidorId = request.RepartidorId,
                EstadoId = request.EstadoId,
                Productos = request.Productos
            };

            var pedidoId = await _boutiqueData.InsertarPedido(pedido);

            foreach (var producto in request.Productos)
            {
                await _boutiqueData.InsertarProductoPedido(pedidoId, producto);
            }

            return Ok(new { PedidoId = pedidoId });
        }

        // Método para cambiar el estado de un pedido
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstadoPedido(int id, [FromBody] CambiarEstadoPedidoRequest request)
        {
            await _boutiqueData.CambiarEstadoPedido(id, request.NuevoEstadoId);
            return NoContent();
        }
    }
}
