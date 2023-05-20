CREATE DATABASE store_project;
USE store_project;
--------------------------------------------------------------------------------------------------
-- Tablas
--------------------------------------------------------------------------------------------------

--Tabla de clientes
CREATE TABLE customer (
  id_customer INT IDENTITY(1,1),
  Nombre VARCHAR(50),
  Direccion VARCHAR(100),
  Correo VARCHAR(20),
  NIT VARCHAR(20),
  primary key (id_customer)
);

--Tabla de productos
CREATE TABLE products (
  id_producto INT not null IDENTITY(1,1),
  Descripcion VARCHAR(50),
  id_marca INT,
  id_categoria INT,
  FechaRegistro DATE,
  Price DECIMAL(10,2),
  primary key (id_producto)
);


--Tabla de empresas
CREATE TABLE company (
	NIT varchar(20),
	Nombre VARCHAR(50),
	Direccion VARCHAR(50),
	Telefono VARCHAR(20),
	Correo VARCHAR(20),
	Portal VARCHAR(20),
	primary key (NIT)
);

--Tabla de ventas, 1
create table Sales_d (
	id_sale int not null identity(1,1),
	cantidad int not null,
	product INT not null REFERENCES products(id_producto),
	factura int not null FOREIGN KEY REFERENCES Sales_h(Numero),
	serie varchar (10) not null,
	primary key (id_sale)
);

--Tabla de ventas, 2
CREATE TABLE Sales_h (
   Numero int IDENTITY(1,1) PRIMARY KEY,
   Serie varchar(10) NOT NULL,
   Fecha date NOT NULL,
   codigo_cliente int NOT NULL REFERENCES customer(id_customer),
   nit_empresa varchar(20) NOT NULL REFERENCES company(NIT)
);

--Tabla de compras
CREATE TABLE compras (
  id INT PRIMARY KEY IDENTITY(1,1),
  descripcion VARCHAR(255),
  id_producto INT FOREIGN KEY REFERENCES products(id_producto),
  cantidad INT,
  fecha DATE
);

--Tabla de inventario
CREATE TABLE Inventory(
	id_inventory int not null identity(1,1),
	date_int date,
	date_out date,
	id_product int not null FOREIGN KEY REFERENCES products(id_producto),
	stock_in int not null,
	entries int not null,
	outlets int not null,
	primary key (id_inventory)
);

--------------------------------------------------------------------------------------------------
-- Triggers
--------------------------------------------------------------------------------------------------

--TRIGGER QUE SE EJECUTARA A LA HORA DE REALIZAR UNA COMPRA PARA ACTUALIZAR LA TABLA DE INVENTARIO

Create trigger TrCompraInventrario
on compras for insert
as
Declare @Cantidad int
Declare @Stock_in int
Declare @entries int
Declare @outlets int
Declare @Date_int date
Declare @Date_out date
Declare @id_producto int

Select @id_producto = id_producto, @Cantidad = cantidad, @Date_int = fecha, @Date_out = fecha from inserted 
Select @Stock_in =stock_in from Inventory where id_product = @id_producto;
Update Inventory set Inventory.stock_in = @Cantidad + @Stock_in, Inventory.date_int = @Date_int, Inventory.date_out = Inventory.date_out,
Inventory.id_product = @id_producto, Inventory.entries = @Cantidad + Inventory.entries, Inventory.outlets = Inventory.outlets
where Inventory.id_product = @id_producto
go


--Agrega al inventario el producto creado
Create trigger trAgregarProductoInventario
On products for insert
as
Declare @Stock_in int
Declare @entries int
Declare @outlets int
Declare @Date_int date
Declare @Date_out date
Declare @id_producto int

Select @id_producto = id_producto, @Date_int = FechaRegistro, @Date_out = FechaRegistro from inserted
insert into Inventory(id_product, outlets, stock_in, entries, date_int, date_out)
values(@id_producto, 0, 0, 0, @Date_int, @Date_out)
go


--Trigger cuando se hara una venta, actualizar el inventario
Create trigger TrVentaInventrario
on Sales_d for insert
as
Declare @Cantidad int
Declare @Stock_in int
Declare @entries int
Declare @outlets int
Declare @Date_int date
Declare @Date_out date
Declare @id_producto int
Declare @factura int
Declare @serie varchar(10)

Select @id_producto = product, @Cantidad = cantidad, @factura = factura, @serie = serie from inserted 
Select @Stock_in = stock_in from Inventory where id_product = @id_producto;
Select @Date_out = Fecha from Sales_h where @factura = Numero

if(@Stock_in >= @Cantidad)
begin
	Update Inventory set Inventory.stock_in = @Stock_in - @Cantidad, Inventory.date_int = Inventory.date_int, Inventory.date_out = @Date_out,
	Inventory.id_product = @id_producto, Inventory.entries = Inventory.entries, Inventory.outlets = Inventory.outlets + @Cantidad
	where Inventory.id_product = @id_producto
end
else
	RAISERROR('El producto no tiene stock', 16, 1)
	RETURN
go

