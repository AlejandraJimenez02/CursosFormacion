USE [master]
GO
/****** Object:  Database [cursosFormacion]    Script Date: 4/04/2022 11:33:37 p. m. ******/
CREATE DATABASE [cursosFormacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'cursosFormacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\cursosFormacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'cursosFormacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\cursosFormacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [cursosFormacion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [cursosFormacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [cursosFormacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [cursosFormacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [cursosFormacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [cursosFormacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [cursosFormacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [cursosFormacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [cursosFormacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [cursosFormacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [cursosFormacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [cursosFormacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [cursosFormacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [cursosFormacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [cursosFormacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [cursosFormacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [cursosFormacion] SET  DISABLE_BROKER 
GO
ALTER DATABASE [cursosFormacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [cursosFormacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [cursosFormacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [cursosFormacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [cursosFormacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [cursosFormacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [cursosFormacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [cursosFormacion] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [cursosFormacion] SET  MULTI_USER 
GO
ALTER DATABASE [cursosFormacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [cursosFormacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [cursosFormacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [cursosFormacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [cursosFormacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [cursosFormacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [cursosFormacion] SET QUERY_STORE = OFF
GO
USE [cursosFormacion]
GO
/****** Object:  Table [dbo].[empleados]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[codigoEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](200) NULL,
	[direccion] [varchar](200) NULL,
	[telefono] [varchar](100) NULL,
	[documento] [varchar](18) NULL,
	[fechaNacimiento] [date] NULL,
	[sexo] [varchar](50) NULL,
	[salario] [money] NULL,
	[permiteCurso] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[codigoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cursos]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos](
	[codigoCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombreCurso] [varchar](300) NULL,
	[duracion] [varchar](10) NULL,
	[costo] [money] NULL,
	[prerequisitos] [varchar](max) NULL,
	[descripcion] [varchar](max) NULL,
	[lugar] [varchar](200) NULL,
	[fechaInicio] [date] NULL,
	[fechaFinal] [date] NULL,
	[horarios] [varchar](200) NULL,
	[diaSemanaCurso] [varchar](100) NULL,
	[horaInicio] [time](7) NULL,
	[horaFinal] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[codigoCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cursosEmpleados]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursosEmpleados](
	[idRegistro] [int] IDENTITY(1,1) NOT NULL,
	[codigoEmpleado] [int] NULL,
	[codigoCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[empleadosCursos]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[empleadosCursos]
as
select c.codigoCurso,
e.nombres as nombreEmpleado,
e.documento,
c.nombreCurso,
c.duracion,
c.costo,
c.prerequisitos,
c.descripcion,
c.lugar,
c.fechaInicio,
c.fechaFinal,
c.horarios,
c.diaSemanaCurso,
c.horaInicio,
c.horaFinal

from  cursosEmpleados ce 
left join cursos c on c.codigoCurso =ce.codigoCurso
left join empleados e on e.codigoEmpleado = ce.codigoEmpleado
GO
/****** Object:  Table [dbo].[empleadosDocentes]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleadosDocentes](
	[idDocente] [int] IDENTITY(1,1) NOT NULL,
	[codigoEmpleado] [int] NULL,
	[codigoCurso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horarios]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horarios](
	[IdTipoCursos] [int] IDENTITY(1,1) NOT NULL,
	[TipoCursos] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTipoCursos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[IdSexo] [int] NULL,
	[TipoSexo] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usr]    Script Date: 4/04/2022 11:33:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usr](
	[usr] [varchar](200) NULL,
	[pwd] [varchar](20) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([codigoCurso], [nombreCurso], [duracion], [costo], [prerequisitos], [descripcion], [lugar], [fechaInicio], [fechaFinal], [horarios], [diaSemanaCurso], [horaInicio], [horaFinal]) VALUES (2, N'Curso MEcanica', N'30min,', 3000.0000, N'1', N'algo', N'Medellín', CAST(N'2022-04-02' AS Date), CAST(N'2022-04-02' AS Date), N'no se', N'como asi', CAST(N'21:09:04.9933333' AS Time), CAST(N'21:09:04.9933333' AS Time))
INSERT [dbo].[cursos] ([codigoCurso], [nombreCurso], [duracion], [costo], [prerequisitos], [descripcion], [lugar], [fechaInicio], [fechaFinal], [horarios], [diaSemanaCurso], [horaInicio], [horaFinal]) VALUES (3, N'Curso prueba', N'30min,', 3000.0000, N'1', N'algo', N'Medellín', CAST(N'2022-04-02' AS Date), CAST(N'2022-04-02' AS Date), N'no se', N'como asi', CAST(N'21:09:30.6000000' AS Time), CAST(N'21:09:30.6000000' AS Time))
INSERT [dbo].[cursos] ([codigoCurso], [nombreCurso], [duracion], [costo], [prerequisitos], [descripcion], [lugar], [fechaInicio], [fechaFinal], [horarios], [diaSemanaCurso], [horaInicio], [horaFinal]) VALUES (4, N'Curso prueba 2', N'30min,', 3000.0000, N'1', N'algo', N'Medellín', CAST(N'2022-04-02' AS Date), CAST(N'2022-04-02' AS Date), N'no se', N'como asi', CAST(N'21:09:30.6000000' AS Time), CAST(N'21:09:30.6000000' AS Time))
SET IDENTITY_INSERT [dbo].[cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[cursosEmpleados] ON 

INSERT [dbo].[cursosEmpleados] ([idRegistro], [codigoEmpleado], [codigoCurso]) VALUES (1, 1, 2)
INSERT [dbo].[cursosEmpleados] ([idRegistro], [codigoEmpleado], [codigoCurso]) VALUES (2, 2, 2)
SET IDENTITY_INSERT [dbo].[cursosEmpleados] OFF
GO
SET IDENTITY_INSERT [dbo].[empleados] ON 

INSERT [dbo].[empleados] ([codigoEmpleado], [nombres], [direccion], [telefono], [documento], [fechaNacimiento], [sexo], [salario], [permiteCurso]) VALUES (1, N'Maria Alejandra Jimenez', N'av 39 b,', N'5972234', N'1000445851', CAST(N'2001-02-28' AS Date), N'Femenino', 1000000.0000, 1)
INSERT [dbo].[empleados] ([codigoEmpleado], [nombres], [direccion], [telefono], [documento], [fechaNacimiento], [sexo], [salario], [permiteCurso]) VALUES (2, N'Maria Camila zuluaga', N'av 39 b,', N'5972234', N'1000445851', CAST(N'2001-06-23' AS Date), N'Femenino', 1000000.0000, 1)
SET IDENTITY_INSERT [dbo].[empleados] OFF
GO
INSERT [dbo].[usr] ([usr], [pwd]) VALUES (N'zuluagalondonomariacamila', N'1234')
INSERT [dbo].[usr] ([usr], [pwd]) VALUES (N'admin', N'1234')
GO
ALTER TABLE [dbo].[cursosEmpleados]  WITH CHECK ADD FOREIGN KEY([codigoEmpleado])
REFERENCES [dbo].[empleados] ([codigoEmpleado])
GO
ALTER TABLE [dbo].[cursosEmpleados]  WITH CHECK ADD FOREIGN KEY([codigoCurso])
REFERENCES [dbo].[cursos] ([codigoCurso])
GO
ALTER TABLE [dbo].[empleadosDocentes]  WITH CHECK ADD FOREIGN KEY([codigoEmpleado])
REFERENCES [dbo].[empleados] ([codigoEmpleado])
GO
ALTER TABLE [dbo].[empleadosDocentes]  WITH CHECK ADD FOREIGN KEY([codigoCurso])
REFERENCES [dbo].[cursos] ([codigoCurso])
GO
USE [master]
GO
ALTER DATABASE [cursosFormacion] SET  READ_WRITE 
GO
