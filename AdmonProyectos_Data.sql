USE Proyectos;
GO

SET		IDENTITY_INSERT Configuracion.Plataforma ON;
INSERT	INTO Configuracion.Plataforma(Id, Nombre, Descripcion)
VALUES	(1, 'Prolancer', 'Profesional en línea'),
		(2, 'Serna Sistemas', 'Sitio propio'),
		(3, 'Workana', 'Free lancers'),
		(4, 'Freelancer', 'Free lancers');
SET		IDENTITY_INSERT Configuracion.Plataforma OFF;
GO

SET IDENTITY_INSERT Configuracion.TipoStatus ON;
INSERT	INTO Configuracion.TipoStatus(Id, Nombre)
VALUES	(1, 'De Persona'),
		(2, 'De Proyecto'),
		(3, 'De Actividad');
SET IDENTITY_INSERT Configuracion.TipoStatus OFF;
GO

SET IDENTITY_INSERT Configuracion.Status ON;
INSERT INTO Configuracion.Status(Id, IdTipoStatus, Nombre)
VALUES ( 1, 1, 'Activo'),
       ( 2, 1, 'Inactivo'),
	   ( 3, 2, 'Iniciado'),
	   ( 4, 2, 'En proceso'),
	   ( 5, 2, 'Finalizado'),
	   ( 6, 2, 'Cancelado'),
	   ( 7, 3, 'No iniciada'),
	   ( 8, 3, 'Iniciada'),
	   ( 9, 3, 'En proceso'),
	   (10, 3, 'En revisión con cliente'),
	   (11, 3, 'Finalizada');
SET IDENTITY_INSERT Configuracion.Status OFF;
GO

SET IDENTITY_INSERT Proyecto.Cliente ON;
INSERT INTO Proyecto.Cliente (Id, Nombre, Correo, Telefono, Direccion, Ciudad)
VALUES (1, 'AcMax de México', 'ti@acmax.mx','222-891-8484','Calle Rosas 134','Puebla'),
       (2, 'Centro Universitario Hispana', 'sin@correo.com','249-123-4567', 'Chalchicomula de Sesma', 'Chalchicomula de Sesma'),
	   (3, 'Serna Sistemas', 'efrain_serna@hotmail.com','22-25-29-9764','67 oriente 632','Puebla');
SET IDENTITY_INSERT Proyecto.Cliente OFF;
GO

SET IDENTITY_INSERT Proyecto.Contacto ON;
INSERT	INTO Proyecto.Contacto(Id, Nombre, Correo, Telefono, IdCliente, EsPrincipal)
VALUES	(1, 'Verónica Hernández', 'ti@acmax.mx','222-891-8484',1,1),
		(2, 'Enrique Fragoso', 'sin@correo.com', '249-123-4567', 2, 1),
		(3, 'Efraín Serna', 'efrain_serna@hotmail.com', '22-25-29-9764', 2, 1);
SET IDENTITY_INSERT Proyecto.Contacto OFF;
GO

SET IDENTITY_INSERT Proyecto.Proyecto ON;
INSERT INTO Proyecto.Proyecto (Id, Nombre, Inicio, Descripcion, IdCliente, IdStatus, Fin, IdPlataforma)
VALUES (1, 'Incorporación TC/TD', '2017-12-16', 'Incorporación de pasarela para pagos con TC/TD', 1, 4, '2017-12-23', 2),
       (2, 'Ticket Hispana', '2018-03-01', 'Redonfiguración de tickets para caja de sistema escolar', 3, 3, '2018-05-15', 2),
	   (3, 'Seguimientos', '2018-05-01', 'Sistema de registro y consulta para seguimiento de proyectos', 3, 3, '2018-05-20', 2),
	   (4, 'Sincronizador de precios', '2018-03-16', 'Sincrnizador de precios de tienda on-line', 1, 4, '2018-04-01', 2);
SET IDENTITY_INSERT Proyecto.Proyecto OFF;
GO

SET IDENTITY_INSERT Proyecto.Actividad ON;
INSERT INTO Proyecto.Actividad(Id, Nombre, Descripcion, Tiempo, IdPrincipal, IdProyecto, IdStatus, Orden, Sprint, Inicio, Fin)
VALUES (1, 'Ajuste de UI', 'Ajuste visual en presentación de resultados', 2, 1, 4, 11, 1, 2, '2018-04-16', '2018-04-16');
SET IDENTITY_INSERT Proyecto.Actividad OFF;
GO

SELECT 'Plataforma', COUNT(*) FROM Configuracion.Plataforma
UNION
SELECT 'Tipo de Status', COUNT(*) FROM Configuracion.TipoStatus
UNION
SELECT 'Status', COUNT(*) FROM Configuracion.Status
UNION
SELECT 'Clientes', COUNT(*) FROM Proyecto.Cliente
UNION
SELECT 'Contactos', COUNT(*) FROM Proyecto.Contacto
UNION
SELECT 'Proyectos', COUNT(*) FROM Proyecto.Proyecto
UNION
SELECT 'Actividades', COUNT(*) FROM Proyecto.Actividad;