CREATE DATABASE Proyectos;
USE Proyectos;
GO
CREATE SCHEMA Proyecto;
GO
CREATE SCHEMA Configuracion;
GO
CREATE SCHEMA Seguridad;
GO

CREATE TABLE Configuracion.TipoStatus(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Configuracion.Status(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	IdTipoStatus INT NOT NULL,
	CONSTRAINT FK_TipoStatus_Status FOREIGN KEY(IdTipoStatus) REFERENCES Configuracion.TipoStatus(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Configuracion.Plataforma(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL
);

CREATE TABLE Proyecto.Cliente(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Correo VARCHAR(100) NOT NULL,
	Telefono VARCHAR(20),
	Direccion VARCHAR(200),
	Ciudad VARCHAR(100) NOT NULL
);

CREATE TABLE Proyecto.Contacto(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Correco VARCHAR(100) NOT NULL,
	Telefono VARCHAR(20),
	IdCliente INT NOT NULL,
	EsPrincipal BIT NOT NULL DEFAULT 0,
	CONSTRAINT FK_Cliente_Contacto FOREIGN KEY(IdCliente) REFERENCES Proyecto.Cliente(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Proyecto.Proyecto(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(150) NOT  NULL,
	Inicio DATE NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	IdCliente INT NOT NULL,
	IdStatus INT NOT NULL,
	Fin DATE NOT NULL,
IdPlataforma INT NOT NULL,
	CONSTRAINT FK_Cliente_Proyecto FOREIGN KEY (IdCliente) REFERENCES Proyecto.Cliente(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT FK_Status_Proyecto FOREIGN KEY (IdStatus) REFERENCES Configuracion.Status(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
CONSTRAINT FK_Plataforma_Proyecto FOREIGN KEY(IdPlataforma) REFERENCES Configuracion.Plataforma(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Proyecto.Actividad(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(200) NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	Tiempo INT NOT NULL DEFAULT 1,
	IdPrincipal INT NOT NULL DEFAULT 1,
	IdProyecto INT NOT NULL,
	IdStatus INT NOT NULL,
	Orden TINYINT NOT NULL,
	Sprint TINYINT NOT NULL,
	Inicio DATE NOT NULL,
	Fin DATE NOT NULL,
	CONSTRAINT FK_Proyecto_Actividad FOREIGN KEY (IdProyecto) REFERENCES Proyecto.Proyecto(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT FK_Status_Actividad FOREIGN KEY (IdStatus) REFERENCES Configuracion.Status(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);
GO

CREATE PROCEDURE Proyecto.selStatusActual
@IdProyecto INT
AS
SELECT	TOP 1
		P.Id,
		P.Nombre Proyecto, P.Descripcion, a.Nombre Actividad,
		c.Nombre Cliente,
		a.Orden NumActividad, a.Sprint,
		sp.Nombre StatusProyecto, sa.Nombre StatusActividad,
		pl.Nombre Plataforma, a.Inicio
FROM	Proyecto.Proyecto P left join Proyecto.Actividad a
ON		p.Id = a.IdProyecto left join Configuracion.Status sp
ON		p.IdStatus = sp.Id left join Configuracion.Status sa
ON		a.IdStatus = sa.Id left join Proyecto.Cliente c
ON		P.IdCliente = c.Id left join Proyecto.Contacto co
ON		c.Id = co.IdCliente left join Configuracion.Plataforma pl
ON		P.IdPlataforma = pl.Id
WHERE	P.Id = @IdProyecto
ORDER	BY a.Inicio