USE [master]
GO
/****** Object:  Database [HistoriaClinica]    Script Date: 11/01/2019 02:41:22 p. m. ******/
CREATE DATABASE [HistoriaClinica]
GO
ALTER DATABASE [HistoriaClinica] SET COMPATIBILITY_LEVEL = 110
GO

USE [HistoriaClinica]
GO

/****** Object:  Schema [Administracion]    Script Date: 11/01/2019 02:41:22 p. m. ******/
CREATE SCHEMA [Administracion]
GO
/****** Object:  Schema [Clinica]    Script Date: 11/01/2019 02:41:22 p. m. ******/
CREATE SCHEMA [Clinica]
GO
/****** Object:  Schema [Configuracion]    Script Date: 11/01/2019 02:41:22 p. m. ******/
CREATE SCHEMA [Configuracion]
GO
/****** Object:  StoredProcedure [Administracion].[loginMedico]    Script Date: 11/01/2019 02:41:22 p. m. ******/

/****** Object:  Table [Administracion].[Medico]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Administracion].[Medico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasenia] [varbinary](128) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Administracion].[Persona]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Administracion].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSexo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[IdTipoSangre] [int] NOT NULL,
	[Rh] [char](1) NULL,
	[FechaNacimiento] [date] NOT NULL,
	[IdLugarNacimiento] [int] NOT NULL,
	[CiudadNacimiento] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Administracion].[Telefonos]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Administracion].[Telefonos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdTipoTelefono] [int] NOT NULL,
	[NumeroTelefono] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[Adicciones]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[Adicciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[Adiccion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[Alergias]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[Alergias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[Alergia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[AntecedentesGinecobstetricios]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clinica].[AntecedentesGinecobstetricios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdAnticonceptivo] [int] NOT NULL,
	[Menarca] [date] NOT NULL,
	[FUR] [date] NOT NULL,
	[G] [tinyint] NOT NULL,
	[P] [tinyint] NOT NULL,
	[C] [tinyint] NOT NULL,
	[A] [tinyint] NOT NULL,
	[Papanicolaou] [date] NOT NULL,
	[Mastografia] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Clinica].[AntecedentesHereditarios]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[AntecedentesHereditarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdFamiliar] [int] NOT NULL,
	[Padecimiento] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[AntecedentesPatologicos]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[AntecedentesPatologicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[Enfermedad] [varchar](100) NOT NULL,
	[FechaInicio] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[ExploracionFisica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[ExploracionFisica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoriaClinica] [int] NOT NULL,
	[TA] [varchar](20) NULL,
	[Pulso] [tinyint] NOT NULL,
	[FR] [tinyint] NOT NULL,
	[FC] [tinyint] NOT NULL,
	[Temperatura] [decimal](10, 2) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Peso] [decimal](10, 2) NULL,
	[Estatura] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[ExploracionSistemas]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clinica].[ExploracionSistemas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoriaClinica] [int] NOT NULL,
	[IdSistema] [int] NOT NULL,
	[Descripcion] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Clinica].[HistoriaClinica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Clinica].[HistoriaClinica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdMedico] [int] NOT NULL,
	[FechaHistoria] [date] NOT NULL,
	[MotivoConsulta] [text] NOT NULL,
	[Analisis] [text] NOT NULL,
	[ImpresionDiagnostica] [text] NOT NULL,
	[PlanTerapeutico] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Clinica].[MedicacionActual]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[MedicacionActual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoriaClinica] [int] NOT NULL,
	[Medicamento] [varchar](100) NOT NULL,
	[Dosis] [varchar](100) NOT NULL,
	[FechaInicio] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[NotaEvolutiva]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[NotaEvolutiva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoria] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[Descripcion] [text] NOT NULL,
	[TA] [varchar](20) NULL,
	[Pulso] [tinyint] NOT NULL,
	[FR] [tinyint] NOT NULL,
	[FC] [tinyint] NOT NULL,
	[Temperatura] [decimal](10, 2) NOT NULL,
	[Peso] [decimal](10, 2) NULL,
	[Estatura] [int] NULL,
	[PlanTratamiento] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[Ocupaciones]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[Ocupaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[Ocupacion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Clinica].[Paciente]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Clinica].[Paciente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdLugarResidencia] [int] NOT NULL,
	[Domicilio] [varchar](255) NOT NULL,
	[Tabaco] [bit] NOT NULL,
	[Alcohol] [bit] NOT NULL,
	[CiudadResidencia] [varchar](100) NOT NULL,
	[AnioResidencia] [int] NULL,
	[ocupacion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Catalogo]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Catalogo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[Estado]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Abreviatura] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuracion].[TipoCatalogo]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuracion].[TipoCatalogo](
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
/****** Object:  Table [dbo].[ExploracionFisica]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExploracionFisica](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoriaClinica] [int] NOT NULL,
	[TA] [varchar](20) NULL,
	[Pulso] [tinyint] NOT NULL,
	[FR] [tinyint] NOT NULL,
	[FC] [tinyint] NOT NULL,
	[Temperatura] [decimal](10, 2) NOT NULL,
	[Descripcion] [text] NOT NULL,
	[Peso] [decimal](10, 2) NULL,
	[Estatura] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExploracionSistemas]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExploracionSistemas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdHistoriaClinica] [int] NOT NULL,
	[IdSistema] [int] NOT NULL,
	[Descripcion] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [Administracion].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Medico] FOREIGN KEY([IdPersona])
REFERENCES [Administracion].[Persona] ([Id])
GO
ALTER TABLE [Administracion].[Medico] CHECK CONSTRAINT [FK_Persona_Medico]
GO
ALTER TABLE [Administracion].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo1_Persona] FOREIGN KEY([IdSexo])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Administracion].[Persona] CHECK CONSTRAINT [FK_Catalogo1_Persona]
GO
ALTER TABLE [Administracion].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo2_Persona] FOREIGN KEY([IdTipoSangre])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Administracion].[Persona] CHECK CONSTRAINT [FK_Catalogo2_Persona]
GO
ALTER TABLE [Administracion].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Estado_Persona] FOREIGN KEY([IdLugarNacimiento])
REFERENCES [Configuracion].[Estado] ([Id])
GO
ALTER TABLE [Administracion].[Persona] CHECK CONSTRAINT [FK_Estado_Persona]
GO
ALTER TABLE [Administracion].[Telefonos]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_Telefonos] FOREIGN KEY([IdTipoTelefono])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Administracion].[Telefonos] CHECK CONSTRAINT [FK_Catalogo_Telefonos]
GO
ALTER TABLE [Administracion].[Telefonos]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Telefonos] FOREIGN KEY([IdPersona])
REFERENCES [Administracion].[Persona] ([Id])
GO
ALTER TABLE [Administracion].[Telefonos] CHECK CONSTRAINT [FK_Persona_Telefonos]
GO
ALTER TABLE [Clinica].[Adicciones]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Adicciones] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[Adicciones] CHECK CONSTRAINT [FK_Paciente_Adicciones]
GO
ALTER TABLE [Clinica].[Alergias]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Alergias] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[Alergias] CHECK CONSTRAINT [FK_Paciente_Alergias]
GO
ALTER TABLE [Clinica].[AntecedentesGinecobstetricios]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_AntecedentesGinecobstetricios] FOREIGN KEY([IdAnticonceptivo])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesGinecobstetricios] CHECK CONSTRAINT [FK_Catalogo_AntecedentesGinecobstetricios]
GO
ALTER TABLE [Clinica].[AntecedentesGinecobstetricios]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_AntecedentesGinecobstetricios] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesGinecobstetricios] CHECK CONSTRAINT [FK_Paciente_AntecedentesGinecobstetricios]
GO
ALTER TABLE [Clinica].[AntecedentesHereditarios]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_AntecedentesHereditarios] FOREIGN KEY([IdFamiliar])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesHereditarios] CHECK CONSTRAINT [FK_Catalogo_AntecedentesHereditarios]
GO
ALTER TABLE [Clinica].[AntecedentesHereditarios]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_AntecedentesHereditarios] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesHereditarios] CHECK CONSTRAINT [FK_Paciente_AntecedentesHereditarios]
GO
ALTER TABLE [Clinica].[AntecedentesPatologicos]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_AntecedentesPatologicos] FOREIGN KEY([IdStatus])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesPatologicos] CHECK CONSTRAINT [FK_Catalogo_AntecedentesPatologicos]
GO
ALTER TABLE [Clinica].[AntecedentesPatologicos]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_AntecedentesPatologicos] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[AntecedentesPatologicos] CHECK CONSTRAINT [FK_Paciente_AntecedentesPatologicos]
GO
ALTER TABLE [Clinica].[ExploracionFisica]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_ExploracionFisica] FOREIGN KEY([IdHistoriaClinica])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [Clinica].[ExploracionFisica] CHECK CONSTRAINT [FK_HistoriaClinica_ExploracionFisica]
GO
ALTER TABLE [Clinica].[ExploracionSistemas]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_ExploracionSistemas] FOREIGN KEY([IdSistema])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [Clinica].[ExploracionSistemas] CHECK CONSTRAINT [FK_Catalogo_ExploracionSistemas]
GO
ALTER TABLE [Clinica].[ExploracionSistemas]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_ExploracionSistemas] FOREIGN KEY([IdHistoriaClinica])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [Clinica].[ExploracionSistemas] CHECK CONSTRAINT [FK_HistoriaClinica_ExploracionSistemas]
GO
ALTER TABLE [Clinica].[HistoriaClinica]  WITH CHECK ADD  CONSTRAINT [FK_Medico_HistoriaClinica] FOREIGN KEY([IdMedico])
REFERENCES [Administracion].[Medico] ([Id])
GO
ALTER TABLE [Clinica].[HistoriaClinica] CHECK CONSTRAINT [FK_Medico_HistoriaClinica]
GO
ALTER TABLE [Clinica].[HistoriaClinica]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_HistoriaClinica] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[HistoriaClinica] CHECK CONSTRAINT [FK_Paciente_HistoriaClinica]
GO
ALTER TABLE [Clinica].[MedicacionActual]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_MedicacionActual] FOREIGN KEY([IdHistoriaClinica])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [Clinica].[MedicacionActual] CHECK CONSTRAINT [FK_HistoriaClinica_MedicacionActual]
GO
ALTER TABLE [Clinica].[NotaEvolutiva]  WITH CHECK ADD  CONSTRAINT [fk_historia_nota] FOREIGN KEY([IdHistoria])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [Clinica].[NotaEvolutiva] CHECK CONSTRAINT [fk_historia_nota]
GO
ALTER TABLE [Clinica].[Ocupaciones]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Ocupaciones] FOREIGN KEY([IdPaciente])
REFERENCES [Clinica].[Paciente] ([Id])
GO
ALTER TABLE [Clinica].[Ocupaciones] CHECK CONSTRAINT [FK_Paciente_Ocupaciones]
GO
ALTER TABLE [Clinica].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Estado_Paciente] FOREIGN KEY([IdLugarResidencia])
REFERENCES [Configuracion].[Estado] ([Id])
GO
ALTER TABLE [Clinica].[Paciente] CHECK CONSTRAINT [FK_Estado_Paciente]
GO
ALTER TABLE [Clinica].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Paciente] FOREIGN KEY([IdPersona])
REFERENCES [Administracion].[Persona] ([Id])
GO
ALTER TABLE [Clinica].[Paciente] CHECK CONSTRAINT [FK_Persona_Paciente]
GO
ALTER TABLE [Configuracion].[Catalogo]  WITH CHECK ADD  CONSTRAINT [FK_TipoCatalogo_Catalogo] FOREIGN KEY([IdTipo])
REFERENCES [Configuracion].[TipoCatalogo] ([Id])
GO
ALTER TABLE [Configuracion].[Catalogo] CHECK CONSTRAINT [FK_TipoCatalogo_Catalogo]
GO
ALTER TABLE [dbo].[ExploracionFisica]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_ExploracionFisica] FOREIGN KEY([IdHistoriaClinica])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [dbo].[ExploracionFisica] CHECK CONSTRAINT [FK_HistoriaClinica_ExploracionFisica]
GO
ALTER TABLE [dbo].[ExploracionSistemas]  WITH CHECK ADD  CONSTRAINT [FK_Catalogo_ExploracionSistemas] FOREIGN KEY([IdSistema])
REFERENCES [Configuracion].[Catalogo] ([Id])
GO
ALTER TABLE [dbo].[ExploracionSistemas] CHECK CONSTRAINT [FK_Catalogo_ExploracionSistemas]
GO
ALTER TABLE [dbo].[ExploracionSistemas]  WITH CHECK ADD  CONSTRAINT [FK_HistoriaClinica_ExploracionSistemas] FOREIGN KEY([IdHistoriaClinica])
REFERENCES [Clinica].[HistoriaClinica] ([Id])
GO
ALTER TABLE [dbo].[ExploracionSistemas] CHECK CONSTRAINT [FK_HistoriaClinica_ExploracionSistemas]
GO