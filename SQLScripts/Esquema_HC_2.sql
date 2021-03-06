USE [master]
GO
/****** Object:  View [Configuracion].[vAnticonceptivos]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Configuracion].[vAnticonceptivos]
AS
select C.Id, C.Nombre, TC.Nombre Catalogo
from Configuracion.Catalogo C (nolock)
join Configuracion.TipoCatalogo TC (nolock)
on TC.Id = C.IdTipo
where TC.Nombre = 'Anticonceptivo'
GO
/****** Object:  View [Configuracion].[vFamiliares]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Configuracion].[vFamiliares]
AS
select C.Id, C.Nombre, TC.Nombre Catalogo
from Configuracion.Catalogo C (nolock)
join Configuracion.TipoCatalogo TC (nolock)
on TC.Id = C.IdTipo
where TC.Nombre = 'Familiar'
GO
/****** Object:  View [Configuracion].[vSistemas]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Configuracion].[vSistemas]
AS
select C.Id, C.Nombre, TC.Nombre Catalogo
from Configuracion.Catalogo C (nolock)
join Configuracion.TipoCatalogo TC (nolock)
on TC.Id = C.IdTipo
where TC.Nombre = 'Sistema'
GO
/****** Object:  View [Configuracion].[vTipoTelefono]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Configuracion].[vTipoTelefono]
AS
select C.Id, C.Nombre, TC.Nombre Catalogo
from Configuracion.Catalogo C (nolock)
join Configuracion.TipoCatalogo TC (nolock)
on TC.Id = C.IdTipo
where TC.Nombre = 'TipoTelefono'
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
