USE [master]
GO
/****** Object:  StoredProcedure [Administracion].[loginMedico]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Administracion].[loginMedico]
	@Usuario	varchar(50),
	@Passwd		varchar(50)
AS
	select	top 1 Resultado, Mensaje
	FROM	(	select	1 Resultado, HASHBYTES('SHA1',Usuario + CAST(GETDATE() AS VARCHAR)) Mensaje
				from	Administracion.Medico
				where	Usuario = @Usuario AND Contrasenia = HASHBYTES('SHA1',@Passwd)
				union
				select	0 Resultado, HASHBYTES('SHA1','Datos incorrectos') Mensaje
			) T
	order	by Resultado DESC
GO
/****** Object:  StoredProcedure [Administracion].[registraMedico]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Administracion].[registraMedico]
	@Id int = 0,
    @IdSexo int,
    @Nombre varchar(100),
    @IdTipoSangre int, 
    @Rh char(1),
    @FechaNacimiento date, 
    @IdLugarNacimiento int, 
    @CiudadNacimiento varchar(100),

    @Usuario varchar(200),
    @Contrasenia varchar(100) = NULL
AS
BEGIN
	declare @bytes VARBINARY(MAX)
    declare @IdPersona INT

	set @bytes = HASHBYTES('SHA1',isnull(@Contrasenia,''));

	if (@Id = 0)
	BEGIN
		insert into Administracion.Persona(IdSexo, Nombre, IdTipoSangre, Rh, FechaNacimiento, IdLugarNacimiento, CiudadNacimiento)
		values (@IdSexo, @Nombre, @IdTipoSangre, @Rh, @FechaNacimiento, @IdLugarNacimiento, @CiudadNacimiento)

		SET @IdPersona = @@IDENTITY;

		insert into Administracion.Medico(IdPersona, Usuario, Contrasenia)
		values (@IdPersona, @Usuario, @bytes)
	END
	ELSE
	BEGIN
		update Administracion.Persona
		set IdSexo=@IdSexo, Nombre=@Nombre, IdTipoSangre=@IdTipoSangre, Rh=@Rh, FechaNacimiento=@FechaNacimiento, IdLugarNacimiento=@IdLugarNacimiento, CiudadNacimiento=@CiudadNacimiento
		where Id = @Id
		set @IdPersona = @Id
	END

	
    select  Pe.Id, Pe.FechaNacimiento, Pe.CiudadNacimiento, Pe.Nombre, Pe.Rh, S.Nombre Sexo, TS.Nombre TipoSangre,
			E.Nombre LugarNacimiento, Me.Usuario
    from    Administracion.Persona Pe
            join Configuracion.Catalogo S
    on      S.Id = Pe.IdSexo
            join Configuracion.Catalogo TS
    on      Pe.IdTipoSangre = TS.Id
            join Configuracion.Estado E
    on      E.Id = Pe.IdLugarNacimiento
            join Administracion.Medico Me
    on      Me.IdPersona = Pe.Id
	where	IdPersona = @IdPersona
END

GO
/****** Object:  StoredProcedure [Administracion].[registraTelefono]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [Administracion].[registraTelefono]
    @IdPersona int,
    @IdTipoTelefono int, 
    @NumeroTelefono varchar(20)
as
    insert into Administracion.Telefonos( IdPersona, IdTipoTelefono, NumeroTelefono)
    values (@IdPersona, @IdTipoTelefono, @NumeroTelefono)

	select Id, IdPersona, IdTipoTelefono, NumeroTelefono
	from Administracion.Telefonos
	where Id = @@IDENTITY

GO
/****** Object:  StoredProcedure [Administracion].[verMedico]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Administracion].[verMedico]
	@Id INT
AS
    select  Pe.Id, Pe.FechaNacimiento, Pe.CiudadNacimiento, Pe.Nombre, Pe.Rh, S.Nombre Sexo, TS.Nombre TipoSangre,
			E.Nombre LugarNacimiento, Me.Usuario, E.Id IdLugarNacimiento, TS.Id IdTipoSangre, S.Id IdSexo
    from    Administracion.Persona Pe
            join Configuracion.Catalogo S
    on      S.Id = Pe.IdSexo
            join Configuracion.Catalogo TS
    on      Pe.IdTipoSangre = TS.Id
            join Configuracion.Estado E
    on      E.Id = Pe.IdLugarNacimiento
            join Administracion.Medico Me
    on      Me.IdPersona = Pe.Id
	where	Pe.Id = @Id

GO
/****** Object:  StoredProcedure [Clinica].[buscarHistorias]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[buscarHistorias]
		@IdPaciente int = 0,
		@Paciente varchar(200) = null,
		@IdMedico int = 0,
		@FechaHistoria date = null
as
begin
	if @IdPaciente = 0
		set @IdPaciente = NULL
	if @IdMedico = 0
		set @IdMedico = NULL

	select	HC.Id, Pa.Id IdPaciente, HC.FechaHistoria, HC.MotivoConsulta, Pe2.Nombre Medico,
			Pe.Nombre Paciente
	from	Clinica.Paciente Pa (nolock)
			join Administracion.Persona Pe (nolock)
	on		Pa.IdPersona = Pe.Id
			join Clinica.HistoriaClinica HC (nolock)
	on		Pa.Id = HC.IdPaciente
			join Administracion.Medico Me (nolock)
	on		HC.IdMedico = Me.Id
			join Administracion.Persona Pe2 (nolock)
	on		Me.IdPersona = Pe2.Id
	where	Pa.Id = ISNULL(@IdPaciente, Pa.Id) and
			Me.Id = ISNULL(@IdMedico, Me.Id) and
			HC.FechaHistoria between ISNULL(@FechaHistoria, HC.FechaHistoria) and getdate() and
			Pe.Nombre like '%' + ISNULL(@Paciente, '') + '%'
	order	by HC.Id
end
GO
/****** Object:  StoredProcedure [Clinica].[buscarPaciente]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[buscarPaciente]
		@IdLugarResidencia int = 0,
		@IdLugarNacimiento int = 0,
		@IdTipoSangre int = 0,
		@IdSexo int = 0,
		@Nombre varchar(200) = '',
		@Domicilio varchar(200) = '',
		@CiudadResidencia varchar(200) = '',
		@CiudadNacimiento varchar(200) = '',
		@Rh char(1) = '',
		@Tabaco bit = 0,
		@Alcohol bit = 0,
		@FechaNacimiento date = null
as
begin
	if @IdLugarResidencia = 0
		set @IdLugarResidencia = NULL
	if @IdLugarNacimiento = 0
		set @IdLugarNacimiento = NULL
	if @IdSexo = 0
		set @IdSexo = NULL
	if @IdTipoSangre = 0
		set @IdTipoSangre = NULL

	if @Nombre = ''
		set @Nombre = NULL
	if @Domicilio = ''
		set @Domicilio = NULL
	if @CiudadNacimiento = ''
		set @CiudadNacimiento = NULL
	if @CiudadResidencia = ''
		set @CiudadResidencia = NULL
	if @Rh = ''
		set @Rh = NULL

	if @Tabaco = 0
		set @Tabaco = NULL
	if @Alcohol = 0
		set @Alcohol = NULL

	select	Pa.Id IdPaciente, Pe.Nombre, case TS.Id when 37 then '' else TS.Nombre end + Pe.Rh TipoSangre, S.Nombre Sexo, T.NumeroTelefono
	from	Clinica.Paciente Pa (nolock)
			join Administracion.Persona Pe (nolock)
	on		Pa.IdPersona = Pe.Id
			join Configuracion.Catalogo TS (nolock)
	on		Pe.IdTipoSangre = TS.Id
			join Configuracion.Catalogo S (nolock)
	on		Pe.IdSexo = S.Id
			left join Administracion.Telefonos T (nolock)
	on		Pe.Id = T.IdPersona
	where
			Pa.IdLugarResidencia = ISNULL(@IdLugarResidencia,Pa.IdLugarResidencia) and
			Pa.Domicilio like isnull('%' + @Domicilio + '%', Pa.Domicilio) and
			Pa.Tabaco = isnull(@Tabaco, Pa.Tabaco) and
			Pa.Alcohol = isnull(@Alcohol, Pa.Alcohol) and
			Pa.CiudadResidencia like isnull('%'+ @CiudadResidencia +'%', Pa.CiudadResidencia) and
			Pe.IdSexo = ISNULL(@IdSexo, Pe.IdSexo) and
			Pe.Nombre like isnull('%' + @Nombre + '%', Pe.Nombre) and
			Pe.IdTipoSangre = ISNULL(@IdTipoSangre, Pe.IdTipoSangre) and
			Pe.Rh = ISNULL(@Rh, Pe.Rh) and
			--cast(Pe.FechaNacimiento as date) = cast(isnull(@FechaNacimiento, Pe.FechaNacimiento) as date) and
			Pe.IdLugarNacimiento = ISNULL(@IdLugarNacimiento,Pe.IdLugarNacimiento) and
			Pe.CiudadNacimiento like isnull('%'+ @CiudadNacimiento +'%', Pe.CiudadNacimiento)
end
GO
/****** Object:  StoredProcedure [Clinica].[listarHistoriasPaciente]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[listarHistoriasPaciente]
	@IdPaciente int
as
select	HC.Id, IdPaciente, IdMedico, FechaHistoria, MotivoConsulta, Analisis, ImpresionDiagnostica, PlanTerapeutico
from	Clinica.HistoriaClinica HC
		join Administracion.Medico M
on		HC.IdMedico = M.Id
where	IdPaciente =  @IdPaciente
GO
/****** Object:  StoredProcedure [Clinica].[registraPaciente]    Script Date: 11/01/2019 02:41:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Clinica].[registraPaciente]
	@Id int = 0,
    @IdSexo int,
    @Nombre varchar(100),
    @IdTipoSangre int, 
    @Rh char(1),
    @FechaNacimiento date, 
    @IdLugarNacimiento int, 
    @CiudadNacimiento varchar(100),
    @IdLugarResidencia int,
    @Domicilio varchar(200),
    @Tabaco bit,
    @Alcohol bit, 
    @CiudadResidencia varchar(100),
	@Numero varchar(20),
	@IdTipoNumero int,
	@Ocupacion varchar(100) = null,
	@AnioResidencia int = null,
	@Alergias varchar(max) = null,
	@Adicciones varchar(max) = null
AS
BEGIN
    declare @IdPersona INT,
			@IdPaciente INT
	if (@Id = 0)
	begin
		insert into Administracion.Persona(IdSexo, Nombre, IdTipoSangre, Rh, FechaNacimiento, IdLugarNacimiento, CiudadNacimiento)
		values (@IdSexo, @Nombre, @IdTipoSangre, @Rh, @FechaNacimiento, @IdLugarNacimiento, @CiudadNacimiento)

		SET @IdPersona = @@IDENTITY;

		insert into clinica.paciente(IdPersona, IdLugarResidencia, Domicilio, Tabaco, Alcohol, CiudadResidencia, AnioResidencia, ocupacion)
		values (@IdPersona, @IdLugarResidencia, @Domicilio, @Tabaco, @Alcohol, @CiudadResidencia, @AnioResidencia, @Ocupacion)

		SET @IdPaciente = @@IDENTITY;
		insert into Administracion.Telefonos (IdPersona, IdTipoTelefono, NumeroTelefono)
		values (@IdPersona, @IdTipoNumero, @Numero)

		INSERT INTO Clinica.Adicciones(IdPaciente, Adiccion)
		select @IdPaciente, LTRIM(RTRIM(Name)) from miSplitString (@Adicciones) A
		where A.Name is not null and Name != ''

		INSERT INTO Clinica.Alergias(IdPaciente, Alergia)
		select @IdPaciente, LTRIM(RTRIM(Name)) from miSplitString (@Alergias) A
		where A.Name is not null and Name != ''
	end
	else
	begin
		select	@IdPersona = IdPersona
		from	Clinica.Paciente Pa
		where	Id = @Id

		update	Administracion.Persona
		set		IdSexo = @IdSexo, Nombre = @Nombre, IdTipoSangre = @IdTipoSangre, Rh = @Rh, FechaNacimiento = @FechaNacimiento,
				IdLugarNacimiento = @IdLugarNacimiento, CiudadNacimiento = @CiudadNacimiento
		where	Id = @IdPersona

		update	Clinica.Paciente
		set		IdPersona = @IdPersona, IdLugarResidencia = @IdLugarResidencia, Domicilio = @Domicilio, Tabaco = @Tabaco,
				Alcohol = @Alcohol, CiudadResidencia = @CiudadResidencia, ocupacion = @Ocupacion, AnioResidencia = @AnioResidencia
		where	Id = @Id

		INSERT INTO Clinica.Adicciones(IdPaciente, Adiccion)
		select @Id, LTRIM(Name) from miSplitString (@Adicciones) m left join Clinica.Adicciones A
		on LTRIM(RTRIM(m.Name)) = LTRIM(RTRIM(A.Adiccion)) and A.IdPaciente = @Id
		where A.Id is null and Name is not  null and Name != ''

		INSERT INTO Clinica.Alergias(IdPaciente, Alergia)
		select @Id, LTRIM(Name) from miSplitString (@Alergias) m left join Clinica.Alergias A
		on LTRIM(RTRIM(m.Name)) = LTRIM(RTRIM(A.Alergia)) and A.IdPaciente = @Id
		where A.Id is null and Name is not  null and Name != ''

		if NOT EXISTS (select 1 FROM Administracion.Telefonos T (nolock) WHERE IdPersona = @IdPersona AND IdTipoTelefono = @IdTipoNumero)
		BEGIN
			insert into Administracion.Telefonos (IdPersona, IdTipoTelefono, NumeroTelefono)
			values (@IdPersona, @IdTipoNumero, @Numero)
		END
		ELSE
		BEGIN
			update Administracion.Telefonos
			set NumeroTelefono = @Numero
			where IdPersona = @IdPersona and IdTipoTelefono = @IdTipoNumero
		END

		set @IdPaciente = @Id
	end

	declare @maxid int = 0,
			@LasAlergias varchar(max) = '',
			@LasAdicciones varchar(max) = ''

	while @maxid is not null 
	begin
		set @maxid = (select top 1 A.Id from Clinica.Alergias A where @maxid < A.Id and A.IdPaciente = @IdPaciente order by A.Id)
		select @LasAlergias += ', ' + Alergia from Clinica.Alergias where Id = @maxid
	end
	if LEN(@LasAlergias)>2
		select @LasAlergias = right(@LasAlergias, len(@LasAlergias)-2)

	set @maxid = 0
	while @maxid is not null 
	begin
		set @maxid = (select top 1 A.Id from Clinica.Adicciones A where @maxid < A.Id and A.IdPaciente = @IdPaciente order by A.Id)
		select @LasAdicciones += ', ' + Adiccion from Clinica.Adicciones where Id = @maxid
	end
	if LEN(@LasAdicciones) > 2
		select @LasAdicciones = right(@LasAdicciones, len(@LasAdicciones)-2)

	select  Pe.Id IdPersona, S.Nombre Sexo, Pe.Nombre, TS.Nombre TipoSangre, Pe.Rh, Pe.FechaNacimiento, E.Nombre LugarNacimiento,
			Pe.CiudadNacimiento, Pa.Id IdPaciente, E2.Nombre LugarResidencia, Pa.Domicilio, Pa.Tabaco, Pa.Alcohol, Pa.CiudadResidencia,
			Tel.NumeroTelefono Numero, Tel.IdTipoTelefono, TT.Nombre TipoTelefono, Pa.IdLugarResidencia, Pe.IdLugarNacimiento,
			Pe.IdSexo,Pe.IdTipoSangre, Pa.AnioResidencia, Pa.ocupacion, @LasAdicciones Adicciones, @LasAlergias Alergias
	from    Administracion.Persona Pe
			join Configuracion.Catalogo S
	on      S.Id = Pe.IdSexo
			join Configuracion.Catalogo TS
	on      Pe.IdTipoSangre = TS.Id
			join Configuracion.Estado E
	on      E.Id = Pe.IdLugarNacimiento
			join Clinica.Paciente Pa
	on      Pa.IdPersona = Pe.Id
			join Configuracion.Estado E2
	ON      E2.Id = Pa.IdLugarResidencia
			left join Administracion.Telefonos Tel
	ON		Pe.Id = Tel.IdPersona
			join Configuracion.Catalogo TT
	ON		Tel.IdTipoTelefono = TT.Id
	where	Pa.Id = @IdPaciente
END
GO
/****** Object:  StoredProcedure [Clinica].[selNotaEvolutiva]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[selNotaEvolutiva]
	@Id int = null,
	@idhistoria int = null
as
begin
	if (@Id is null)
		set @Id = 0

	if (@id != 0)
		select	N.Id, N.IdHistoria, N.Fecha, N.Descripcion, N.TA, N.Pulso, N.FR, N.FC, N.Temperatura, N.Peso, N.Estatura,
				N.PlanTratamiento, H.IdPaciente
		from	clinica.NotaEvolutiva N (nolock) join Clinica.HistoriaClinica H (nolock)
		on		N.IdHistoria = H.Id
		where	N.Id = @Id
	else
	begin
		if (@idhistoria is null)
			set @idhistoria = 0
		if @idhistoria != 0
			select	N.Id, N.IdHistoria, N.Fecha, substring(N.Descripcion, 0, 40) + '...' Descripcion,
					N.TA, N.Pulso, N.FR, N.FC, N.Temperatura, N.Peso, N.Estatura,
					substring(N.PlanTratamiento, 0, 40) + '...' PlanTratamiento, H.IdPaciente
			from	clinica.NotaEvolutiva N (nolock) join Clinica.HistoriaClinica H (nolock)
			on		N.IdHistoria = H.Id
			where	N.IdHistoria = @idhistoria
			order	by Fecha desc
	end
end
GO
/****** Object:  StoredProcedure [Clinica].[selPaciente]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Clinica].[selPaciente]
    @IdPaciente INT
AS
BEGIN
	declare @maxid int = 0,
			@LasAlergias varchar(max) = '',
			@LasAdicciones varchar(max) = ''

	while @maxid is not null 
	begin
		set @maxid = (select top 1 A.Id from Clinica.Alergias A where @maxid < A.Id and A.IdPaciente = @IdPaciente order by A.Id)
		select @LasAlergias += ', ' + Alergia from Clinica.Alergias where Id = @maxid
	end
	if LEN(@LasAlergias)>2
		select @LasAlergias = right(@LasAlergias, len(@LasAlergias)-2)

	set @maxid = 0
	while @maxid is not null 
	begin
		set @maxid = (select top 1 A.Id from Clinica.Adicciones A where @maxid < A.Id and A.IdPaciente = @IdPaciente order by A.Id)
		select @LasAdicciones += ', ' + Adiccion from Clinica.Adicciones where Id = @maxid
	end
	if LEN(@LasAdicciones) > 2
		select @LasAdicciones = right(@LasAdicciones, len(@LasAdicciones)-2)

    select  Pe.Id IdPersona, S.Nombre Sexo, Pe.Nombre, TS.Nombre TipoSangre, Pe.Rh, Pe.FechaNacimiento, E.Nombre LugarNacimiento,
            Pe.CiudadNacimiento, Pa.Id IdPaciente, E2.Nombre LugarResidencia, Pa.Domicilio, Pa.Tabaco, Pa.Alcohol, Pa.CiudadResidencia,
            TT.Nombre TipoTelefono, TT.Id IdTipoTelefono, T.NumeroTelefono, E.Id IdLugarNacimiento,E2.Id IdLugarResidencia, S.Id IdSexo,TS.Id IdTipoSangre,
			Pa.AnioResidencia, pa.ocupacion, @LasAdicciones Adicciones, @LasAlergias Alergias
    from    Administracion.Persona Pe (nolock)
            join Clinica.Paciente Pa (nolock)
    on      Pa.IdPersona = Pe.Id and Pa.Id = @IdPaciente
            left join Administracion.Telefonos T
    on      T.IdPersona = Pe.Id
            left join Configuracion.Catalogo S (nolock)
    on      S.Id = Pe.IdSexo
            left join Configuracion.Catalogo TS (nolock)
    on      Pe.IdTipoSangre = TS.Id
            left join Configuracion.Estado E (nolock)
    on      E.Id = Pe.IdLugarNacimiento
            left join Configuracion.Estado E2 (nolock)
    ON      E2.Id = Pa.IdLugarResidencia
            left join Configuracion.Catalogo TT (nolock)
    on      T.IdTipoTelefono = TT.Id
    
END
GO
/****** Object:  StoredProcedure [Clinica].[spCargarAntGineco]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spCargarAntGineco]
	@Id int
as
begin
	select Id, IdPaciente, IdAnticonceptivo, A, C, G, P, FUR, Mastografia, Menarca, Papanicolaou
	from Clinica.AntecedentesGinecobstetricios AG
	where IdPaciente = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarAntHered]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spCargarAntHered]
	@IdPaciente int
as
begin
	select row_number() over (partition by IdPaciente order by IdFamiliar) Id, AH.Id IdAH, IdPaciente, IdFamiliar,
			F.Nombre Familiar, Padecimiento
	from Clinica.AntecedentesHereditarios AH join Configuracion.vFamiliares F
	on AH.IdFamiliar = F.Id
	where AH.IdPaciente = @IdPaciente
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarAntPersonalPatologico]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spCargarAntPersonalPatologico]
	@IdPaciente int
as
begin
	select AP.Id, AP.IdPaciente, AP.IdStatus, S.Nombre Status, Ap.Enfermedad, AP.FechaInicio
	from Clinica.AntecedentesPatologicos AP join Configuracion.Catalogo S
	on AP.IdStatus = S.Id
	where AP.IdPaciente = @IdPaciente
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarExploracionFisica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spCargarExploracionFisica]
	@IdHistoria int
as
begin
	select Id, IdHistoriaClinica, TA, Pulso, FR, FC, Temperatura, Descripcion, Peso, Estatura
	from Clinica.ExploracionFisica EF
	where IdHistoriaClinica = @IdHistoria
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarExploracionSistema]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spCargarExploracionSistema]
	@IdHistoria int
as
begin
	select ES.Id, IdHistoriaClinica, IdSistema, S.Nombre Sistema, ES.Descripcion
	from Clinica.ExploracionSistemas ES
	join Configuracion.Catalogo S
	on IdSistema = S.Id
	where IdHistoriaClinica = @IdHistoria
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarHistoriaClinica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spCargarHistoriaClinica]
	@IdHistoria int
as
begin
	select Id, IdPaciente, Analisis, FechaHistoria, IdMedico, IdPaciente, ImpresionDiagnostica, MotivoConsulta,
			PlanTerapeutico
	from Clinica.HistoriaClinica HC
	where HC.Id = @IdHistoria
end
GO
/****** Object:  StoredProcedure [Clinica].[spCargarMedicacionActual]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spCargarMedicacionActual]
	@IdHistoria int
as
begin
	select Id, IdHistoriaClinica, Medicamento, Dosis, FechaInicio
	from Clinica.MedicacionActual
	where IdHistoriaClinica = @IdHistoria
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaAntGineco]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spGuardaAntGineco]
@Id int = 0,
@IdPaciente int,
@A int,
@C int,
@FUR date,
@G int, 
@IdAnticonceptivo int,
@Mastografia date,
@Menarca date,
@P int,
@Papanicolaou date
as
begin
	if @id = 0
	begin
		insert into Clinica.AntecedentesGinecobstetricios (A, C, FUR, G, IdAnticonceptivo, IdPaciente, Mastografia, Menarca, P, Papanicolaou)
		values (@A, @C, @FUR, @G, @IdAnticonceptivo, @IdPaciente, @Mastografia, @Menarca, @P, @Papanicolaou)
		SET @Id = @@IDENTITY;
	end
	else
	begin
		update Clinica.AntecedentesGinecobstetricios
		set A=@A, C=@C, FUR=@FUR, G=@G, IdAnticonceptivo=@IdAnticonceptivo, IdPaciente=@IdPaciente, Mastografia=@Mastografia,
			Menarca=@Menarca, P=@P, Papanicolaou=@Papanicolaou
		where Id = @Id
	end
	select A, C, FUR, G, IdAnticonceptivo, IdPaciente, Mastografia, Menarca, P, Papanicolaou
	from Clinica.AntecedentesGinecobstetricios
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaAntHered]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spGuardaAntHered]
	@Id int = 0,
	@IdFamiliar int,
	@IdPaciente int,
	@Padecimiento varchar(50)
as
begin
	if @id = 0
	begin
		insert into Clinica.AntecedentesHereditarios (IdPaciente, IdFamiliar, Padecimiento)
		values (@IdPaciente,  @IdFamiliar, @Padecimiento)
		SET @Id = @@IDENTITY;
	end
	else
	begin
		update Clinica.AntecedentesHereditarios
		set IdPaciente = @IdPaciente, IdFamiliar= @IdFamiliar, Padecimiento = @Padecimiento
		where Id = @Id
	end
	select Id, IdPaciente, IdFamiliar, Padecimiento
	from Clinica.AntecedentesHereditarios
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaAntPersonalPatologico]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spGuardaAntPersonalPatologico]
	@Id int = 0,
	@IdPaciente int,
	@IdStatus int,
	@Enfermedad varchar(100),
	@FechaInicio date
as
begin
	if @IdStatus = 0
		set @IdStatus = 26

	if @id = 0
	begin
		insert into Clinica.AntecedentesPatologicos(IdPaciente, IdStatus, Enfermedad, FechaInicio)
		values (@IdPaciente, @IdStatus, @Enfermedad, @FechaInicio)
		SET @Id = @@IDENTITY;
	end
	else
	begin
		update Clinica.AntecedentesPatologicos
		set IdPaciente=@IdPaciente, IdStatus=@IdStatus, Enfermedad=@Enfermedad, FechaInicio=@FechaInicio
		where Id = @Id
	end
	select Id, IdPaciente, IdStatus, Enfermedad, FechaInicio
	from Clinica.AntecedentesPatologicos
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaExploracionFisica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spGuardaExploracionFisica]
	@Id int = null,
	@IdHistoriaClinica int = null,
	@TA varchar(20),
	@Pulso tinyint,
	@FR tinyint,
	@FC tinyint,
	@Temperatura decimal(10,2),
	@Descripcion text,
	@Peso decimal(10,2),
	@Estatura int
as
begin
	if @Id = 0
		set @Id = null
	if @Id is null
	begin
		insert into Clinica.ExploracionFisica(IdHistoriaClinica, TA, Pulso, FR, FC, Temperatura, Descripcion, Peso, Estatura)
		values (@IdHistoriaClinica, @TA, @Pulso, @FR, @FC, @Temperatura, @Descripcion, @Peso, @Estatura)
		set @Id = @@IDENTITY
	end
	else
	begin
		update Clinica.ExploracionFisica
		set IdHistoriaClinica = @IdHistoriaClinica, TA = @TA, Pulso = @Pulso, FR = @FR, FC = @FC, Temperatura = @Temperatura,
			Descripcion = @Descripcion, Peso = @Peso, Estatura = @Estatura
		where Id = @Id
	end

	select Id, IdHistoriaClinica, TA, Pulso, FR, FC, Temperatura, Descripcion, Peso, Estatura
	from Clinica.ExploracionFisica
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaExploracionSistema]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spGuardaExploracionSistema]
	@Id int = 0,
	@IdHistoria int,
	@IdSistema int,
	@Descripcion text
as
begin
	if @id = 0
	begin
		insert into Clinica.ExploracionSistemas(IdHistoriaClinica, IdSistema, Descripcion)
		values (@IdHistoria, @IdSistema, @Descripcion)
		SET @Id = @@IDENTITY;
	end
	else
	begin
		update Clinica.ExploracionSistemas
		set IdHistoriaClinica = @IdHistoria, IdSistema = @IdSistema, Descripcion = @Descripcion
		where Id = @Id
	end
	select Id, IdHistoriaClinica IdHistoria, IdSistema, Descripcion
	from Clinica.ExploracionSistemas
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaHistoriaClinica]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [Clinica].[spGuardaHistoriaClinica]
	@Id int = 0,
	@IdPaciente int,
	@IdMedico int,
	@FechaHistoria date,
	@MotivoConsulta text,
	@Analisis text,
	@ImpresionDiagnostica text,
	@PlanTerapeutico text

as
begin
	if @id = 0
	begin
		insert into Clinica.HistoriaClinica(IdPaciente, IdMedico, FechaHistoria, MotivoConsulta, Analisis, ImpresionDiagnostica, PlanTerapeutico)
		values (@IdPaciente, @IdMedico, @FechaHistoria, @MotivoConsulta, @Analisis, @ImpresionDiagnostica, @PlanTerapeutico)
		SET @Id = @@IDENTITY;
	end
	else
	begin
		update Clinica.HistoriaClinica
		set IdPaciente=@IdPaciente, IdMedico=@IdMedico, FechaHistoria=@FechaHistoria, MotivoConsulta=@MotivoConsulta, Analisis=@Analisis, ImpresionDiagnostica=@ImpresionDiagnostica, PlanTerapeutico=@PlanTerapeutico
		where Id = @Id
	end
	select Id, IdPaciente, IdMedico, FechaHistoria, MotivoConsulta, Analisis, ImpresionDiagnostica, PlanTerapeutico
	from Clinica.HistoriaClinica
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaMedicacionActual]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spGuardaMedicacionActual]
	@Id int,
	@IdHistoria int,
	@Dosis varchar(200),
	@FechaInicio date,
	@Medicamento varchar(200)
as
begin
	if @id = 0
	begin
		insert into Clinica.MedicacionActual(IdHistoriaClinica, Dosis, FechaInicio, Medicamento)
		values (@IdHistoria, @Dosis, @FechaInicio, @Medicamento)
		set @Id = @@IDENTITY
	end
	else
	begin
		update Clinica.MedicacionActual
		set IdHistoriaClinica = @IdHistoria, Dosis = @Dosis, FechaInicio = @FechaInicio, Medicamento = @Medicamento
		where Id = @Id
	end
	select Id, IdHistoriaClinica IdHistoria, Dosis, FechaInicio, Medicamento
	from Clinica.MedicacionActual
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Clinica].[spGuardaNotaEvolutiva]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Clinica].[spGuardaNotaEvolutiva]
	@Id int,
	@IdHistoria int,
	@Fecha date,
	@Descripcion text,
	@PlanTratamiento text,
	@TA varchar(20),
	@Pulso tinyint,
	@FR tinyint,
	@FC tinyint,
	@Temperatura decimal(10, 2),
	@Peso decimal(10, 2),
	@Estatura int
as
begin
	if @Id = 0
		set @Id = null

	if @Id is null
	begin
		insert into Clinica.NotaEvolutiva(IdHistoria, Descripcion, Estatura, FC, Fecha, FR, Peso, Pulso, TA, Temperatura, PlanTratamiento)
		values (@IdHistoria, @Descripcion, @Estatura, @FC, @Fecha, @FR, @Peso, @Pulso, @TA, @Temperatura, @PlanTratamiento)
		set @Id = @@IDENTITY
	end
	else
	begin
		update Clinica.NotaEvolutiva
		set IdHistoria = @IdHistoria, Descripcion = @Descripcion, Estatura = @Estatura, FC = @FC, Fecha = @Fecha, FR = @FR, Peso = @Peso, 
			Pulso = @Pulso, TA = @TA, Temperatura = @Temperatura, PlanTratamiento = @PlanTratamiento
		where Id = @Id
	end
	select Id, IdHistoria, Descripcion, Estatura, FC, Fecha, FR, Peso, Pulso, TA, Temperatura, PlanTratamiento
	from Clinica.NotaEvolutiva
	where Id = @Id
end
GO
/****** Object:  StoredProcedure [Configuracion].[obtenerEstados]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [Configuracion].[obtenerEstados]
	@id int = 0,
	@nombre varchar(50) = ''
as
begin
	if (@id = 0)
		set @id = null

	if (@nombre = '')
		set @nombre = null

	select *
	from Configuracion.Estado
	where id = isnull(@id,id) and Nombre like '%' + ISNULL(@nombre, Nombre) + '%'
end
GO
/****** Object:  StoredProcedure [Configuracion].[spCatalogo]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuracion].[spCatalogo]
    @Catalogo VARCHAR(50)
AS
if (@Catalogo = 'Medico')
BEGIN
	SELECT M.Id, Pe.Nombre, 'Medico' Catalogo FROM Administracion.Medico M (nolock)
	JOIN Administracion.Persona Pe (nolock)
	ON M.IdPersona = Pe.Id
	ORDER BY Pe.Nombre
END
ELSE
BEGIN
	select C.Id, C.Nombre, TC.Nombre Catalogo
	from Configuracion.Catalogo C (nolock)
	join Configuracion.TipoCatalogo TC (nolock)
	on TC.Id = C.IdTipo
	where TC.Nombre = @Catalogo
	ORDER BY Nombre
END
GO
/****** Object:  UserDefinedFunction [dbo].[miSplitString]    Script Date: 30/07/2020 10:41:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[miSplitString] ( @stringToSplit VARCHAR(MAX) )
RETURNS
@returnList TABLE ([Name] [nvarchar] (500))
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT

 WHILE CHARINDEX(',', @stringToSplit) > 0
 BEGIN
  SELECT @pos  = CHARINDEX(',', @stringToSplit)  
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1)

  INSERT INTO @returnList 
  SELECT @name

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END

 INSERT INTO @returnList
 SELECT LTRIM(RTRIM(@stringToSplit))

 RETURN
END
GO
USE [master]
GO
ALTER DATABASE [HistoriaClinica] SET  READ_WRITE 
GO
