-- Crear la base de datos
CREATE DATABASE CafeteriaDB;
GO

-- Usar la base de datos creada
USE CafeteriaDB;
GO

-- Crear la tabla TipoProducto
CREATE TABLE TipoProducto (
    tipoProducto_id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    UsuarioId INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    apellidoPaterno VARCHAR(100) NOT NULL,
    apellidoMaterno VARCHAR(100) NOT NULL,
    telefono VARCHAR(10) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contrasenia VARCHAR(255) NOT NULL,
    direccion VARCHAR(300) NOT NULL,
    fechaNacimiento DATE NOT NULL,
    edad INT NOT NULL,
    rol NVARCHAR(50) CHECK (rol IN ('Administrador', 'Empleado')) NOT NULL,
    fechaAlta DATETIME NOT NULL,
    fechaBaja DATETIME NULL,
    activo BIT NOT NULL DEFAULT 1
);
GO

-- Crear la tabla Productos
CREATE TABLE Productos (
    producto_id INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    imagen VARCHAR(200) NOT NULL, /* URL de ubicacion de la imagen */
    sabor VARCHAR(100) NOT NULL,
    tamanio VARCHAR(100) NOT NULL,
    unidad VARCHAR(100) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    fechaAlta DATETIME NOT NULL,
    activo BIT NOT NULL DEFAULT 1,
    tipoProducto_id INT NOT NULL,
    FOREIGN KEY (tipoProducto_id) REFERENCES TipoProducto(tipoProducto_id)
);
GO

-- Crear la tabla Ventas
CREATE TABLE Ventas (
    venta_id INT PRIMARY KEY IDENTITY(1,1),
    usuario_id INT NOT NULL,
    fechaVenta DATETIME NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(UsuarioId)
);
GO

