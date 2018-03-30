/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [BloodDonation]
GO
/****** Object:  Table [dbo].[Blood]    Script Date: 3/30/2018 9:15:49 AM ******/
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
	[donorEmail] [varchar](50) NOT NULL,
	[donationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Blood] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 3/30/2018 9:15:49 AM ******/
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
	[request_id] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationCenters]    Script Date: 3/30/2018 9:15:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonationCenters](
	[id] [int] NOT NULL,
	[location_id] [int] NOT NULL,
	[pendingDoctorRequets] [int] NOT NULL,
	[pendingDonorRequests] [int] NOT NULL,
 CONSTRAINT [PK_DonationCenters] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donations]    Script Date: 3/30/2018 9:15:49 AM ******/
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
/****** Object:  Table [dbo].[Donors]    Script Date: 3/30/2018 9:15:49 AM ******/
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
/****** Object:  Table [dbo].[Locations]    Script Date: 3/30/2018 9:15:49 AM ******/
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
/****** Object:  Table [dbo].[Requests]    Script Date: 3/30/2018 9:15:49 AM ******/
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
