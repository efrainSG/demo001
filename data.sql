set identity_insert super.tipostatus on;
insert into super.tipostatus(id, nombre)
values (1, 'administrativo'),
       (2, 'negocio');
set identity_insert super.tipostatus off;

set identity_insert super.tipooferta on;
insert into super.tipooferta(id, nombre)
values (1, 'servicio'),
       (2, 'producto'),
	   (3, 'descargable');
set identity_insert super.tipooferta off;

set identity_insert super.tipolocalidad on;
insert into super.tipolocalidad(id, nombre)
values (1, 'país'),
       (2, 'estado'),
	   (3, 'ciudad'),
	   (4, 'colonia');
set identity_insert super.tipolocalidad off;

set identity_insert super.tipoubicacion on;
insert into super.tipoubicacion(id, nombre)
values (1, 'unica'),
       (2, 'matriz'),
	   (3, 'sucursal'),
	   (4, 'filial');
set identity_insert super.tipoubicacion off;

set identity_insert catalogo.status on;
insert into catalogo.status(id, nombre, idtipostatus)
values (1, 'activo', 1),
       (2, 'inactivo', 1),
	   (3, 'activo', 2),
	   (4, 'inactivo', 2);
set identity_insert catalogo.status off;

set identity_insert catalogo.plantilla on;
insert into catalogo.plantilla(id, nombre, idstatus)
values (1, 'básica', 1),
       (2, 'azul', 1),
	   (3, 'ecologica', 1),
	   (4, 'artesanal', 1),
	   (5, 'tecnologia', 1);
set identity_insert catalogo.plantilla off;

set identity_insert catalogo.seccion on;
insert into catalogo.seccion(id, nombre, idstatus)
values (1, 'titulo', 1),
       (2, 'subtitulo', 1),
       (3, 'columna izquerda', 1),
	   (4, 'columna central', 1),
	   (5, 'columna derecha', 1),
	   (6, 'pie izquierdo', 1),
	   (7, 'pie central', 1),
	   (8, 'pie derecho', 1),
	   (9, 'lateral izquierda', 1),
	   (10, 'lateral derecha', 1),
	   (11, 'superior', 1),
	   (12, 'inferior', 1);
set identity_insert catalogo.seccion off;

