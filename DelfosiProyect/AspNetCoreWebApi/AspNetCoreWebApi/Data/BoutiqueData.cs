using AspNetCoreWebApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace AspNetCoreWebApi.Data
{
    public class BoutiqueData
    {
        private readonly string conexion;

        public BoutiqueData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("CadenaSQL")!;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(conexion);
        }

        // Método para insertar un usuario
        public async Task InsertarUsuario(Usuario usuario)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("InsertarUsuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CodigoTrabajador", usuario.CodigoTrabajador);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                    command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    command.Parameters.AddWithValue("@Puesto", usuario.Puesto);
                    command.Parameters.AddWithValue("@RolId", usuario.RolId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }



        // Método para insertar un producto
        public async Task InsertarProducto(Producto producto)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SKU", producto.SKU);
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Tipo", producto.Tipo);
                    command.Parameters.AddWithValue("@Etiquetas", producto.Etiquetas);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@UnidadMedida", producto.UnidadMedida);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        // Método para insertar un pedido
        public async Task<int> InsertarPedido(Pedido pedido)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("InsertarPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                    command.Parameters.AddWithValue("@FechaRecepcion", pedido.FechaRecepcion);
                    command.Parameters.AddWithValue("@FechaDespacho", pedido.FechaDespacho);
                    command.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                    command.Parameters.AddWithValue("@VendedorId", pedido.VendedorId);
                    command.Parameters.AddWithValue("@RepartidorId", pedido.RepartidorId);
                    command.Parameters.AddWithValue("@EstadoId", pedido.EstadoId);

                    var outputParameter = new SqlParameter("@PedidoId", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputParameter);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();

                    return (int)outputParameter.Value;
                }
            }
        }

        // Método para insertar un producto en un pedido
        public async Task InsertarProductoPedido(int pedidoId, ProductoPedidoRequest productoPedido)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("InsertarProductoPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PedidoId", pedidoId);
                    command.Parameters.AddWithValue("@ProductoSKU", productoPedido.ProductoSKU);
                    command.Parameters.AddWithValue("@Cantidad", productoPedido.Cantidad);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }


        // Método para cambiar el estado de un pedido
        public async Task CambiarEstadoPedido(int pedidoId, int nuevoEstadoId)
        {
            using (var connection = GetConnection())
            {
                using (var command = new SqlCommand("CambiarEstadoPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PedidoId", pedidoId);
                    command.Parameters.AddWithValue("@NuevoEstadoId", nuevoEstadoId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
