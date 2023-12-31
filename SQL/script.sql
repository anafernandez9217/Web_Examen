--SELECCIONA TODO Y EJECUTA TODO

GO
USE master
GO

CREATE DATABASE [DBPRUEBAS]

GO

USE [DBPRUEBAS]
GO
/****** Object:  Table [dbo].[PERSONAS]    Script Date: 20/03/2021 20:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PERSONAS](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Correo] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


-----------------------


go
use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'BdiExamen')
CREATE DATABASE BdiExamen

GO 

USE BdiExamen

GO

--(1) TABLA tblExamen
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'tblExamen')
create table tblExamen(
idExamen int primary key identity(1,1),
Nombre varchar(255),
Descripcion varchar(255)
)

GO


--REGISTRO EN TABLA tblExamen
Insert into tblExamen([Nombre],[Descripcion]) values 
('Primero','Nivel 8'),
('Segundo','Nivel 9')

go