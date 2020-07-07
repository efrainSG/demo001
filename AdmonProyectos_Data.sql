USE Proyectos;
GO

SET IDENTITY_INSERT Configuracion.Plataforma ON;
INSERT INTO Configuracion.Plataforma(Id, Nombre)
VALUES (1, 'Prolancer'),
       (2, 'Serna Sistemas'),
	   (3, 'Workana');
SET IDENTITY_INSERT Configuracion.Plataforma OFF;
GO

SET IDENTITY_INSERT Configuracion.Status ON;
INSERT INTO Configuracion.Status(Id, Nombre)
VALUES (1, 'Por Hacer'),
       (2, 'En Proceso'),
	   (3, 'En Pruebas'),
	   (4, 'Concluido'),
	   (5, 'Cancelado');
SET IDENTITY_INSERT Configuracion.Status OFF;
GO

SET IDENTITY_INSERT Proyecto.Cliente ON;
INSERT INTO Proyecto.Cliente (Id, Nombre, Contacto)
VALUES (1, 'AcMax', 'Verónica Hernández'),
       (2, 'Centro Universitario Hispana', 'Enrique Fragoso'),
	   (3, 'Serna Sistemas', 'Efraín Serna');
SET IDENTITY_INSERT Proyecto.Cliente OFF;
GO

SET IDENTITY_INSERT Proyecto.Proyecto ON;
INSERT INTO Proyecto.Proyecto (Id, Nombre, IdCliente, Inicio, Termino, Descripcion, IdPlataformaContacto)
VALUES (1, 'Sincronizador AcMax', 1, '2018-03-16', '2018-04-20', 'Sincronizador de tablas de productos', 3),
       (2, 'Ticket Hispana', 2, '2018-03-01', '2018-04-20', 'Redonfiguración de tickets para caja de sistema escolar', 3),
	   (3, 'Historias Clínicas', 3, '2018-01-01', '2018-01-01', 'Sistema de Historias Clínicas', 3),
	   (4, 'CoTeDiv 2.0', 3, '2018-01-01', '2018-01-01', 'Mejora al proyecto de maestría', 3),
	   (5, 'Plataforma Hotelera', 3, '2018-01-01', '2018-01-01', 'Sistema Hotelero', 3),
	   (6, 'Plataforma multinegocios', 3, '2018-01-01', '2018-01-01', 'Sistema de Negocios y tiendas', 3);
SET IDENTITY_INSERT Proyecto.Proyecto OFF;
GO

SET IDENTITY_INSERT Proyecto.Actividad ON;
INSERT INTO Proyecto.Actividad(Id, FolioProyecto, Descripcion, Sprint, FechaInicio, IdStatus)
VALUES (1, 1, 'Ajuste visual en presentación de resultados', 2, '2018-04-16', 1),
       (2, 2, 'Creación de RDLC para ticket', 1, '2018-04-16', 1),
	   (3, 3, 'Proceso de análisis', 0, '2018-04-16', 1);
SET IDENTITY_INSERT Proyecto.Actividad OFF;
GO
