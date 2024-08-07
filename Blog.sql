USE [master]
GO
/****** Object:  Database [SSDLDotNetCore]    Script Date: 4/23/2024 9:44:26 PM ******/
CREATE DATABASE [SSDLDotNetCore] ON  PRIMARY 
( NAME = N'SSDLDotNetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\SSDLDotNetCore.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SSDLDotNetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\SSDLDotNetCore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SSDLDotNetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SSDLDotNetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SSDLDotNetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SSDLDotNetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SSDLDotNetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SSDLDotNetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SSDLDotNetCore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SSDLDotNetCore] SET  MULTI_USER 
GO
ALTER DATABASE [SSDLDotNetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SSDLDotNetCore] SET DB_CHAINING OFF 
GO
USE [SSDLDotNetCore]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 4/23/2024 9:44:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NULL,
	[BlogAuthor] [varchar](50) NULL,
	[BlogContent] [varchar](50) NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (12, N'update title', N'update author', N'update content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
USE [master]
GO
ALTER DATABASE [SSDLDotNetCore] SET  READ_WRITE 
GO
