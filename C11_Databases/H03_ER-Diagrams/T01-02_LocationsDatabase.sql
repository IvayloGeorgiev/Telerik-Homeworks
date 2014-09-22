USE [master]
GO
/****** Object:  Database [Locations]    Script Date: 24/08/2014 15:18:44 ******/
CREATE DATABASE [Locations]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Locations', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Locations.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Locations_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Locations_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Locations] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Locations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Locations] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Locations] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Locations] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Locations] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Locations] SET ARITHABORT OFF 
GO
ALTER DATABASE [Locations] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Locations] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Locations] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Locations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Locations] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Locations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Locations] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Locations] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Locations] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Locations] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Locations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Locations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Locations] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Locations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Locations] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Locations] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Locations] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Locations] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Locations] SET  MULTI_USER 
GO
ALTER DATABASE [Locations] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Locations] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Locations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Locations] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Locations] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Locations]
GO
/****** Object:  Table [dbo].[ADDRESS]    Script Date: 24/08/2014 15:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRESS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [text] NOT NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTINENT]    Script Date: 24/08/2014 15:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTINENT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CONTINENT_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 24/08/2014 15:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 24/08/2014 15:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWN]    Script Date: 24/08/2014 15:18:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_TOWN_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADDRESS] ON 

INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (1, N'26 Korab Planina Str., App 2230, Floor 300, Postal Code: 1200', 1)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (3, N'131 Ne mi se pishat adresi', 1)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (4, N'123 Oshte ne mis e pishat', 2)
INSERT [dbo].[ADDRESS] ([id], [address_text], [town_id]) VALUES (5, N'612 Somewhere, App. 0', 3)
SET IDENTITY_INSERT [dbo].[ADDRESS] OFF
SET IDENTITY_INSERT [dbo].[CONTINENT] ON 

INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (1, N'North America')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (2, N'South America')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (3, N'Europe')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (4, N'Asia')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (5, N'Africa')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (6, N'Australia')
INSERT [dbo].[CONTINENT] ([id], [name]) VALUES (7, N'Antarctica')
SET IDENTITY_INSERT [dbo].[CONTINENT] OFF
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 

INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (1, N'Bulgaria', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (2, N'China', 4)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (3, N'Australia', 6)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (4, N'Greece', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (5, N'Germany', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (6, N'Ecuador', 2)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (7, N'USA', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (9, N'Canada', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (10, N'Mexico', 1)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (11, N'France', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (12, N'Spain', 3)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (13, N'Japan', 4)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (14, N'Korea', 4)
INSERT [dbo].[COUNTRY] ([id], [name], [continent_id]) VALUES (15, N'India', 4)
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
SET IDENTITY_INSERT [dbo].[PERSON] ON 

INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (1, N'Pencho', N'Penchov', 1)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (2, N'Dragan', N'Draganchov', 1)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Koriandyr', N'Pushkov', 3)
SET IDENTITY_INSERT [dbo].[PERSON] OFF
SET IDENTITY_INSERT [dbo].[TOWN] ON 

INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (2, N'Burgas', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (3, N'Veliko Tyrnovo', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (4, N'Plovdiv', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (5, N'Ruse', 1)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (6, N'Beijing', 2)
INSERT [dbo].[TOWN] ([id], [name], [country_id]) VALUES (7, N'Honk Kong', 2)
SET IDENTITY_INSERT [dbo].[TOWN] OFF
ALTER TABLE [dbo].[ADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESS_TOWN] FOREIGN KEY([town_id])
REFERENCES [dbo].[TOWN] ([id])
GO
ALTER TABLE [dbo].[ADDRESS] CHECK CONSTRAINT [FK_ADDRESS_TOWN]
GO
ALTER TABLE [dbo].[COUNTRY]  WITH CHECK ADD  CONSTRAINT [FK_COUNTRY_CONTINENT] FOREIGN KEY([continent_id])
REFERENCES [dbo].[CONTINENT] ([id])
GO
ALTER TABLE [dbo].[COUNTRY] CHECK CONSTRAINT [FK_COUNTRY_CONTINENT]
GO
ALTER TABLE [dbo].[PERSON]  WITH CHECK ADD  CONSTRAINT [FK_PERSON_ADDRESS1] FOREIGN KEY([address_id])
REFERENCES [dbo].[ADDRESS] ([id])
GO
ALTER TABLE [dbo].[PERSON] CHECK CONSTRAINT [FK_PERSON_ADDRESS1]
GO
ALTER TABLE [dbo].[TOWN]  WITH CHECK ADD  CONSTRAINT [FK_TOWN_COUNTRY] FOREIGN KEY([country_id])
REFERENCES [dbo].[COUNTRY] ([id])
GO
ALTER TABLE [dbo].[TOWN] CHECK CONSTRAINT [FK_TOWN_COUNTRY]
GO
USE [master]
GO
ALTER DATABASE [Locations] SET  READ_WRITE 
GO
