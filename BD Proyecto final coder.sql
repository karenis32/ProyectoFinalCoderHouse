Create database ProyectoFinalCoderHouse
use ProyectoFinalCoderHouse

create table usuario (id int identity(1,1) primary key, 
nombre varchar(50),
apellido varchar(50), 
edad int, 
genero varchar(10), 
mail varchar(50), 
pass varchar(50), 
dni varchar(50))

create table Producto(id int identity(1,1) primary key,
descripcion varchar(50),
valorcosto float,
valorventa float,
idUsuario int foreign key references usuario(id),
stock int)

create table Venta(id int identity(1,1) primary key,
descripcion varchar(50))

create table ProductoVenta(id int identity(1,1) primary key,
idProducto int foreign key references producto(id),
idVenta int foreign key references venta(id),
idUsuario int foreign key references usuario(id),
stockvendido int)

select * from Producto
where nombre like ''


SELECT
id,
descripcion,
valorcosto,
valorventa,idUsuario,
stock
from Producto 
where idUsuario = 0
 
