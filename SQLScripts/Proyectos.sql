USE [master]
GO
/****** Object:  Database [Proyectos]    Script Date: 11/01/2019 02:40:46 p. m. ******/
CREATE DATABASE [Proyectos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyectos', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Proyectos.mdf' , SIZE = 5184KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Proyectos_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Proyectos_log.ldf' , SIZE = 5248KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Proyectos] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyectos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyectos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyectos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyectos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyectos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyectos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyectos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Proyectos] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Proyectos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyectos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyectos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyectos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyectos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyectos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyectos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyectos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyectos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Proyectos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyectos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyectos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyectos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyectos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyectos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyectos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyectos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Proyectos] SET  MULTI_USER 
GO
ALTER DATABASE [Proyectos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyectos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyectos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyectos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Proyectos]
GO
/****** Object:  Schema [Configuracion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
CREATE SCHEMA [Configuracion]
GO
/****** Object:  Schema [Negocio]    Script Date: 11/01/2019 02:40:49 p. m. ******/
CREATE SCHEMA [Negocio]
GO
/****** Object:  Schema [Proyecto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
CREATE SCHEMA [Proyecto]
GO
/****** Object:  Schema [Seguridad]    Script Date: 11/01/2019 02:40:49 p. m. ******/
CREATE SCHEMA [Seguridad]
GO
/****** Object:  StoredProcedure [Configuracion].[delClasificacion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delClasificacion] @Id int AS DELETE FROM Clasificacion WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delGiro]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delGiro] @Id int AS DELETE FROM Giro WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delPlataforma]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delPlataforma] @Id int AS DELETE FROM Plataforma WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delSeccion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delSeccion] @Id int AS DELETE FROM Seccion WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delStatus] @Id int AS DELETE FROM Status WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delTipo]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delTipo] @Id int AS DELETE FROM Tipo WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[delTipoStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[delTipoStatus] @Id int AS DELETE FROM TipoStatus WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Configuracion].[InsClasificacion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsClasificacion] @Id INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.Clasificacion(Id, Nombre)VALUES (@Id, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsGiro]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsGiro] @Id INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.Giro(Id, Nombre)VALUES (@Id, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsPlataforma]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsPlataforma] @Id INT, @Nombre VARCHAR(100), @Descripcion VARCHAR(MAX) AS BEGIN INSERT INTO Configuracion.Plataforma(Id, Nombre, Descripcion)VALUES (@Id, @Nombre, @Descripcion) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsSeccion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsSeccion] @Id INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.Seccion(Id, Nombre)VALUES (@Id, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsStatus] @Id INT, @IdTipoStatus INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.Status(Id, IdTipoStatus, Nombre)VALUES (@Id, @IdTipoStatus, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsTipo]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsTipo] @Id INT, @IdClasificacion INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.Tipo(Id, IdClasificacion, Nombre)VALUES (@Id, @IdClasificacion, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[InsTipoStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[InsTipoStatus] @Id INT, @Nombre VARCHAR(100) AS BEGIN INSERT INTO Configuracion.TipoStatus(Id, Nombre)VALUES (@Id, @Nombre) END;

GO
/****** Object:  StoredProcedure [Configuracion].[listarGiros]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Configuracion].[listarGiros]
AS
BEGIN
	SELECT	G.Id, G.Nombre
	FROM	Configuracion.Giro G
	ORDER	BY G.Nombre
END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdClasificacion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdClasificacion] @Id INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.Clasificacion SET Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdGiro]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdGiro] @Id INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.Giro SET Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdPlataforma]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdPlataforma] @Id INT, @Nombre VARCHAR(100), @Descripcion VARCHAR(MAX) AS BEGIN UPDATE Configuracion.Plataforma SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdSeccion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdSeccion] @Id INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.Seccion SET Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdStatus] @Id INT, @IdTipoStatus INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.Status SET IdTipoStatus = @IdTipoStatus, Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdTipo]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdTipo] @Id INT, @IdClasificacion INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.Tipo SET IdClasificacion = @IdClasificacion, Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Configuracion].[UpdTipoStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[UpdTipoStatus] @Id INT, @Nombre VARCHAR(100) AS BEGIN UPDATE Configuracion.TipoStatus SET Nombre = @Nombre WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [dbo].[delsysdiagrams]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delsysdiagrams] @diagram_id int AS DELETE FROM sysdiagrams WHERE diagram_id = @diagram_id

GO
/****** Object:  StoredProcedure [Negocio].[delAdministrador]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delAdministrador] @Id int AS DELETE FROM Administrador WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delContacto] @Id int AS DELETE FROM Contacto WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delDescripcionTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delDescripcionTienda] @Id int AS DELETE FROM DescripcionTienda WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delFoto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delFoto] @Id int AS DELETE FROM Foto WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delFotoOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delFotoOferta] @Id int AS DELETE FROM FotoOferta WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delHorario]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delHorario] @Id int AS DELETE FROM Horario WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delOferta] @Id int AS
BEGIN
	DELETE
	FROM	Negocio.FotoOferta
	WHERE	IdOferta = @Id

	DELETE
	FROM	Negocio.OfertaSucursal
	WHERE	IdOferta = @Id

	DELETE
	FROM	Oferta
	WHERE	Id = @Id
END
GO
/****** Object:  StoredProcedure [Negocio].[delOfertaSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delOfertaSucursal] @Id int AS DELETE FROM OfertaSucursal WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delSesiones]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delSesiones] @Id int AS DELETE FROM Sesiones WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delSucursal] @Id int AS DELETE FROM Sucursal WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[delTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[delTienda] @Id int AS DELETE FROM Tienda WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Negocio].[guardarContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[guardarContacto]
	@Id			INT = 0,
	@Nombre		VARCHAR(100),
	@Telefono	VARCHAR(20),
	@Correo		VARCHAR(150),
	@IdTienda	INT = 1,
	@Msg		VARCHAR(255) OUTPUT
AS
BEGIN
	DECLARE @N VARCHAR(100) = NULL,
			@T VARCHAR(20) = NULL,
			@C VARCHAR(150) = NULL,
			@R INT = 1
				
	SELECT	@N = Nombre, @T = Telefono, @C = Correo
	FROM	Negocio.Contacto
	WHERE	(Nombre = @Nombre OR Correo = @Correo OR Telefono = @Telefono) AND IdTienda = @IdTienda

	IF @N = @Nombre
		SET @Msg = 'Id:0|Msg:EL NOMBRE DE CONTACTO YA EXISTE'
	ELSE IF @T =@Telefono
		SET @Msg = 'Id:0|Msg:EL TELÉFONO DE CONTACTO YA EXISTE'
	ELSE IF @C = @Correo
		SET @Msg = 'Id:0|Msg:EL CORREO ELECTRÓNICO DE CONTACTO YA EXISTE'
	ELSE
	BEGIN
		INSERT	INTO Negocio.Contacto(Nombre, Telefono, Correo, IdTienda)
		VALUES	(@Nombre, @Telefono, @Correo, @IdTienda)
		SET @Msg = 'Id:' + CAST(@@IDENTITY AS VARCHAR) + '|Msg:EL CONTACTO FUE REGISTRADO'
		SET @R = 0
	END

	RETURN @R
END;


GO
/****** Object:  StoredProcedure [Negocio].[hazLogin]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[hazLogin]
	@IdUsuario	VARCHAR(50),
	@IdPass		VARCHAR(50),
	@IdToken	VARCHAR(50)
AS
BEGIN
	DECLARE @Id INT = -1, @IdTienda INT = -1

	SELECT	@Id = A.Id
	FROM	Negocio.Administrador A
	WHERE	A.Usuario = @IdUsuario AND A.Password = @IdPass

	IF (ISNULL(@Id,-1)>0)
	BEGIN
		
		SELECT	TOP 1 @IdTienda = Id
		FROM	Negocio.Tienda T
		WHERE	IdAdministrador = @Id

		INSERT	INTO Negocio.Sesiones (IdUsuario, Token, HoraFecha)
		VALUES	(@Id, @IdToken, CURRENT_TIMESTAMP)
		SELECT	'Hecho' Resultado, @Id IdUsuario, @IdTienda IdTienda;
	END;
	ELSE
		SELECT 'Denegado' Resultado, 0 IdUsuario, 0 IdTienda;
END;
GO
/****** Object:  StoredProcedure [Negocio].[InsAdministrador]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsAdministrador] @Id INT, @Usuario VARCHAR(20), @Password VARCHAR(128), @Nombre VARCHAR(100), @Telefono VARCHAR(20), @Correo VARCHAR(100) AS BEGIN INSERT INTO Negocio.Administrador(Id, Usuario, Password, Nombre, Telefono, Correo)VALUES (@Id, @Usuario, @Password, @Nombre, @Telefono, @Correo) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsContacto] @IdTienda INT, @Id INT, @Correo VARCHAR(100), @Nombre VARCHAR(100), @Telefono VARCHAR(20) AS BEGIN INSERT INTO Negocio.Contacto(IdTienda, Id, Correo, Nombre, Telefono)VALUES (@IdTienda, @Id, @Correo, @Nombre, @Telefono) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsDescripcionTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsDescripcionTienda] @Contenido TEXT, @Id INT, @IdTienda INT, @IdSeccion INT, @Titulo VARCHAR(100) AS BEGIN INSERT INTO Negocio.DescripcionTienda(Contenido, Id, IdTienda, IdSeccion, Titulo)VALUES (@Contenido, @Id, @IdTienda, @IdSeccion, @Titulo) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsFoto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsFoto] @Id INT, @Orden INT, @IdTienda INT, @Foto VARCHAR(200) AS BEGIN INSERT INTO Negocio.Foto(Id, Orden, IdTienda, Foto)VALUES (@Id, @Orden, @IdTienda, @Foto) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsFotoOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsFotoOferta] @Orden INT, @IdOferta INT, @Id INT, @Foto VARCHAR(200) AS BEGIN INSERT INTO Negocio.FotoOferta(Orden, IdOferta, Id, Foto)VALUES (@Orden, @IdOferta, @Id, @Foto) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsHorario]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsHorario] @Dia TINYINT, @Id INT, @IdSucursal INT, @Entrada VARCHAR(20), @Salida VARCHAR(20) AS BEGIN INSERT INTO Negocio.Horario(Dia, Id, IdSucursal, Entrada, Salida)VALUES (@Dia, @Id, @IdSucursal, @Entrada, @Salida) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsOferta] @Descripcion TEXT, @Id INT, @IdTienda INT, @IdTipo INT, @Precio DECIMAL, @Unidad VARCHAR(20), @Nombre VARCHAR(100), @DescBreve VARCHAR(150) AS BEGIN INSERT INTO Negocio.Oferta(Descripcion, Id, IdTienda, IdTipo, Precio, Unidad, Nombre, DescBreve)VALUES (@Descripcion, @Id, @IdTienda, @IdTipo, @Precio, @Unidad, @Nombre, @DescBreve) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsOfertaSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsOfertaSucursal]
	@IdSucursal INT,
	@IdOferta INT,
	@Id INT,
	@Activa BIT
AS
BEGIN
	INSERT	INTO Negocio.OfertaSucursal(IdSucursal, IdOferta, Activa)
	VALUES	(@IdSucursal, @IdOferta, @Activa)
	SET		@Id = @@IDENTITY
	RETURN	@Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[InsSesiones]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsSesiones] @IdUsuario INT, @Id INT, @HoraFecha DATETIME, @Token VARCHAR(100) AS BEGIN INSERT INTO Negocio.Sesiones(IdUsuario, Id, HoraFecha, Token)VALUES (@IdUsuario, @Id, @HoraFecha, @Token) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsSucursal] @Id INT, @IdTienda INT, @IdTipo INT, @Latitud VARCHAR(20), @Longitud VARCHAR(20), @Direccion VARCHAR(200), @Telefono VARCHAR(20), @Correo VARCHAR(100) AS BEGIN INSERT INTO Negocio.Sucursal(Id, IdTienda, IdTipo, Latitud, Longitud, Direccion, Telefono, Correo)VALUES (@Id, @IdTienda, @IdTipo, @Latitud, @Longitud, @Direccion, @Telefono, @Correo) END;

GO
/****** Object:  StoredProcedure [Negocio].[InsTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[InsTienda] @Id INT, @IdAdministrador INT, @IdGiro INT, @Latitud VARCHAR(20), @Longitud VARCHAR(20), @RazonSocial VARCHAR(100), @Nombre VARCHAR(100), @Direccion VARCHAR(200), @Telefono VARCHAR(20), @Correo VARCHAR(100) AS BEGIN INSERT INTO Negocio.Tienda(Id, IdAdministrador, IdGiro, Latitud, Longitud, RazonSocial, Nombre, Direccion, Telefono, Correo)VALUES (@Id, @IdAdministrador, @IdGiro, @Latitud, @Longitud, @RazonSocial, @Nombre, @Direccion, @Telefono, @Correo) END;

GO
/****** Object:  StoredProcedure [Negocio].[listarContactos]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[listarContactos]
	@IdTienda	INT
AS
BEGIN
	SELECT	C.Id, C.IdTienda, C.Nombre, C.Telefono, C.Correo
	FROM	Negocio.Contacto C
	WHERE	C.IdTienda = @IdTienda
END;

GO
/****** Object:  StoredProcedure [Negocio].[listarSecciones]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[listarSecciones]
	@IdTienda INT
AS
BEGIN
	SELECT	DT.Id, DT.IdSeccion, DT.IdTienda, DT.Titulo, DT.Contenido,
			S.Nombre Seccion
	FROM	Negocio.DescripcionTienda DT
			JOIN Configuracion.Seccion S
	ON		DT.IdSeccion = S.Id
	WHERE	DT.IdTienda = @IdTienda
END;

GO
/****** Object:  StoredProcedure [Negocio].[listarSucursales]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[listarSucursales]
	@IdTienda	INT
AS
BEGIN
	SELECT	S.Id, S.Direccion, S.Telefono, S.Correo, S.Latitud, S.Longitud, S.IdTienda, S.IdTipo,
			T.Nombre Tipo, Status, S.Visible
	FROM	Negocio.Sucursal S
			JOIN Configuracion.Tipo T
	ON		S.IdTipo = T.Id
	WHERE	S.IdTienda = @IdTienda
END;

GO
/****** Object:  StoredProcedure [Negocio].[obtenerContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[obtenerContacto]
	@Id	INT
AS
BEGIN
	SELECT	C.Id, C.Nombre, C.Telefono, C.Correo, C.IdTienda
	FROM	Negocio.Contacto C
	WHERE	C.Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[obtenerDatosPropietario]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerDatosPropietario]
	@Id INT
AS
BEGIN
	SELECT	Id, Nombre, Telefono, Correo, Usuario
	FROM	Negocio.Administrador
	WHERE	Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[obtenerDatosSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Negocio].[obtenerDatosSucursal]
	@Id INT
AS
BEGIN
	SELECT	S.Id, S.Direccion, S.Telefono, S.Correo, S.Latitud, S.Longitud, S.IdTienda, S.IdTipo, S.Status,
			T.Nombre Tipo
	FROM	Negocio.Sucursal S (NOLOCK)
			JOIN Configuracion.Tipo T (NOLOCK)
	ON		S.IdTipo = T.Id
	WHERE	S.Id = @Id
END

GO
/****** Object:  StoredProcedure [Negocio].[ObtenerDatosTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[ObtenerDatosTienda]
	@Id	INT
AS
BEGIN
	SELECT	T.Id, T.Nombre, T.Direccion, T.Telefono, T.Correo, T.Latitud, T.Longitud, T.RazonSocial,
			T.IdGiro, G.Nombre Giro
	FROM	Negocio.Tienda T
			JOIN Configuracion.Giro G
	ON		T.IdGiro = G.Id
	WHERE	T.Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[obtenerDatosTiendaResumen]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerDatosTiendaResumen]
	@IdTienda INT
AS
SELECT	T.Id, RazonSocial AS Nombre, T.Direccion, T.Telefono, T.Correo, T.IdGiro,
		ISNULL(CASE H.Dia
			WHEN 1 THEN 'Lu'
			WHEN 2 THEN 'Ma'
			WHEN 3 THEN 'Mi'
			WHEN 4 THEN 'Ju'
			WHEN 5 THEN 'Vi'
			WHEN 6 THEN 'Sa'
			WHEN 7 THEN 'Do'
		END,'') Dia,
		ISNULL(H.Entrada + ' - ' + H.Salida, '') Horario
FROM	Negocio.Tienda T LEFT JOIN Negocio.Sucursal S
ON		T.Id = S.IdTienda AND S.IdTipo = 1 LEFT JOIN Negocio.Horario H
ON		S.Id = H.IdSucursal
WHERE	T.Id =@IdTienda
ORDER	BY T.Id, H.Dia
GO
/****** Object:  StoredProcedure [Negocio].[obtenerFotos]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerFotos]
	@IdTienda INT
AS
BEGIN
	SELECT	F.Id, F.Foto
	FROM	Negocio.Foto F
	WHERE	IdTienda = @IdTienda
	ORDER	BY Orden
END
GO
/****** Object:  StoredProcedure [Negocio].[obtenerNegocios]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerNegocios]
	@nombre VARCHAR(100) = '',
	@IdGiro INT = 0
AS
BEGIN
IF (@IdGiro != 0)
	SELECT	T.Id, T.RazonSocial, T.Direccion, T.Telefono, T.Correo, T.Latitud, T.Longitud, G.Nombre Giro
	FROM	Negocio.Tienda T JOIN Configuracion.Giro G
	ON		T.IdGiro = G.Id
	WHERE	T.RazonSocial LIKE '%' +@nombre+ '%' AND G.Id = @IdGiro
ELSE
	SELECT	T.Id, T.RazonSocial, T.Direccion, T.Telefono, T.Correo, T.Latitud, T.Longitud, G.Nombre Giro
	FROM	Negocio.Tienda T JOIN Configuracion.Giro G
	ON		T.IdGiro = G.Id
	WHERE	T.RazonSocial LIKE '%' +@nombre+ '%'
END
GO
/****** Object:  StoredProcedure [Negocio].[obtenerNovedades]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerNovedades]
	@IdTienda INT = 1
AS
BEGIN
	WITH vNovedades AS (
		SELECT	ROW_NUMBER() OVER(PARTITION BY T.Id, O.IdTienda ORDER BY O.Id DESC) Fila,
				O.Id, O.Nombre, O.DescBreve, O.Descripcion, O.Precio, O.Unidad, T.Nombre Tipo, FO.Foto
		FROM	Negocio.Oferta O JOIN Configuracion.Tipo T
		ON		O.IdTipo = T.Id LEFT JOIN Negocio.FotoOferta FO
		ON		O.Id = FO.IdOferta
		WHERE	O.IdTienda = @IdTienda AND O.Visible = 1
	)
	SELECT	Id, Nombre, DescBreve, Descripcion, Precio, Unidad, Tipo, Foto
	FROM	vNovedades
	WHERE	Fila < 4
END;

GO
/****** Object:  StoredProcedure [Negocio].[obtenerOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Negocio].[obtenerOferta]
	@ID	INT
AS
BEGIN
	SELECT	O.Id, O.Nombre, O.DescBreve, O.Descripcion, O.Precio, O.Unidad, O.IdTienda, O.IdTipo,
			T.Nombre Tipo, ISNULL(OS.IdSucursal,0) IdSucursal, ISNULL(OS.Id,0) IdOS
	FROM	Negocio.Oferta O
			LEFT JOIN Negocio.OfertaSucursal OS
	ON		O.Id = OS.IdOferta
			JOIN Configuracion.Tipo T
	ON		O.IdTipo = T.Id
	WHERE	O.Id = @ID
END;


GO
/****** Object:  StoredProcedure [Negocio].[obtenerOfertas]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerOfertas]
	@IdTienda INT,
	@IdTipo INT,
	@Visible BIT = NULL
AS
BEGIN
	SELECT	O.Id, O.Nombre, O.DescBreve, O.Descripcion, O.Precio, O.Unidad, T.Nombre Tipo, FO.Foto, O.Visible
	FROM	Negocio.Oferta O JOIN Configuracion.Tipo T
	ON		O.IdTipo = T.Id LEFT JOIN Negocio.FotoOferta FO
	ON		O.Id = FO.IdOferta
	WHERE	O.IdTienda = @IdTienda AND T.Id = @IdTipo AND O.Visible = ISNULL(@Visible,O.Visible)
END;


GO
/****** Object:  StoredProcedure [Negocio].[obtenerSeccion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[obtenerSeccion]
	@IdTienda INT,
	@IdSeccion INT
AS
SELECT	Id, Titulo, Contenido
FROM	Negocio.DescripcionTienda
WHERE	IdTienda = @IdTienda AND IdSeccion = @IdSeccion
GO
/****** Object:  StoredProcedure [Negocio].[obtenerSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[obtenerSucursal]
	@Id	INT
AS
BEGIN
	SELECT	S.Id, S.Direccion, S.Telefono, S.Correo, S.Latitud, S.Longitud, S.IdTienda, S.IdTipo,
			T.Nombre
	FROM	Negocio.Sucursal S
			JOIN Configuracion.Tipo T
	ON		S.IdTipo = T.Id
	WHERE	S.Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[selNegocioUsrPwd]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[selNegocioUsrPwd]
	@IdTienda INT
AS
BEGIN
	SELECT	T.Id, Correo Email, REPLACE(REPLACE(REPLACE(G.Nombre, ' ', ''),'ó','o'),'ñ','ni') + '@sernasis.com' [User], 'NegocioSernaSis#2018' Pwd
	FROM	Negocio.Tienda T JOIN Configuracion.Giro G
	ON		T.IdGiro = G.Id
	WHERE	T.id = @IdTienda
END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdAdministrador]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdAdministrador]
	@Id INT,
	@Usuario VARCHAR(20),
	@Password VARCHAR(128) = '',
	@Nombre VARCHAR(100),
	@Telefono VARCHAR(20),
	@Correo VARCHAR(100)
AS 
BEGIN
	IF @Password = '' OR @Password IS NULL
		SELECT	@Password = Password
		FROM	Negocio.Administrador
		WHERE	Usuario = @Usuario

	UPDATE	Negocio.Administrador
	SET		Usuario = @Usuario,
			Password = @Password,
			Nombre = @Nombre,
			Telefono = @Telefono,
			Correo = @Correo
	WHERE	Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdContacto] @IdTienda INT, @Id INT, @Correo VARCHAR(100), @Nombre VARCHAR(100), @Telefono VARCHAR(20) AS BEGIN UPDATE Negocio.Contacto SET IdTienda = @IdTienda, Correo = @Correo, Nombre = @Nombre, Telefono = @Telefono WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdDescripcionTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdDescripcionTienda]
	@Contenido TEXT,
	@Id INT,
	@IdTienda INT,
	@IdSeccion INT,
	@Titulo VARCHAR(100)
AS
BEGIN
	IF (@Id != 0)
	BEGIN
		UPDATE	Negocio.DescripcionTienda
		SET		Contenido = @Contenido, IdTienda = @IdTienda, IdSeccion = @IdSeccion, Titulo = @Titulo
		WHERE	Id = @Id
	END
	ELSE
	BEGIN
		IF NOT EXISTS(SELECT 1 FROM Negocio.DescripcionTienda WHERE IdTienda = @IdTienda AND IdSeccion = @IdSeccion)
			INSERT	INTO Negocio.DescripcionTienda(IdTienda, IdSeccion, Contenido, Titulo)
			VALUES	(@IdTienda, @IdSeccion, @Contenido, @Titulo)
		ELSE
			UPDATE	Negocio.DescripcionTienda
			SET		Contenido = @Contenido, Titulo = @Titulo
			WHERE	IdTienda = @IdTienda AND IdSeccion = @IdSeccion
	END
END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdFoto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdFoto] @Id INT, @Orden INT, @IdTienda INT, @Foto VARCHAR(200) AS BEGIN UPDATE Negocio.Foto SET Orden = @Orden, IdTienda = @IdTienda, Foto = @Foto WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdFotoOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdFotoOferta] @Orden INT, @IdOferta INT, @Id INT, @Foto VARCHAR(200) AS BEGIN UPDATE Negocio.FotoOferta SET Orden = @Orden, IdOferta = @IdOferta, Foto = @Foto WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdHorario]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdHorario] @Dia TINYINT, @Id INT, @IdSucursal INT, @Entrada VARCHAR(20), @Salida VARCHAR(20) AS BEGIN UPDATE Negocio.Horario SET Dia = @Dia, IdSucursal = @IdSucursal, Entrada = @Entrada, Salida = @Salida WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdOferta] @Descripcion TEXT, @Id INT, @IdTienda INT, @IdTipo INT, @Precio DECIMAL, @Unidad VARCHAR(20), @Nombre VARCHAR(100), @DescBreve VARCHAR(150) AS BEGIN UPDATE Negocio.Oferta SET Descripcion = @Descripcion, IdTienda = @IdTienda, IdTipo = @IdTipo, Precio = @Precio, Unidad = @Unidad, Nombre = @Nombre, DescBreve = @DescBreve WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdOfertaSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdOfertaSucursal] @IdSucursal INT, @IdOferta INT, @Id INT, @Activa BIT AS BEGIN UPDATE Negocio.OfertaSucursal SET IdSucursal = @IdSucursal, IdOferta = @IdOferta, Activa = @Activa WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[updOfertaVisible]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Negocio].[updOfertaVisible]
	@Id int,
	@rVisible bit output
as
begin
	declare @visible bit;
	select @visible = Visible ^ 1 from Negocio.Oferta where Id = @id
	update	Negocio.Oferta
	set		Visible = @Visible
	where	Id = @id

	select @rVisible = visible from Negocio.Oferta where Id = @id

	return @rVisible
end

GO
/****** Object:  StoredProcedure [Negocio].[UpdSeccionTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdSeccionTienda]
		@Id INT = NULL,
		@Titulo VARCHAR(255) = 'Introducción de prueba',
		@Contenido VARCHAR(MAX) = 'Esta es una prueba de carga desde el formulario.',
		@IdTienda INT = 1,
		@IdSeccion INT = 1
AS
BEGIN
	if (ISNULL(@Id,0)=0)
		update	Negocio.DescripcionTienda 
		set		Titulo = @Titulo, Contenido = @Contenido
		where	IdTienda = @IdTienda AND IdSeccion = @IdSeccion
	else
		update	Negocio.DescripcionTienda 
		set		Titulo = @Titulo, Contenido = @Contenido
		where	Id = @Id
END
GO
/****** Object:  StoredProcedure [Negocio].[UpdSesiones]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdSesiones] @IdUsuario INT, @Id INT, @HoraFecha DATETIME, @Token VARCHAR(100) AS BEGIN UPDATE Negocio.Sesiones SET IdUsuario = @IdUsuario, HoraFecha = @HoraFecha, Token = @Token WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Negocio].[UpdSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdSucursal] 
	@Id INT,
	@IdTienda INT,
	@IdTipo INT,
	@Status INT,
	@Latitud VARCHAR(20)='',
	@Longitud VARCHAR(20)='',
	@Direccion VARCHAR(200),
	@Telefono VARCHAR(20),
	@Correo VARCHAR(100)
AS
BEGIN
	UPDATE	Negocio.Sucursal
	SET		IdTienda = @IdTienda, IdTipo = @IdTipo, Latitud = @Latitud, Longitud = @Longitud, 
			Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo
	WHERE	Id = @Id
END;

GO
/****** Object:  StoredProcedure [Negocio].[updSucursalVisible]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Negocio].[updSucursalVisible]
	@Id INT,
	@rVisible BIT OUTPUT
AS
BEGIN
	declare @visible bit;
	select @visible = Visible ^ 1 from Negocio.Sucursal where Id = @id
	update	Negocio.Sucursal
	set		Visible = @Visible
	where	Id = @id

	select @rVisible = visible from Negocio.Sucursal where Id = @id

	return @rVisible
END

GO
/****** Object:  StoredProcedure [Negocio].[UpdTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Negocio].[UpdTienda] 
	@Id INT,
	@IdAdministrador INT = NULL,
	@IdGiro INT,
	@Latitud VARCHAR(20),
	@Longitud VARCHAR(20),
	@RazonSocial VARCHAR(100),
	@Nombre VARCHAR(100),
	@Direccion VARCHAR(200),
	@Telefono VARCHAR(20),
	@Correo VARCHAR(100)
AS
BEGIN
	SELECT	@IdAdministrador = ISNULL(@IdAdministrador, IdAdministrador)
	FROM	Negocio.Tienda
	WHERE	Id = @Id

	UPDATE	Negocio.Tienda 
	SET		IdAdministrador = @IdAdministrador, IdGiro = @IdGiro, Latitud = @Latitud,
			Longitud = @Longitud, RazonSocial = @RazonSocial, Nombre = @Nombre,
			Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo
	WHERE	Id = @Id
END;

GO
/****** Object:  StoredProcedure [Proyecto].[delActividad]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[delActividad] @Id int AS DELETE FROM Actividad WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Proyecto].[delCliente]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[delCliente] @Id int AS DELETE FROM Cliente WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Proyecto].[delContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[delContacto] @Id int AS DELETE FROM Contacto WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Proyecto].[delProyecto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[delProyecto] @Id int AS DELETE FROM Proyecto WHERE Id = @Id

GO
/****** Object:  StoredProcedure [Proyecto].[InsActividad]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[InsActividad] @Inicio DATE, @Fin DATE, @Orden TINYINT, @Sprint TINYINT, @IdPrincipal INT, @IdProyecto INT, @IdStatus INT, @Id INT, @Tiempo INT, @Nombre VARCHAR(200), @Descripcion VARCHAR(MAX) AS BEGIN INSERT INTO Proyecto.Actividad(Inicio, Fin, Orden, Sprint, IdPrincipal, IdProyecto, IdStatus, Id, Tiempo, Nombre, Descripcion)VALUES (@Inicio, @Fin, @Orden, @Sprint, @IdPrincipal, @IdProyecto, @IdStatus, @Id, @Tiempo, @Nombre, @Descripcion) END;

GO
/****** Object:  StoredProcedure [Proyecto].[InsCliente]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[InsCliente] @Id INT, @Nombre VARCHAR(100), @Correo VARCHAR(100), @Telefono VARCHAR(20), @Direccion VARCHAR(200), @Ciudad VARCHAR(100) AS BEGIN INSERT INTO Proyecto.Cliente(Id, Nombre, Correo, Telefono, Direccion, Ciudad)VALUES (@Id, @Nombre, @Correo, @Telefono, @Direccion, @Ciudad) END;

GO
/****** Object:  StoredProcedure [Proyecto].[InsContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[InsContacto] @Id INT, @IdCliente INT, @EsPrincipal BIT, @Nombre VARCHAR(100), @Telefono VARCHAR(20), @Correo VARCHAR(100) AS BEGIN INSERT INTO Proyecto.Contacto(Id, IdCliente, EsPrincipal, Nombre, Telefono, Correo)VALUES (@Id, @IdCliente, @EsPrincipal, @Nombre, @Telefono, @Correo) END;

GO
/****** Object:  StoredProcedure [Proyecto].[InsProyecto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[InsProyecto] @Inicio DATE, @Fin DATE, @Id INT, @IdCliente INT, @IdStatus INT, @IdPlataforma INT, @Nombre VARCHAR(150), @Descripcion VARCHAR(MAX) AS BEGIN INSERT INTO Proyecto.Proyecto(Inicio, Fin, Id, IdCliente, IdStatus, IdPlataforma, Nombre, Descripcion)VALUES (@Inicio, @Fin, @Id, @IdCliente, @IdStatus, @IdPlataforma, @Nombre, @Descripcion) END;

GO
/****** Object:  StoredProcedure [Proyecto].[selStatusActual]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE DATABASE Proyectos;
--USE Proyectos;
--GO
--CREATE SCHEMA Proyecto;
--GO
--CREATE SCHEMA Configuracion;
--GO
--CREATE SCHEMA Seguridad;
--GO

--CREATE TABLE Configuracion.TipoStatus(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(100) NOT NULL
--);

--CREATE TABLE Configuracion.Status(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(100) NOT NULL,
--	IdTipoStatus INT NOT NULL,
--	CONSTRAINT FK_TipoStatus_Status FOREIGN KEY(IdTipoStatus) REFERENCES Configuracion.TipoStatus(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
--);

--CREATE TABLE Configuracion.Plataforma(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(100) NOT NULL,
--	Descripcion VARCHAR(MAX) NOT NULL
--);

--CREATE TABLE Proyecto.Cliente(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(100) NOT NULL,
--	Correo VARCHAR(100) NOT NULL,
--	Telefono VARCHAR(20),
--	Direccion VARCHAR(200),
--	Ciudad VARCHAR(100) NOT NULL
--);

--CREATE TABLE Proyecto.Contacto(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(100) NOT NULL,
--	Correco VARCHAR(100) NOT NULL,
--	Telefono VARCHAR(20),
--	IdCliente INT NOT NULL,
--	EsPrincipal BIT NOT NULL DEFAULT 0,
--	CONSTRAINT FK_Cliente_Contacto FOREIGN KEY(IdCliente) REFERENCES Proyecto.Cliente(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
--);

--CREATE TABLE Proyecto.Proyecto(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(150) NOT  NULL,
--	Inicio DATE NOT NULL,
--	Descripcion VARCHAR(MAX) NOT NULL,
--	IdCliente INT NOT NULL,
--	IdStatus INT NOT NULL,
--	Fin DATE NOT NULL,
--IdPlataforma INT NOT NULL,
--	CONSTRAINT FK_Cliente_Proyecto FOREIGN KEY (IdCliente) REFERENCES Proyecto.Cliente(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
--	CONSTRAINT FK_Status_Proyecto FOREIGN KEY (IdStatus) REFERENCES Configuracion.Status(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
--CONSTRAINT FK_Plataforma_Proyecto FOREIGN KEY(IdPlataforma) REFERENCES Configuracion.Plataforma(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
--);

--CREATE TABLE Proyecto.Actividad(
--	Id INT IDENTITY PRIMARY KEY,
--	Nombre VARCHAR(200) NOT NULL,
--	Descripcion VARCHAR(MAX) NOT NULL,
--	Tiempo INT NOT NULL DEFAULT 1,
--	IdPrincipal INT NOT NULL DEFAULT 1,
--	IdProyecto INT NOT NULL,
--	IdStatus INT NOT NULL,
--	Orden TINYINT NOT NULL,
--	Sprint TINYINT NOT NULL,
--	Inicio DATE NOT NULL,
--	Fin DATE NOT NULL,
--	CONSTRAINT FK_Proyecto_Actividad FOREIGN KEY (IdProyecto) REFERENCES Proyecto.Proyecto(Id) ON UPDATE NO ACTION ON DELETE NO ACTION,
--	CONSTRAINT FK_Status_Actividad FOREIGN KEY (IdStatus) REFERENCES Configuracion.Status(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
--);
--GO

CREATE PROCEDURE [Proyecto].[selStatusActual]
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
GO
/****** Object:  StoredProcedure [Proyecto].[UpdActividad]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[UpdActividad] @Inicio DATE, @Fin DATE, @Orden TINYINT, @Sprint TINYINT, @IdPrincipal INT, @IdProyecto INT, @IdStatus INT, @Id INT, @Tiempo INT, @Nombre VARCHAR(200), @Descripcion VARCHAR(MAX) AS BEGIN UPDATE Proyecto.Actividad SET Inicio = @Inicio, Fin = @Fin, Orden = @Orden, Sprint = @Sprint, IdPrincipal = @IdPrincipal, IdProyecto = @IdProyecto, IdStatus = @IdStatus, Tiempo = @Tiempo, Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Proyecto].[UpdCliente]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[UpdCliente] @Id INT, @Nombre VARCHAR(100), @Correo VARCHAR(100), @Telefono VARCHAR(20), @Direccion VARCHAR(200), @Ciudad VARCHAR(100) AS BEGIN UPDATE Proyecto.Cliente SET Nombre = @Nombre, Correo = @Correo, Telefono = @Telefono, Direccion = @Direccion, Ciudad = @Ciudad WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Proyecto].[UpdContacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[UpdContacto] @Id INT, @IdCliente INT, @EsPrincipal BIT, @Nombre VARCHAR(100), @Telefono VARCHAR(20), @Correo VARCHAR(100) AS BEGIN UPDATE Proyecto.Contacto SET IdCliente = @IdCliente, EsPrincipal = @EsPrincipal, Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE Id = @Id END;

GO
/****** Object:  StoredProcedure [Proyecto].[UpdProyecto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Proyecto].[UpdProyecto] @Inicio DATE, @Fin DATE, @Id INT, @IdCliente INT, @IdStatus INT, @IdPlataforma INT, @Nombre VARCHAR(150), @Descripcion VARCHAR(MAX) AS BEGIN UPDATE Proyecto.Proyecto SET Inicio = @Inicio, Fin = @Fin, IdCliente = @IdCliente, IdStatus = @IdStatus, IdPlataforma = @IdPlataforma, Nombre = @Nombre, Descripcion = @Descripcion WHERE Id = @Id END;

GO
/****** Object:  UserDefinedFunction [Negocio].[verificarToken]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Efraín Serna Gracia
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [Negocio].[verificarToken] 
(
	-- Add the parameters for the function here
	@Usuario VARCHAR(50),
		@token	VARCHAR(100)
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Resultado bit
	DECLARE	@HF	DATETIME

	SELECT	TOP 1 @HF = L.HoraFecha
	FROM	Negocio.Administrador A
			LEFT JOIN Negocio.Sesiones L
	ON		A.Id = L.IdUsuario
	WHERE	A.Usuario = @Usuario AND L.Token = @Token
	ORDER	BY L.HoraFecha DESC

	IF GETDATE() BETWEEN ISNULL(@HF,CAST('01-01-2000' AS DATETIME)) AND DATEADD(DAY,1,ISNULL(@HF,CAST('01-01-2000 00:00:00' AS DATETIME)))
		SET @Resultado = 1
	ELSE
		SET @Resultado = 0
	-- Return the result of the function
	RETURN @Resultado

END

GO
/****** Object:  Table [Configuracion].[Clasificacion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Clasificacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Giro]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Giro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Plataforma]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Plataforma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Seccion]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Seccion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Status]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdTipoStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Tipo]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Tipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdClasificacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[TipoStatus]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[TipoStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Administrador]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Administrador](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Password] [varchar](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Contacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Contacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[IdTienda] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[DescripcionTienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[DescripcionTienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NULL,
	[Contenido] [text] NOT NULL,
	[IdTienda] [int] NOT NULL,
	[IdSeccion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Foto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Foto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[Orden] [int] NOT NULL,
	[IdTienda] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[FotoOferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[FotoOferta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[Orden] [int] NOT NULL,
	[IdOferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Horario]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Horario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dia] [tinyint] NULL,
	[Entrada] [varchar](20) NOT NULL,
	[Salida] [varchar](20) NOT NULL,
	[IdSucursal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Oferta]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Oferta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[DescBreve] [varchar](150) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Unidad] [varchar](20) NOT NULL,
	[IdTienda] [int] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Visible] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[OfertaSucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Negocio].[OfertaSucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activa] [bit] NULL,
	[IdSucursal] [int] NOT NULL,
	[IdOferta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Negocio].[Sesiones]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Sesiones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Token] [varchar](100) NOT NULL,
	[HoraFecha] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Sucursal]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Sucursal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Latitud] [varchar](20) NOT NULL,
	[Longitud] [varchar](20) NOT NULL,
	[IdTienda] [int] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Status] [int] NULL,
	[Visible] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Negocio].[Tienda]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Negocio].[Tienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Latitud] [varchar](20) NOT NULL,
	[Longitud] [varchar](20) NOT NULL,
	[RazonSocial] [varchar](100) NOT NULL,
	[IdAdministrador] [int] NOT NULL,
	[IdGiro] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Proyecto].[Actividad]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Proyecto].[Actividad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[Tiempo] [int] NOT NULL,
	[IdPrincipal] [int] NOT NULL,
	[IdProyecto] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[Orden] [tinyint] NOT NULL,
	[Sprint] [tinyint] NOT NULL,
	[Inicio] [date] NOT NULL,
	[Fin] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Proyecto].[Cliente]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Proyecto].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NULL,
	[Direccion] [varchar](200) NULL,
	[Ciudad] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Proyecto].[Contacto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Proyecto].[Contacto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Telefono] [varchar](20) NULL,
	[IdCliente] [int] NOT NULL,
	[EsPrincipal] [bit] NOT NULL,
	[Correo] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Proyecto].[Proyecto]    Script Date: 11/01/2019 02:40:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Proyecto].[Proyecto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
	[Inicio] [date] NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[Fin] [date] NOT NULL,
	[IdPlataforma] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [Negocio].[Oferta] ADD  DEFAULT ((1)) FOR [Visible]
GO
ALTER TABLE [Proyecto].[Actividad] ADD  DEFAULT ((1)) FOR [Tiempo]
GO
ALTER TABLE [Proyecto].[Actividad] ADD  DEFAULT ((1)) FOR [IdPrincipal]
GO
ALTER TABLE [Proyecto].[Contacto] ADD  DEFAULT ((0)) FOR [EsPrincipal]
GO
ALTER TABLE [Configuracion].[Status]  WITH CHECK ADD  CONSTRAINT [FK_TipoStatus_Status] FOREIGN KEY([IdTipoStatus])
REFERENCES [Configuracion].[TipoStatus] ([Id])
GO
ALTER TABLE [Configuracion].[Status] CHECK CONSTRAINT [FK_TipoStatus_Status]
GO
ALTER TABLE [Configuracion].[Tipo]  WITH CHECK ADD  CONSTRAINT [fk_Clasificacion_Tipo] FOREIGN KEY([IdClasificacion])
REFERENCES [Configuracion].[Clasificacion] ([Id])
GO
ALTER TABLE [Configuracion].[Tipo] CHECK CONSTRAINT [fk_Clasificacion_Tipo]
GO
ALTER TABLE [Negocio].[Contacto]  WITH CHECK ADD  CONSTRAINT [fk_Tienda_Contacto] FOREIGN KEY([IdTienda])
REFERENCES [Negocio].[Tienda] ([Id])
GO
ALTER TABLE [Negocio].[Contacto] CHECK CONSTRAINT [fk_Tienda_Contacto]
GO
ALTER TABLE [Negocio].[DescripcionTienda]  WITH CHECK ADD  CONSTRAINT [fk_Seccion_DescripcionTienda] FOREIGN KEY([IdSeccion])
REFERENCES [Configuracion].[Seccion] ([Id])
GO
ALTER TABLE [Negocio].[DescripcionTienda] CHECK CONSTRAINT [fk_Seccion_DescripcionTienda]
GO
ALTER TABLE [Negocio].[DescripcionTienda]  WITH CHECK ADD  CONSTRAINT [fk_Tienda_DescripcionTienda] FOREIGN KEY([IdTienda])
REFERENCES [Negocio].[Tienda] ([Id])
GO
ALTER TABLE [Negocio].[DescripcionTienda] CHECK CONSTRAINT [fk_Tienda_DescripcionTienda]
GO
ALTER TABLE [Negocio].[Foto]  WITH CHECK ADD  CONSTRAINT [fk_Tienda_Foto] FOREIGN KEY([IdTienda])
REFERENCES [Negocio].[Tienda] ([Id])
GO
ALTER TABLE [Negocio].[Foto] CHECK CONSTRAINT [fk_Tienda_Foto]
GO
ALTER TABLE [Negocio].[FotoOferta]  WITH CHECK ADD  CONSTRAINT [fk_Oferta_fotoOferta] FOREIGN KEY([IdOferta])
REFERENCES [Negocio].[Oferta] ([Id])
GO
ALTER TABLE [Negocio].[FotoOferta] CHECK CONSTRAINT [fk_Oferta_fotoOferta]
GO
ALTER TABLE [Negocio].[Horario]  WITH CHECK ADD  CONSTRAINT [fk_Sucursal_Horario] FOREIGN KEY([IdSucursal])
REFERENCES [Negocio].[Sucursal] ([Id])
GO
ALTER TABLE [Negocio].[Horario] CHECK CONSTRAINT [fk_Sucursal_Horario]
GO
ALTER TABLE [Negocio].[Oferta]  WITH CHECK ADD  CONSTRAINT [fk_Tienda_Oferta] FOREIGN KEY([IdTienda])
REFERENCES [Negocio].[Tienda] ([Id])
GO
ALTER TABLE [Negocio].[Oferta] CHECK CONSTRAINT [fk_Tienda_Oferta]
GO
ALTER TABLE [Negocio].[Oferta]  WITH CHECK ADD  CONSTRAINT [fk_Tipo_Oferta] FOREIGN KEY([IdTipo])
REFERENCES [Configuracion].[Tipo] ([Id])
GO
ALTER TABLE [Negocio].[Oferta] CHECK CONSTRAINT [fk_Tipo_Oferta]
GO
ALTER TABLE [Negocio].[OfertaSucursal]  WITH CHECK ADD  CONSTRAINT [fk_Oferta_OfertaSucursal] FOREIGN KEY([IdOferta])
REFERENCES [Negocio].[Oferta] ([Id])
GO
ALTER TABLE [Negocio].[OfertaSucursal] CHECK CONSTRAINT [fk_Oferta_OfertaSucursal]
GO
ALTER TABLE [Negocio].[OfertaSucursal]  WITH CHECK ADD  CONSTRAINT [fk_Sucursal_OfertaSucursal] FOREIGN KEY([IdSucursal])
REFERENCES [Negocio].[Sucursal] ([Id])
GO
ALTER TABLE [Negocio].[OfertaSucursal] CHECK CONSTRAINT [fk_Sucursal_OfertaSucursal]
GO
ALTER TABLE [Negocio].[Sucursal]  WITH CHECK ADD  CONSTRAINT [fk_Tienda_Sucursal] FOREIGN KEY([IdTienda])
REFERENCES [Negocio].[Tienda] ([Id])
GO
ALTER TABLE [Negocio].[Sucursal] CHECK CONSTRAINT [fk_Tienda_Sucursal]
GO
ALTER TABLE [Negocio].[Tienda]  WITH CHECK ADD  CONSTRAINT [fk_Administrador_Tienda] FOREIGN KEY([IdAdministrador])
REFERENCES [Negocio].[Administrador] ([Id])
GO
ALTER TABLE [Negocio].[Tienda] CHECK CONSTRAINT [fk_Administrador_Tienda]
GO
ALTER TABLE [Negocio].[Tienda]  WITH CHECK ADD  CONSTRAINT [fk_Giro_Tienda] FOREIGN KEY([IdGiro])
REFERENCES [Configuracion].[Giro] ([Id])
GO
ALTER TABLE [Negocio].[Tienda] CHECK CONSTRAINT [fk_Giro_Tienda]
GO
ALTER TABLE [Proyecto].[Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Proyecto_Actividad] FOREIGN KEY([IdProyecto])
REFERENCES [Proyecto].[Proyecto] ([Id])
GO
ALTER TABLE [Proyecto].[Actividad] CHECK CONSTRAINT [FK_Proyecto_Actividad]
GO
ALTER TABLE [Proyecto].[Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Status_Actividad] FOREIGN KEY([IdStatus])
REFERENCES [Configuracion].[Status] ([Id])
GO
ALTER TABLE [Proyecto].[Actividad] CHECK CONSTRAINT [FK_Status_Actividad]
GO
ALTER TABLE [Proyecto].[Contacto]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Contacto] FOREIGN KEY([IdCliente])
REFERENCES [Proyecto].[Cliente] ([Id])
GO
ALTER TABLE [Proyecto].[Contacto] CHECK CONSTRAINT [FK_Cliente_Contacto]
GO
ALTER TABLE [Proyecto].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Proyecto] FOREIGN KEY([IdCliente])
REFERENCES [Proyecto].[Cliente] ([Id])
GO
ALTER TABLE [Proyecto].[Proyecto] CHECK CONSTRAINT [FK_Cliente_Proyecto]
GO
ALTER TABLE [Proyecto].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Plataforma_Proyecto] FOREIGN KEY([IdPlataforma])
REFERENCES [Configuracion].[Plataforma] ([Id])
GO
ALTER TABLE [Proyecto].[Proyecto] CHECK CONSTRAINT [FK_Plataforma_Proyecto]
GO
ALTER TABLE [Proyecto].[Proyecto]  WITH CHECK ADD  CONSTRAINT [FK_Status_Proyecto] FOREIGN KEY([IdStatus])
REFERENCES [Configuracion].[Status] ([Id])
GO
ALTER TABLE [Proyecto].[Proyecto] CHECK CONSTRAINT [FK_Status_Proyecto]
GO
USE [master]
GO
ALTER DATABASE [Proyectos] SET  READ_WRITE 
GO
