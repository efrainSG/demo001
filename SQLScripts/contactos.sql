create database contactos;
go
use contactos;

create table Contacto(
Id int identity primary key,
Nombre varchar(150) not null,
Direccion varchar(150) not null,
Telefono varchar(20),
Correo varchar(255) not null,
Registro date not  null,
Comentario varchar(255) not null
);