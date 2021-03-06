-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing.  --

USE [master]
GO
/****** Object:  Database [PersonalAccounts]    Script Date: 26/08/2014 07:06:40 ******/
CREATE DATABASE [PersonalAccounts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonalAccounts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PersonalAccounts.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonalAccounts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PersonalAccounts_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonalAccounts] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonalAccounts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonalAccounts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonalAccounts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonalAccounts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonalAccounts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonalAccounts] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonalAccounts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonalAccounts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonalAccounts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonalAccounts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonalAccounts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonalAccounts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonalAccounts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonalAccounts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonalAccounts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonalAccounts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonalAccounts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonalAccounts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonalAccounts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonalAccounts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonalAccounts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonalAccounts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonalAccounts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonalAccounts] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PersonalAccounts] SET  MULTI_USER 
GO
ALTER DATABASE [PersonalAccounts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonalAccounts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonalAccounts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonalAccounts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PersonalAccounts] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PersonalAccounts]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 26/08/2014 07:06:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NULL,
	[Balance] [money] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 26/08/2014 07:06:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[SSN] [nvarchar](9) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (1, 1, 700.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (2, 2, -90.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (3, 3, 1000.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (4, 4, 141.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (5, 5, 932.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (6, 6, 10000.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (7, 7, -1000.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (8, 8, 1200.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (9, 9, 500.0000)
INSERT [dbo].[Accounts] ([AccountID], [PersonID], [Balance]) VALUES (10, 10, 100000.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (1, N'Pesho', N'Petrov', N'123151689')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (2, N'Kalin', N'Donkov', N'912831580')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (3, N'Rumina', N'Nalonova', N'914781021')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (4, N'Lyudmil', N'Panayotov', N'811581123')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (5, N'Dragomir', N'Cankov', N'081424031')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (6, N'Hristo', N'Haralampiev', N'901238812')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (7, N'Nevena', N'Karadimova', N'009127771')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (8, N'Svetlina', N'Svetilova', N'512358812')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (9, N'Mladen', N'Filipov', N'801236732')
INSERT [dbo].[Persons] ([PersonID], [FirstName], [LastName], [SSN]) VALUES (10, N'Lyudmila', N'Zhivkova', N'314135123')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([PersonID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
USE [master]
GO
ALTER DATABASE [PersonalAccounts] SET  READ_WRITE 
GO