-- Crear la tabla Detalle_Ventas
CREATE TABLE Detalle_Ventas (
    detalleVenta_id INT PRIMARY KEY IDENTITY(1,1),
    venta_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (venta_id) REFERENCES Ventas(venta_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);
GO

-- Crear la tabla Compras
CREATE TABLE Compras (
    compra_id INT PRIMARY KEY IDENTITY(1,1),
    usuario_id INT NOT NULL,
    fechaCompra DATETIME NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    activo BIT NOT NULL DEFAULT 1
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(UsuarioId)
);
GO

-- Crear la tabla Detalle_Compras
CREATE TABLE Detalle_Compras (
    detalleCompra_id INT PRIMARY KEY IDENTITY(1,1),
    compra_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(10, 2) NOT NULL,
    subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (compra_id) REFERENCES Compras(compra_id),
    FOREIGN KEY (producto_id) REFERENCES Productos(producto_id)
);
GO





/*=======> INSERCIONES DE EJEMPLO <=======*/
-- Usar la base de datos creada
USE CafeteriaDB;
GO

-- Insertar registros en la tabla TipoProducto
INSERT INTO TipoProducto (nombre, activo) VALUES
('Café', 1),
('Té', 1),
('Bebida Fria',1),
('Postre', 1),
('Snack', 1);
GO

-- Insertar registros en la tabla Usuarios
INSERT INTO Usuarios (nombre, apellidoPaterno, apellidoMaterno, telefono, email, contrasenia, direccion, fechaNacimiento, edad, rol, fechaAlta, activo) VALUES
('Leydi', 'Vazquez', 'Carreon', '5525353722', 'leydi.vazquez@example.com', 'password1', 'Calle Falsa 123', '1998-05-15', 26, 'Administrador', GETDATE(), 1),
('Sonia', 'Romero', 'Lopez', '5552345678', 'sonia.romero@example.com', 'password2', 'Avenida Siempre Viva 742', '1990-08-25', 31, 'Administrador', GETDATE(), 1),
('Miguel', 'Osorio', 'Garcia', '5553456789', 'miguel.osorio@example.com', 'password3', 'Boulevard Angeles 456', '1985-12-10', 35, 'Empleado', GETDATE(), 1),
('Fernanda', 'Carrera', 'Rodriguez', '5555678901', 'fernanda.carrera@example.com', 'password5', 'Parque de los Venados 101', '1987-07-20', 20, 'Empleado', GETDATE(), 1);
GO

-- Insertar registros en la tabla Productos
INSERT INTO Productos (nombre, descripcion, imagen, sabor, tamanio, unidad, precio, fechaAlta, activo, tipoProducto_id) VALUES
('Café Americano', 'Café negro sin azúcar', 'http://example.com/imagenes/cafe_americano.jpg', 'Americano','chico', 'Taza 250 ml', 35.00, GETDATE(), 1, 1),
('Café Americano', 'Café negro sin azúcar', 'http://example.com/imagenes/cafe_americano.jpg', 'Americano','mediano', 'Taza 350 ml', 40.00, GETDATE(), 1, 1),
('Café Americano', 'Café negro sin azúcar', 'http://example.com/imagenes/cafe_americano.jpg', 'Americano','grande', 'Taza 600 ml', 50.00, GETDATE(), 1, 1),
('Café Espresso', 'Café con sabor y textura más concentrada, con una superficie cremosa', 'http://example.com/imagenes/cafe_espresso .jpg', 'Expresso','chico', 'Taza 250 ml', 35.00, GETDATE(), 1, 1),
('Café Espresso', 'Café con sabor y textura más concentrada, con una superficie cremosa', 'http://example.com/imagenes/cafe_espresso .jpg', 'Expresso','mediano', 'Taza 350 ml', 40.00, GETDATE(), 1, 1),
('Café Espresso', 'Café con sabor y textura más concentrada, con una superficie cremosa', 'http://example.com/imagenes/cafe_espresso .jpg', 'Expresso','grande', 'Taza 600 ml', 50.00, GETDATE(), 1, 1),
('Capuchino', 'Café con leche y espuma', 'http://example.com/imagenes/capuchino.jpg', 'Capuchino','chico', 'Taza 250 ml', 40.00, GETDATE(), 1, 1),
('Capuchino', 'Café con leche y espuma', 'http://example.com/imagenes/capuchino.jpg', 'Capuchino','mediano', 'Taza 350 ml', 50.00, GETDATE(), 1, 1),
('Capuchino', 'Café con leche y espuma', 'http://example.com/imagenes/capuchino.jpg', 'Capuchino','grande', 'Taza 600 ml', 60.00, GETDATE(), 1, 1),
('Latte', 'Café con leche y espuma', 'http://example.com/imagenes/latte.jpg', 'Latte','chico', 'Taza 250 ml', 40.00, GETDATE(), 1, 1),
('Latte', 'Café con leche y espuma', 'http://example.com/imagenes/latte.jpg', 'Latte','mediano', 'Taza 350 ml', 50.00, GETDATE(), 1, 1),
('Latte', 'Café con leche y espuma', 'http://example.com/imagenes/latte.jpg', 'Latte','grande', 'Taza 600 ml', 60.00, GETDATE(), 1, 1),
('Té Verde', 'Té verde orgánico', 'http://example.com/imagenes/te_verde.jpg', 'Herbal','chico', 'Taza 250 ml', 30.00, GETDATE(), 1, 2),
('Té Verde', 'Té verde orgánico', 'http://example.com/imagenes/te_verde.jpg', 'Herbal','mediano', 'Taza 350 ml', 35.00, GETDATE(), 1, 2),
('Té Verde', 'Té verde orgánico', 'http://example.com/imagenes/te_verde.jpg', 'Herbal','grande', 'Taza 600 ml', 45.00, GETDATE(), 1, 2),
('Tisana Frutal', 'Tisana frutal', 'http://example.com/imagenes/tisana_frutal.jpg', 'Frutal','chico', 'Taza 250 ml', 40.00, GETDATE(), 1, 2),
('Tisana Frutal', 'Tisana frutal', 'http://example.com/imagenes/tisana_frutal.jpg', 'Frutal','mediano', 'Taza 350 ml', 45.00, GETDATE(), 1, 2),
('Tisana Frutal', 'Tisana frutal', 'http://example.com/imagenes/tisana_frutal.jpg', 'Frutal','grande', 'Taza 600 ml', 50.00, GETDATE(), 1, 2),
('Smoothie de Chocolate', 'Bebida fría de chocolate', 'http://example.com/imagenes/smoothie_chocolate.jpg', 'Chocolate','chico', 'Vaso 350 ml', 55.00, GETDATE(), 1, 3),
('Smoothie de Chocolate', 'Bebida fría de chocolate', 'http://example.com/imagenes/smoothie_chocolate.jpg', 'Chocolate','grande', 'Vaso 600 ml', 65.00, GETDATE(), 1, 3),
('Smoothie de Vainilla', 'Bebida fría de vainilla', 'http://example.com/imagenes/smoothie_vainilla.jpg', 'Vainilla','chico', 'Vaso 350 ml', 55.00, GETDATE(), 1, 3),
('Smoothie de Vainilla', 'Bebida fría de vainilla', 'http://example.com/imagenes/smoothie_vainilla.jpg', 'Vainilla','grande', 'Vaso 600 ml', 65.00, GETDATE(), 1, 3),
('Smoothie de Fresa', 'Bebida fría de fresa', 'http://example.com/imagenes/smoothie_fresa.jpg', 'Fresa','chico', 'Vaso 350 ml', 55.00, GETDATE(), 1, 3),
('Smoothie de Fresa', 'Bebida fría de fresa', 'http://example.com/imagenes/smoothie_fresa.jpg', 'Fresa','grande', 'Vaso 600 ml', 65.00, GETDATE(), 1, 3),
('Muffin de Chocolate', 'Muffin con trozos de chocolate', 'http://example.com/imagenes/muffin_chocolate.jpg', 'Chocolate', 'chico', 'Pieza', 35.00, GETDATE(), 1, 4),
('Brownie', 'Brownie de chocolate', 'http://example.com/imagenes/brownie.jpg', 'Chocolate', 'chico', 'Porción', 35.00, GETDATE(), 1, 4),
('Sandwich', 'Sandwich de jamón y queso', 'http://example.com/imagenes/sandwich.jpg', 'Jamon', 'chico', 'Pieza', 40.00, GETDATE(), 1, 5),
('Croissant', 'Croissant de jamón y queso', 'http://example.com/imagenes/croissant.jpg', 'Jamon', 'chico', 'Pieza', 45.00, GETDATE(), 1, 5);
GO

-- Insertar registros en la tabla Ventas
INSERT INTO Ventas (usuario_id, fechaVenta, total) VALUES
(2, GETDATE(), 5.00),
(3, GETDATE(), 6.50),
(4, GETDATE(), 3.00),
(2, GETDATE(), 4.00),
(3, GETDATE(), 7.50);
GO

-- Insertar registros en la tabla Detalle_Ventas
INSERT INTO Detalle_Ventas (venta_id, producto_id, cantidad, precio_unitario, subtotal) VALUES
(1, 1, 1, 1.50, 1.50),
(1, 2, 1, 3.50, 3.50),
(2, 3, 2, 3.00, 6.00),
(2, 4, 1, 0.50, 0.50),
(3, 5, 1, 3.00, 3.00),
(4, 2, 2, 2.00, 4.00),
(5, 4, 2, 2.00, 4.00),
(5, 5, 2, 1.75, 3.50);
GO

-- Insertar registros en la tabla Compras
INSERT INTO Compras (usuario_id, fechaCompra, total,activo) VALUES
(1,GETDATE(), 10.00, 1),
(2, GETDATE(), 15.00, 1),
(3, GETDATE(), 20.00, 1),
(4, GETDATE(), 25.00, 1),
(2, GETDATE(), 30.00, 1);
GO

-- Insertar registros en la tabla Detalle_Compras
INSERT INTO Detalle_Compras (compra_id, producto_id, cantidad, precio_unitario, subtotal) VALUES
(11, 1, 10, 1.00, 10.00),
(11, 2, 5, 2.00, 10.00),
(12, 3, 7, 3.00, 21.00),
(12, 4, 5, 4.00, 20.00),
(13, 5, 4, 5.00, 20.00),
(13, 1, 6, 1.00, 6.00),
(14, 2, 8, 2.00, 16.00),
(14, 3, 3, 3.00, 9.00),
(15, 4, 7, 4.00, 28.00),
(15, 5, 6, 5.00, 30.00);
GO