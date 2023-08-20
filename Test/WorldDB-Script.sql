/*
Created by: Gursharan Tatla
*/

USE [WorldDBFinal]
GO
/****** Object:  Table [dbo].[City]    Script Date: 12-Nov-21 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](100) NOT NULL,
	[IsCapital] [bit] NULL,
	[Population] [nvarchar](100) NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Continent]    Script Date: 12-Nov-21 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[ContinentName] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 12-Nov-21 6:11:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
	[Language] [nvarchar](100) NULL,
	[Currency] [nvarchar](100) NULL,
	[ContinentId] [int] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (1, N'New Delhi', 1, N'31 million', 1)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (2, N'Mumbai', 0, N'20 million', 1)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (3, N'Tokyo', 1, N'14 million', 2)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (4, N'Osaka', 0, N'19 million', 2)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (5, N'Hiroshima', 0, N'2 million', 2)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (6, N'Islamabad', 1, N'1 million', 3)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (7, N'Lahore', 0, N'13 million', 3)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (8, N'Karachi', 0, N'16 million', 3)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (9, N'Tehran', 1, N'9 million', 4)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (10, N'London', 1, N'9 million', 5)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (11, N'Manchester', 0, N'2 million', 5)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (12, N'Paris', 1, N'2 million', 6)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (13, N'Marseille', 0, N'1 million', 6)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (14, N'Berlin', 1, N'3 million', 7)
INSERT [dbo].[City] ([CityId], [CityName], [IsCapital], [Population], [CountryId]) VALUES (15, N'Munich', 0, N'1 million', 7)
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([ContinentId], [ContinentName]) VALUES (1, N'Asia')
INSERT [dbo].[Continent] ([ContinentId], [ContinentName]) VALUES (2, N'Europe')
SET IDENTITY_INSERT [dbo].[Continent] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (1, N'India', N'Hindi', N'Rupee', 1)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (2, N'Japan', N'Japanese', N'Yen', 1)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (3, N'Pakistan', N'Urdu', N'Pakistani Rupee', 1)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (4, N'Iran', N'Persian', N'Iranian Rial', 1)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (5, N'England', N'English', N'Pound', 2)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (6, N'France', N'French', N'Euro', 2)
INSERT [dbo].[Country] ([CountryId], [CountryName], [Language], [Currency], [ContinentId]) VALUES (7, N'Germany', N'German', N'Euro', 2)
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_Country]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continent] ([ContinentId])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
