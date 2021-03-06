USE [DB_Citas]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEvento] [int] NOT NULL,
	[FechaInicio] [date] NULL,
	[HoraInicio] [varchar](5) NULL,
	[FechaFin] [date] NULL,
	[HoraFin] [varchar](5) NULL,
	[IdUsuario] [int] NULL,
	[TituloCita] [varchar](50) NULL,
	[IdEstado] [int] NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoCita]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoCita](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoEvento]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EstadoEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoUsuario]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EstadoU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom_Evento] [nvarchar](50) NOT NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sistema]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sistema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sistema] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sistema] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FechaIngreso] [date] NULL,
	[IdRol] [int] NOT NULL,
	[IdSistema] [int] NOT NULL,
	[Correo] [varchar](100) NULL,
	[Telefono] [varchar](15) NULL,
	[IdEstadoUsuario] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaIngreso]
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoCita] ([Id])
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Cita]  WITH CHECK ADD  CONSTRAINT [FK_Cita_Evento] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[Cita] CHECK CONSTRAINT [FK_Cita_Evento]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [FK_Evento_EstadoEvento] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoEvento] ([Id])
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [FK_Evento_EstadoEvento]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdEstadoUsuario])
REFERENCES [dbo].[EstadoUsuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdSistema])
REFERENCES [dbo].[Sistema] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[ActualizarRegistros]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--execute ActualizarRegistros 5,2,'','','',''
CREATE PROCEDURE [dbo].[ActualizarRegistros]
	-- Add the parameters for the stored procedure here
@Id int,@IdEstado int ,@idEvento int ,@FechaInicial date, @HoraInicial varchar(5),@fechaFin date,@HoraFinal varchar(5),@Titulo varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
    -- Insert statements for procedure here
	if @IdEstado is not null
	begin
	      
		  UPDATE [dbo].[Cita]
		  SET [IdEstado] = @IdEstado
		  WHERE id=@ID
	end
	if @idEvento is not null
	begin
	      
		  UPDATE [dbo].[Cita]
		  SET [IdEvento] = @idEvento
		  WHERE id=@ID
	end
	if @FechaInicial is not null
	begin
	      UPDATE [dbo].[Cita]
		  SET FechaInicio = @FechaInicial
		  WHERE id=@ID
	end
	if @HoraInicial is not null
	begin
	      UPDATE [dbo].[Cita]
		  SET HoraInicio = @HoraInicial
		  WHERE id=@ID
	end
	if @fechaFin is not null
	begin
	      UPDATE [dbo].[Cita]
		  SET FechaFin = @fechaFin
		  WHERE id=@ID
	end
	if @HoraFinal is not null
	begin
	      UPDATE [dbo].[Cita]
		  SET HoraFin = @HoraFinal
		  WHERE id=@ID
	end
	if @Titulo is not null
	begin
	      UPDATE [dbo].[Cita]
		  SET TituloCita = @Titulo
		  WHERE id=@ID
	end

   
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultaCitaXId]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
-- execute ConsultaCitaXId 6
CREATE PROCEDURE [dbo].[ConsultaCitaXId]
	-- Add the parameters for the stored procedure here
	@idCita int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT c.Id as IdCita,idEvento,e.Nom_Evento,FechaInicio,HoraInicio,FechaFin,HoraFin,IdUsuario,u.Nombre,TituloCita,es.Id as IdEstado, es.Estado
	from Cita c inner join Evento e on c.IdEvento=e.Id
	inner join EstadoCita es on es.Id = c.IdEstado
	inner join Usuario u on u.id = c.IdUsuario
	where c.id=@idCita
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstados]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarEstados]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id AS IdEstadoCita, Estado 
	from EstadoCita
	
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTodasCitas]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarTodasCitas]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	--Select '' Id,'' idEvento,''FechaInicio,''HoraInicio,''FechaFin,''HoraFin,0 IdUsuario,''TituloCita,'' IdEstado
	SELECT c.Id as IdCita,idEvento,e.Nom_Evento,FechaInicio,HoraInicio,FechaFin,HoraFin,IdUsuario,u.Nombre,TituloCita,es.Id as IdEstado, es.Estado
	from Cita c inner join Evento e on c.IdEvento=e.Id
	inner join EstadoCita es on es.Id = c.IdEstado
	inner join Usuario u on u.id = c.IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[PRC_VALIDAR_AGENDA_CITA]    Script Date: 20/12/2021 14:24:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
--EXECUTE PRC_VALIDAR_AGENDA_CITA '2021-10-16','10:00','2021-10-16','11:00'
create PROCEDURE [dbo].[PRC_VALIDAR_AGENDA_CITA]
	-- Add the parameters for the stored procedure here
	@FECHAI VARCHAR(15), @HORAI VARCHAR(5),@FECHAF VARCHAR(15), @HORAF VARCHAR(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @RESPUESTA BIT = 0;



    -- Insert statements for procedure here
	IF EXISTS (SELECT 1 FROM [DB_Citas].[dbo].[Cita] 
	                    WHERE CONVERT(VARCHAR(24),FechaInicio,120)=@FECHAI 
						AND HoraInicio=@HORAI 
						AND CONVERT(VARCHAR(24),FechaFin,120)=@FECHAF 
						AND HoraFin=@HORAF
						AND IdEstado=1
			   )
	BEGIN
	 PRINT 'ENTRO'
	 
	 SELECT 1 AS RESULTADO
	END
	ELSE 
	SELECT 0 RESULTADO
	
END
GO
