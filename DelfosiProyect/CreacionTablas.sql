CREATE TABLE Roles (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    CodigoTrabajador VARCHAR(50) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Puesto VARCHAR(50),
    RolId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id)
);

CREATE TABLE Productos (
    SKU VARCHAR(50) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(50),
    Etiquetas VARCHAR(255),
    Precio DECIMAL(18, 2) NOT NULL,
    UnidadMedida VARCHAR(50)
);

CREATE TABLE EstadosPedidos (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Pedidos (
    NroPedido INT PRIMARY KEY IDENTITY(1, 1),
    FechaPedido DATETIME NOT NULL,
    FechaRecepcion DATETIME,
    FechaDespacho DATETIME,
    FechaEntrega DATETIME,
    VendedorId INT,
    RepartidorId INT,
    EstadoId INT,
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id),
    FOREIGN KEY (RepartidorId) REFERENCES Usuarios(Id),
    FOREIGN KEY (EstadoId) REFERENCES EstadosPedidos(Id)
);

CREATE TABLE PedidoProductos (
    PedidoId INT,
    ProductoSKU VARCHAR(50),
    Cantidad INT NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(NroPedido),
    FOREIGN KEY (ProductoSKU) REFERENCES Productos(SKU),
    PRIMARY KEY (PedidoId, ProductoSKU)
);

INSERT INTO Roles (Nombre) VALUES ('Encargado'), ('Vendedor'), ('Delivery'), ('Repartidor');
INSERT INTO EstadosPedidos (Nombre) VALUES ('Por atender'), ('En proceso'), ('En delivery'), ('Recibido');
