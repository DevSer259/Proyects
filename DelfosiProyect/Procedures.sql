-- Procedimiento para insertar un nuevo usuario
CREATE PROCEDURE InsertarUsuario
    @CodigoTrabajador VARCHAR(50),
    @Nombre VARCHAR(100),
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(20),
    @Puesto VARCHAR(50),
    @RolId INT
AS
BEGIN
    INSERT INTO Usuarios (CodigoTrabajador, Nombre, CorreoElectronico, Telefono, Puesto, RolId)
    VALUES (@CodigoTrabajador, @Nombre, @CorreoElectronico, @Telefono, @Puesto, @RolId);
END;
GO
-- Procedimiento para insertar un nuevo producto
CREATE PROCEDURE InsertarProducto
    @SKU VARCHAR(50),
    @Nombre VARCHAR(100),
    @Tipo VARCHAR(50),
    @Etiquetas VARCHAR(255),
    @Precio DECIMAL(18, 2),
    @UnidadMedida VARCHAR(50)
AS
BEGIN
    INSERT INTO Productos (SKU, Nombre, Tipo, Etiquetas, Precio, UnidadMedida)
    VALUES (@SKU, @Nombre, @Tipo, @Etiquetas, @Precio, @UnidadMedida);
END;
GO
-- Procedimiento para insertar un nuevo pedido
CREATE PROCEDURE InsertarPedido
    @FechaPedido DATETIME,
    @FechaRecepcion DATETIME,
    @FechaDespacho DATETIME,
    @FechaEntrega DATETIME,
    @VendedorId INT,
    @RepartidorId INT,
    @EstadoId INT
AS
BEGIN
    INSERT INTO Pedidos (FechaPedido, FechaRecepcion, FechaDespacho, FechaEntrega, VendedorId, RepartidorId, EstadoId)
    VALUES (@FechaPedido, @FechaRecepcion, @FechaDespacho, @FechaEntrega, @VendedorId, @RepartidorId, @EstadoId);
END;
GO
-- Procedimiento para insertar un producto en un pedido
CREATE PROCEDURE InsertarProductoPedido
    @PedidoId INT,
    @ProductoSKU VARCHAR(50),
    @Cantidad INT
AS
BEGIN
    INSERT INTO PedidoProductos (PedidoId, ProductoSKU, Cantidad)
    VALUES (@PedidoId, @ProductoSKU, @Cantidad);
END;
GO
-- Procedimiento para actualizar el estado de un pedido
CREATE PROCEDURE CambiarEstadoPedido
    @PedidoId INT,
    @NuevoEstadoId INT
AS
BEGIN
    UPDATE Pedidos
    SET EstadoId = @NuevoEstadoId
    WHERE NroPedido = @PedidoId;
END;