--------------------------------------------------------------------------------------------------
-- Inserts
--------------------------------------------------------------------------------------------------

--Insercion de clientes
INSERT INTO customer ( Nombre, Direccion, Correo, NIT)
VALUES
( 'Juan Perez', 'Calle 123, Ciudad', 'juanz@outlook.com', '123456-7'),
( 'Maria Rodriguez', 'Avenida 456, Ciudad', 'mariaz@gmail.com', '987654-3'),
( 'Pedro Gomez', 'Carrera 789, Ciudad', 'pedrz@outlook.com', '543210-1'),
( 'Oscar Perez', 'Avenida Las Hostias, Ciudad', 'oPerez@gmail.com', '585896-4'),
( 'Kevin Osorio', 'Calle las Piscinas, Ciudad', 'osorioK@gmail.com', '256933-8');

--Insercion de productos
INSERT INTO products (Descripcion, id_marca, id_categoria, FechaRegistro, Price)
VALUES 
('Sopa Laky Men Camaron', 1, 1, GETDATE(), 5.00);

INSERT INTO products (Descripcion, id_marca, id_categoria, FechaRegistro, Price)
VALUES 
('Coca-Cola 2.5 Litros', 2, 2, GETDATE(), 22.00);

INSERT INTO products (Descripcion, id_marca, id_categoria, FechaRegistro, Price)
VALUES 
('Pepsi 3 Litros', 3, 2, GETDATE(), 15.00);

INSERT INTO products (Descripcion, id_marca, id_categoria, FechaRegistro, Price)
VALUES 
('Lift 3 Litros', 4, 2, GETDATE(), 15.00);

-- Insercion empresas
INSERT INTO company (NIT, Nombre, Direccion, Telefono, Correo, Portal)
VALUES
('123456-7', 'Los Pollos Hermanos S.A', 'Calle 1 #23-45', '555-1234', 'pollosher@gmail.com', 'www.pollosher.com'),
('987654-3', 'Las Margaritas S.A', 'Avenida 5 #12-34', '555-5678', 'margaritas@gmail.com', 'www.margaritas.com'),
('456789-0', 'La Esquinita', 'Carrera 8 #56-78', '555-9012', 'esquinita@gmail.com', 'www.esquinitas.com')

INSERT INTO compras (descripcion, id_producto, fecha, cantidad) VALUES
('Compra de 5 unidades', 10, GETDATE(), 5);

  INSERT INTO compras (descripcion, id_producto, fecha, cantidad) VALUES
('Compra de 20 unidades', 11, GETDATE(), 20);

  INSERT INTO compras (descripcion, id_producto, fecha, cantidad) VALUES
('Compra de 5 unidades', 12, GETDATE(), 5);

-- Insercion Ventas, 2
INSERT INTO Sales_h (Serie, Fecha, codigo_cliente, nit_empresa)
VALUES ('A001', '2023-05-10', 1, '123456-7');

INSERT INTO Sales_h (Serie, Fecha, codigo_cliente, nit_empresa)
VALUES ('A002', '2023-05-11', 2, '987654-3');

INSERT INTO Sales_h (Serie, Fecha, codigo_cliente, nit_empresa)
VALUES ('B001', '2023-05-12', 3, '456789-0');



INSERT INTO Sales_d (cantidad, product, factura, serie)
VALUES 
(10, 10, 1, 'ABC-01');
(5, 2, 5, 'ABC-01'),
(8, 3, 6, 'DEF-01');

INSERT INTO Sales_d(cantidad, product, factura, serie)
Values
(5, 1, 5, 'ABC-01');






select * from compras;
select * from products;
select * from Inventory;
select * from Sales_d;
select * from Sales_h;
select * from customer;
select * from company;



Select 
	id_producto 'ID Producto',
	descripcion 'Descripción del producto',
	cantidad 'Cantidad compra',
	fecha 'Fecha compra'
from compras



select id_sale 'ID Venta', cantidad 'Cantidad Venta', product 'ID Producto',
Descripcion 'Descripción Producto', factura 'No. de Factura', Sales_h.Serie 'Serie Factura', 
Fecha 'Fecha de emisión', codigo_cliente 'ID Cliente', Nombre 'Nombre Cliente'
from
Sales_d, Sales_h, products, customer
where factura = Numero and
product = id_producto and
codigo_cliente = id_customer



select
id_customer
from 
customer
where 
Nombre = 'Juan Perez'



Select
	id_inventory 'ID Inventario',
	id_product 'ID Producto',
	Descripcion 'Producto',
	FechaRegistro 'Registro Producto',
	stock_in 'En Stock',	
	date_int 'Fecha entrada',
	entries 'Entradas',
	date_out 'Fecha salida',
	outlets 'Salidas'
from
	Inventory, products
where
	id_product = id_producto


Select 
	compras.id_producto 'ID Producto', products.Descripcion 'Producto', compras.descripcion 'Descripción Compra', cantidad 'Cantidad compra', fecha 'Fecha compra' 
from
	compras, products 
where
	products.id_producto = compras.id_producto


-- select stock_in from Inventory where id_product = 

select Price from products where id_producto = 2