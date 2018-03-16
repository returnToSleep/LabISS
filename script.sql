/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [master]
GO
/****** Object:  Database [BloodDonation]    Script Date: 3/16/2018 12:36:08 PM ******/
CREATE DATABASE [BloodDonation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloodDonation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BloodDonation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BloodDonation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BloodDonation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BloodDonation] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloodDonation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloodDonation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloodDonation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloodDonation] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloodDonation] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BloodDonation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloodDonation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloodDonation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloodDonation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloodDonation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloodDonation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloodDonation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloodDonation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloodDonation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BloodDonation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloodDonation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloodDonation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloodDonation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloodDonation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloodDonation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloodDonation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloodDonation] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BloodDonation] SET  MULTI_USER 
GO
ALTER DATABASE [BloodDonation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloodDonation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloodDonation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloodDonation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BloodDonation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BloodDonation] SET QUERY_STORE = OFF
GO
USE [BloodDonation]
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
USE [BloodDonation]
GO
/****** Object:  Table [dbo].[Blood]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blood](
	[id] [int] NOT NULL,
	[rH] [bit] NOT NULL,
	[type] [varchar](5) NOT NULL,
	[redBloodCells_id] [int] NOT NULL,
	[trombocytes_id] [int] NOT NULL,
	[plasma_id] [int] NOT NULL,
	[donationCenter_id] [int] NOT NULL,
 CONSTRAINT [PK_Blood] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BloodComponents]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodComponents](
	[id] [int] NOT NULL,
	[donationDate] [datetime] NOT NULL,
	[amount] [float] NOT NULL,
	[donorEmail] [varchar](50) NOT NULL,
	[componentType] [varchar](50) NOT NULL,
	[type] [varchar](50) NULL,
	[rH] [varchar](50) NULL,
 CONSTRAINT [PK_BloodComponents] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[speciality] [varchar](50) NOT NULL,
	[hospital] [varchar](50) NOT NULL,
	[location_id] [int] NOT NULL,
	[request_id] [nchar](10) NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationCenters]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonationCenters](
	[id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
	[pendingDoctorRequets] [int] NOT NULL,
	[pendingDonorRequests] [int] NULL,
 CONSTRAINT [PK_DonationCenters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donations]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donations](
	[id] [int] NOT NULL,
	[Donors_id] [int] NOT NULL,
	[DonationCenter_id] [int] NOT NULL,
 CONSTRAINT [PK_Donations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donors]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donors](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[cnp] [varchar](13) NOT NULL,
	[birthdate] [datetime] NOT NULL,
	[address_id] [int] NOT NULL,
	[residence_id] [int] NOT NULL,
	[blood_id] [int] NOT NULL,
	[donationDate] [datetime] NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Donors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[id] [int] NOT NULL,
	[address] [varchar](50) NOT NULL,
	[country] [varchar](50) NOT NULL,
	[city] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 3/16/2018 12:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[id] [int] NOT NULL,
	[description] [varchar](50) NOT NULL,
	[doctor_id] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blood]  WITH CHECK ADD  CONSTRAINT [FK_Blood_BloodComponents] FOREIGN KEY([redBloodCells_id])
REFERENCES [dbo].[BloodComponents] ([id])
GO
ALTER TABLE [dbo].[Blood] CHECK CONSTRAINT [FK_Blood_BloodComponents]
GO
ALTER TABLE [dbo].[Blood]  WITH CHECK ADD  CONSTRAINT [FK_Blood_BloodComponents1] FOREIGN KEY([trombocytes_id])
REFERENCES [dbo].[BloodComponents] ([id])
GO
ALTER TABLE [dbo].[Blood] CHECK CONSTRAINT [FK_Blood_BloodComponents1]
GO
ALTER TABLE [dbo].[Blood]  WITH CHECK ADD  CONSTRAINT [FK_Blood_BloodComponents2] FOREIGN KEY([plasma_id])
REFERENCES [dbo].[BloodComponents] ([id])
GO
ALTER TABLE [dbo].[Blood] CHECK CONSTRAINT [FK_Blood_BloodComponents2]
GO
ALTER TABLE [dbo].[Blood]  WITH CHECK ADD  CONSTRAINT [FK_Blood_DonationCenters] FOREIGN KEY([donationCenter_id])
REFERENCES [dbo].[DonationCenters] ([id])
GO
ALTER TABLE [dbo].[Blood] CHECK CONSTRAINT [FK_Blood_DonationCenters]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Locations] FOREIGN KEY([location_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Locations]
GO
ALTER TABLE [dbo].[DonationCenters]  WITH CHECK ADD  CONSTRAINT [FK_DonationCenters_Locations] FOREIGN KEY([location_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[DonationCenters] CHECK CONSTRAINT [FK_DonationCenters_Locations]
GO
ALTER TABLE [dbo].[DonationCenters]  WITH CHECK ADD  CONSTRAINT [FK_DonationCenters_Requests] FOREIGN KEY([pendingDoctorRequets])
REFERENCES [dbo].[Requests] ([id])
GO
ALTER TABLE [dbo].[DonationCenters] CHECK CONSTRAINT [FK_DonationCenters_Requests]
GO
ALTER TABLE [dbo].[Donations]  WITH CHECK ADD  CONSTRAINT [FK_Donations_DonationCenters] FOREIGN KEY([DonationCenter_id])
REFERENCES [dbo].[DonationCenters] ([id])
GO
ALTER TABLE [dbo].[Donations] CHECK CONSTRAINT [FK_Donations_DonationCenters]
GO
ALTER TABLE [dbo].[Donations]  WITH CHECK ADD  CONSTRAINT [FK_Donations_Donors] FOREIGN KEY([Donors_id])
REFERENCES [dbo].[Donors] ([id])
GO
ALTER TABLE [dbo].[Donations] CHECK CONSTRAINT [FK_Donations_Donors]
GO
ALTER TABLE [dbo].[Donors]  WITH CHECK ADD  CONSTRAINT [FK_Donors_Blood] FOREIGN KEY([blood_id])
REFERENCES [dbo].[Blood] ([id])
GO
ALTER TABLE [dbo].[Donors] CHECK CONSTRAINT [FK_Donors_Blood]
GO
ALTER TABLE [dbo].[Donors]  WITH CHECK ADD  CONSTRAINT [FK_Donors_Locations] FOREIGN KEY([address_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[Donors] CHECK CONSTRAINT [FK_Donors_Locations]
GO
ALTER TABLE [dbo].[Donors]  WITH CHECK ADD  CONSTRAINT [FK_Donors_Locations1] FOREIGN KEY([residence_id])
REFERENCES [dbo].[Locations] ([id])
GO
ALTER TABLE [dbo].[Donors] CHECK CONSTRAINT [FK_Donors_Locations1]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Doctors] FOREIGN KEY([doctor_id])
REFERENCES [dbo].[Doctors] ([id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Doctors]
GO
USE [master]
GO
ALTER DATABASE [BloodDonation] SET  READ_WRITE 
GO
