CREATE DATABASE Proyectos;
USE Proyectos;
GO
CREATE SCHEMA Proyecto;
GO
CREATE SCHEMA Configuracion;
GO
CREATE SCHEMA Seguridad;
GO

CREATE TABLE Configuracion.Plataforma(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Configuracion.Status(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Proyecto.Cliente(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Contacto VARCHAR(100) NOT NULL
);

CREATE TABLE Proyecto.Proyecto(
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(150) NOT  NULL,
	IdCliente INT NOT NULL,
	Inicio DATE NOT NULL,
	Termino DATE NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	IdPlataformaContacto INT NOT NULL,
	CONSTRAINT FK_Cliente_Proyecto FOREIGN KEY (IdCliente) REFERENCES Proyecto.Cliente(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT FK_Plataforma_Proyecto FOREIGN KEY (IdPlataformaContacto) REFERENCES Configuracion.Plataforma(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Proyecto.Actividad(
	Id INT IDENTITY PRIMARY KEY,
	FolioProyecto INT NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	Sprint TINYINT NOT NULL,
	FechaInicio DATE NOT NULL,
	IdStatus INT NOT NULL,
	CONSTRAINT FK_Proyecto_Actividad FOREIGN KEY (FolioProyecto) REFERENCES Proyecto.Proyecto(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT FK_Status_Actividad FOREIGN KEY (IdStatus) REFERENCES Configuracion.Status(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE Seguridad.Usuarios(
	Id INT IDENTITY PRIMARY KEY,
	Usr VARCHAR(255) NOT NULL,
	Passwd VARCHAR(255) NOT NULL
);

CREATE TABLE Configuracion.Log(
	Id INT IDENTITY PRIMARY KEY,
	IdProyecto INT NOT NULL,
	IdActividad INT,
	UsrRegistro VARCHAR(50) NOT NULL,
	Fecha DATE NOT NULL,
	Accion VARCHAR(200) NOT NULL
);
GO

CREATE PROCEDURE Proyecto.selStatusActual
@IdProyecto INT
AS

SELECT	TOP 1 P.Nombre Proyecto, P.Descripcion, pl.Nombre Plataforma,
		c.Nombre Cliente,
		a.Id IdActividad, a.Sprint, a.Descripcion Actividad,
		s.Nombre Status
FROM	Proyecto.Proyecto P join Configuracion.Plataforma pl
ON		P.IdPlataformaContacto = pl.Id join Proyecto.Cliente c
ON		P.IdCliente = c.Id join Proyecto.Actividad a
ON		p.Id = a.FolioProyecto join Configuracion.Status s
ON		a.IdStatus = s.Id
WHERE	P.Id = @IdProyecto AND a.FechaInicio >= GETDATE()
ORDER	BY a.FechaInicio