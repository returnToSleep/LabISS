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
/****** Object:  Database [Blood]    Script Date: 06-May-18 8:02:59 PM ******/
CREATE DATABASE [Blood]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blood', FILENAME = N'D:\Blood.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blood_log', FILENAME = N'D:\Blood_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Blood] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blood].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blood] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blood] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blood] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blood] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blood] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blood] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blood] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blood] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blood] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blood] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blood] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blood] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blood] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blood] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blood] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blood] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blood] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blood] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blood] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blood] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blood] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blood] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blood] SET RECOVERY FULL 
GO
ALTER DATABASE [Blood] SET  MULTI_USER 
GO
ALTER DATABASE [Blood] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blood] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blood] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blood] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blood] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Blood', N'ON'
GO
ALTER DATABASE [Blood] SET QUERY_STORE = OFF
GO
USE [Blood]
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
USE [Blood]
GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 06-May-18 8:03:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[speciality] [varchar](50) NOT NULL,
	[hospital] [varchar](50) NOT NULL,
	[latitude] [real] NOT NULL,
	[longitude] [real] NOT NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorRequest]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorRequest](
	[doctor_id] [int] NOT NULL,
	[donationCenter_id] [varchar](50) NOT NULL,
	[priority] [int] NOT NULL,
	[patientCnp] [varchar](50) NOT NULL,
	[requestString] [varchar](50) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[doctor_name] [varchar](50) NOT NULL,
	[hospital] [varchar](50) NOT NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_DoctorRequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donation]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[donor_cnp] [varchar](50) NULL,
	[quantity] [float] NULL,
	[pulse] [int] NULL,
	[bloodPressure] [int] NULL,
	[donationDate] [date] NULL,
	[trombocityQuantity] [float] NULL,
	[plasmaQuantity] [float] NULL,
	[trombocyteQuantity] [float] NULL,
 CONSTRAINT [PK__Donation__3213E83FEF89A840] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationCenter]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonationCenter](
	[id] [varchar](50) NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_DonationCenter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[name] [varchar](50) NOT NULL,
	[cnp] [varchar](50) NOT NULL,
	[birthdate] [date] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[isPending] [bit] NOT NULL,
	[donationCenter_id] [varchar](50) NULL,
	[latitude] [real] NOT NULL,
	[longitude] [real] NOT NULL,
	[bloodType] [varchar](10) NULL,
	[rh] [bit] NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[cnp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[addressString] [varchar](50) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[latitude] [real] NOT NULL,
	[longitude] [real] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogInfo]    Script Date: 06-May-18 8:03:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogInfo](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[intId] [int] NULL,
	[type] [varchar](50) NOT NULL,
	[varId] [varchar](50) NULL,
 CONSTRAINT [PK_LogInfo_1] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plasma]    Script Date: 06-May-18 8:03:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plasma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[antibody] [varchar](2) NOT NULL,
	[donationCenter_id] [varchar](50) NOT NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NOT NULL,
	[donationDate] [date] NOT NULL,
	[doctor_id] [int] NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Plasma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RedBloodCell]    Script Date: 06-May-18 8:03:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RedBloodCell](
	[antigen] [varchar](2) NOT NULL,
	[rh] [bit] NOT NULL,
	[donationCenter_id] [varchar](50) NOT NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[donationDate] [date] NOT NULL,
	[doctor_id] [int] NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_RedBloodCell] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trombocyte]    Script Date: 06-May-18 8:03:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trombocyte](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[donationCenter_id] [varchar](50) NOT NULL,
	[donor_cnp] [varchar](50) NULL,
	[ammount] [float] NOT NULL,
	[donationDate] [date] NOT NULL,
	[doctor_id] [int] NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Trobocyte] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DoctorRequest]  WITH CHECK ADD  CONSTRAINT [FK_DoctorRequest_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoctorRequest] CHECK CONSTRAINT [FK_DoctorRequest_Doctor]
GO
ALTER TABLE [dbo].[DoctorRequest]  WITH CHECK ADD  CONSTRAINT [FK_DoctorRequest_DonationCenter1] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DoctorRequest] CHECK CONSTRAINT [FK_DoctorRequest_DonationCenter1]
GO
ALTER TABLE [dbo].[Donation]  WITH CHECK ADD  CONSTRAINT [FK__Donation__donor___3F466844] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[Donation] CHECK CONSTRAINT [FK__Donation__donor___3F466844]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [FK_Donor_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [FK_Donor_DonationCenter]
GO
ALTER TABLE [dbo].[Plasma]  WITH CHECK ADD  CONSTRAINT [FK_Plasma_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Plasma] CHECK CONSTRAINT [FK_Plasma_Doctor]
GO
ALTER TABLE [dbo].[Plasma]  WITH CHECK ADD  CONSTRAINT [FK_Plasma_DonationCenter1] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Plasma] CHECK CONSTRAINT [FK_Plasma_DonationCenter1]
GO
ALTER TABLE [dbo].[Plasma]  WITH CHECK ADD  CONSTRAINT [FK_Plasma_Donor] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[Plasma] CHECK CONSTRAINT [FK_Plasma_Donor]
GO
ALTER TABLE [dbo].[RedBloodCell]  WITH CHECK ADD  CONSTRAINT [FK_RedBloodCell_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RedBloodCell] CHECK CONSTRAINT [FK_RedBloodCell_Doctor]
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
ALTER TABLE [dbo].[Trombocyte]  WITH CHECK ADD  CONSTRAINT [FK_Trobocyte_DonationCenter] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenter] ([id])
GO
ALTER TABLE [dbo].[Trombocyte] CHECK CONSTRAINT [FK_Trobocyte_DonationCenter]
GO
ALTER TABLE [dbo].[Trombocyte]  WITH CHECK ADD  CONSTRAINT [FK_Trobocyte_Donor] FOREIGN KEY([donor_cnp])
REFERENCES [dbo].[Donor] ([cnp])
GO
ALTER TABLE [dbo].[Trombocyte] CHECK CONSTRAINT [FK_Trobocyte_Donor]
GO
ALTER TABLE [dbo].[Trombocyte]  WITH CHECK ADD  CONSTRAINT [FK_Trombocyte_Doctor] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctor] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trombocyte] CHECK CONSTRAINT [FK_Trombocyte_Doctor]
GO
USE [master]
GO
ALTER DATABASE [Blood] SET  READ_WRITE 
GO