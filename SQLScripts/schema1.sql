create database tienda;
go
use tienda;
go

create schema super;
go

create schema catalogo;
go

create schema ente;
go

create schema negocio;
go

create schema administracion;
go

create table super.tipostatus(
id int identity primary key,
nombre varchar(100) not null
);
go

create table super.tipoubicacion(
id int identity primary key,
nombre varchar(100) not null
);
go

create table super.tipolocalidad(
id int identity primary key,
nombre varchar(100) not null
);
go

create table super.tipooferta(
id int identity primary key,
nombre varchar(100) not null
);
go

create table catalogo.status(
id int identity primary key,
nombre varchar(100) not null,
idtipostatus int not null,
constraint fk_tipostatus_status foreign key (idtipostatus) references super.tipostatus(id) on update no action on delete no action
);
go

create table catalogo.seccion(
id int identity primary key,
nombre varchar(100) not null,
idstatus int not null,
constraint fk_status_seccion foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table catalogo.etiqueta(
id int identity primary key,
nombre varchar(100) not null,
idstatus int not null,
constraint fk_status_etiqueta foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table catalogo.plantilla(
id int identity primary key,
nombre varchar(100) not null,
idstatus int not null,
constraint fk_status_plantilla foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table catalogo.localidad(
id int identity primary key,
nombre varchar(255) not null,
idtipolocalidad int not null,
idlocalidad int,
constraint fk_tipolocalidad_localidad foreign key (idtipolocalidad) references super.tipolocalidad(id) on update no action on delete no action,
constraint fk_localidad_localidad foreign key (idlocalidad) references catalogo.localidad(id) on update no action on delete no action
);
go

create table catalogo.seccionplantilla(
id int identity primary key,
idplantilla int not null,
idseccion int not null,
idstatus int not null,
constraint fk_plantilla_seccionplantilla foreign key (idplantilla) references catalogo.plantilla(id) on update no action on delete no action,
constraint fk_seccion_seccionplantilla foreign key (idseccion) references catalogo.seccion(id) on update no action on delete no action,
constraint fk_status_seccionplantilla foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table ente.propietario(
id int identity primary key,
nombre varchar(255) not null,
telefono varchar(20) not null,
direccion varchar(255) not null,
correo varchar(150) not null,
passwd varchar(255) not null,
registro date not null
);
go

create table ente.negocio(
id int identity primary key,
nombre varchar(255) not null,
correo varchar(150) not null,
urllogo varchar(255) not null,
idpropietario int not null,
idstatus int not null,
constraint fk_propietario_negocio foreign key (idpropietario) references ente.propietario(id) on update no action on delete no action,
constraint fk_status_negocio foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table negocio.etiquetas(
id int identity primary key,
idnegocio int not null,
idetiqueta int not null,
constraint fk_negocio_etiquetas foreign key (idnegocio) references ente.negocio(id) on update no action on delete no action,
constraint fk_etiqueta_etiquetas foreign key (idetiqueta) references catalogo.etiqueta(id) on update no action on delete no action
);
go

create table negocio.negocioplantilla(
id int identity primary key,
contenido text not null,
idnegocio int not null,
idseccionplantilla int not null,
idstatus int not null,
constraint fk_negocio_negocioplantilla foreign key (idnegocio) references ente.negocio(id) on update no action on delete no action,
constraint fk_seccionplantilla_negocioplantilla foreign key (idseccionplantilla) references catalogo.seccionplantilla(id) on update no action on delete no action,
constraint fk_status_negocioplantilla foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table negocio.oferta(
id int identity primary key,
nombre varchar(150) not null,
descripcion varchar(255) not null,
precio decimal(10,2) not null,
mostrarprecio bit not null,
idnegocio int not null,
idtipooferta int not null,
idstatus int not null,
constraint fk_negocio_oferta foreign key (idnegocio) references ente.negocio(id) on update no action on delete no action,
constraint fk_tipooferta_oferta foreign key (idtipooferta) references super.tipooferta(id) on update no action on delete no action,
constraint fk_status_oferta foreign key (idstatus) references catalogo.status(id) on update no action on delete no action
);
go

create table negocio.contacto(
id int identity primary key,
nombre varchar(255) not null,
telefono varchar(20) not null,
correo varchar(150) not null,
comentario varchar(255) not null,
fecha date not null,
idnegocio int not null,
constraint fk_negocio_contacto foreign key (idnegocio) references ente.negocio(id) on update no action on delete no action
);
go