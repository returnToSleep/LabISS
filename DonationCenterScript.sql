/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [Test]    Script Date: 27-Apr-18 12:58:32 PM ******/
CREATE DATABASE [Test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MYSQL\MSSQL\DATA\Test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MYSQL\MSSQL\DATA\Test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Test] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test] SET RECOVERY FULL 
GO
ALTER DATABASE [Test] SET  MULTI_USER 
GO
ALTER DATABASE [Test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Test', N'ON'
GO
ALTER DATABASE [Test] SET QUERY_STORE = OFF
GO
USE [Test]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Test]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 27-Apr-18 12:58:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[speciality] [varchar](50) NOT NULL,
	[hospital] [varchar](50) NOT NULL,
	[location_id] [int] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorRequest]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorRequest](
	[doctor_id] [int] NOT NULL,
	[donationCenter_id] [int] NOT NULL,
	[priority] [int] NOT NULL,
	[patientName] [varchar](50) NOT NULL,
	[requestString] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationCenter]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonationCenter](
	[id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
 CONSTRAINT [PK_DonationCenter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[name] [varchar](50) NOT NULL,
	[cnp] [varchar](50) NOT NULL,
	[birthdate] [date] NULL,
	[address] [varchar](50) NOT NULL,
	[location_id] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[isPending] [bit] NOT NULL,
	[donationCenter_id] [int] NOT NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[cnp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[addressString] [varchar](50) NOT NULL,
	[id] [int] NOT NULL,
	[latitude] [real] NOT NULL,
	[longitude] [real] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogInfo]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogInfo](
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[id] [int] NULL,
	[type] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plasma]    Script Date: 27-Apr-18 12:58:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plasma](
	[id] [int] NOT NULL,
	[antibody] [varchar](2) NULL,
	[donationCenter_id] [int] NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NULL,
 CONSTRAINT [PK_Plasma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RedBloodCell]    Script Date: 27-Apr-18 12:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RedBloodCell](
	[antigen] [varchar](2) NULL,
	[rh] [bit] NULL,
	[donationCenter_id] [int] NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NULL,
	[id] [int] NOT NULL,
 CONSTRAINT [PK_RedBloodCell] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trobocyte]    Script Date: 27-Apr-18 12:58:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trobocyte](
	[id] [int] NOT NULL,
	[donationCenter_id] [int] NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NULL,
 CONSTRAINT [PK_Trobocyte] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_Location] FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_Location]
GO
ALTER TABLE [dbo].[DoctorRequest]  WITH CHECK ADD  CONSTRAINT [FK_DoctorRequest_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
GO
ALTER TABLE [dbo].[DoctorRequest] CHECK CONSTRAINT [FK_DoctorRequest_Doctor]
GO
ALTER TABLE [dbo].[DoctorRequest]  WITH CHECK ADD  CONSTRAINT [FK_DoctorRequest_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[DoctorRequest] CHECK CONSTRAINT [FK_DoctorRequest_DonationCenter]
GO
ALTER TABLE [dbo].[DonationCenter]  WITH CHECK ADD  CONSTRAINT [FK_DonationCenter_Location] FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[DonationCenter] CHECK CONSTRAINT [FK_DonationCenter_Location]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_DonationCenter]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_Location] FOREIGN KEY([location_id])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_Location]
GO
ALTER TABLE [dbo].[Plasma]  WITH CHECK ADD  CONSTRAINT [FK_Plasma_DonationCenter] FOREIGN KEY([id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Plasma] CHECK CONSTRAINT [FK_Plasma_DonationCenter]
GO
ALTER TABLE [dbo].[Plasma]  WITH CHECK ADD  CONSTRAINT [FK_Plasma_Donor] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[Plasma] CHECK CONSTRAINT [FK_Plasma_Donor]
GO
ALTER TABLE [dbo].[RedBloodCell]  WITH CHECK ADD  CONSTRAINT [FK_RedBloodCell_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[RedBloodCell] CHECK CONSTRAINT [FK_RedBloodCell_DonationCenter]
GO
ALTER TABLE [dbo].[RedBloodCell]  WITH CHECK ADD  CONSTRAINT [FK_RedBloodCell_Donor] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[RedBloodCell] CHECK CONSTRAINT [FK_RedBloodCell_Donor]
GO
ALTER TABLE [dbo].[Trobocyte]  WITH CHECK ADD  CONSTRAINT [FK_Trobocyte_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Trobocyte] CHECK CONSTRAINT [FK_Trobocyte_DonationCenter]
GO
ALTER TABLE [dbo].[Trobocyte]  WITH CHECK ADD  CONSTRAINT [FK_Trobocyte_Donor] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[Trobocyte] CHECK CONSTRAINT [FK_Trobocyte_Donor]
GO
USE [master]
GO
ALTER DATABASE [Test] SET  READ_WRITE 
GO
