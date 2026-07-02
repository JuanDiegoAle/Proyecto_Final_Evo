CREATE DATABASE VentasDB;
GO

USE VentasDB;
GO

-- =========================
-- USUARIO
-- =========================
CREATE TABLE Usuario (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Rol VARCHAR(20) NOT NULL
);

-- =========================
-- PRODUCTO (ROPA)
-- =========================
CREATE TABLE Producto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);

-- =========================
-- PEDIDO
-- =========================
CREATE TABLE Pedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Total DECIMAL(10,2) NULL,
    MetodoPago VARCHAR(50) NULL,
    Usuario VARCHAR(50) NULL,
    Cliente NVARCHAR(100) NOT NULL
);

-- =========================
-- DEVOLUCION
-- =========================
CREATE TABLE Devolucion (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT NOT NULL,
    Motivo VARCHAR(200) NULL,
    Fecha DATETIME NULL,
    Usuario VARCHAR(50) NULL,

    FOREIGN KEY (PedidoId) REFERENCES Pedido(Id)
);

-- =========================
-- DATOS DE PRUEBA
-- =========================

-- Usuarios
INSERT INTO Usuario (Username, Password, Rol) VALUES
('admin', '123', 'Admin'),
('vendedor', '123', 'Vendedor');

-- Productos (ROPA)
INSERT INTO Producto (Nombre, Precio, Stock) VALUES
('Polo Básico', 35.00, 50),
('Jean Azul', 90.00, 30),
('Vestido Rojo', 120.00, 20),
('Casaca Negra', 150.00, 15),
('Falda Blanca', 70.00, 25);

-- Pedidos
INSERT INTO Pedido (Total, MetodoPago, Usuario, Cliente) VALUES
(125.00, 'Efectivo', 'vendedor', 'Ana Lopez'),
(90.00, 'Tarjeta', 'vendedor', 'Luis Perez');

-- Devoluciones
INSERT INTO Devolucion (PedidoId, Motivo, Fecha, Usuario) VALUES
(1, 'Talla incorrecta', GETDATE(), 'vendedor');