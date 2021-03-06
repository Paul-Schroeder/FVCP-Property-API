USE [FVCPProperty]
GO
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_PropertyAddress_Property')
BEGIN
	PRINT 'Deleting constraint FK_PropertyAddress_Property'
	ALTER TABLE [dbo].[PropertyAddress] DROP CONSTRAINT [FK_PropertyAddress_Property]
END
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Property_Township')
BEGIN
	PRINT 'Deleting constraint FK_Property_Township'
	ALTER TABLE [dbo].[Property] DROP CONSTRAINT [FK_Property_Township]
END
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Property_PropertyClass')
BEGIN
	PRINT 'Deleting constraint FK_Property_PropertyClass'
	ALTER TABLE [dbo].[Property] DROP CONSTRAINT [FK_Property_PropertyClass]
END
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_PropertyTag_Property')
BEGIN
	PRINT 'Deleting constraint FK_PropertyTag_Property'
	ALTER TABLE [dbo].[PropertyTag] DROP CONSTRAINT [FK_PropertyTag_Property]
END
GO

IF OBJECT_ID('dbo.PropertyAddress', 'U') IS NOT NULL 
BEGIN
	PRINT 'Dropping table PropertyAddress'
	DROP TABLE [dbo].[PropertyAddress]
END
GO

IF OBJECT_ID('dbo.PropertyTag', 'U') IS NOT NULL 
BEGIN
	PRINT 'Dropping table PropertyTag'
	DROP TABLE [dbo].[PropertyTag]
END
GO

IF OBJECT_ID('dbo.Property', 'U') IS NOT NULL 
BEGIN
	PRINT 'Dropping table Property'
	DROP TABLE [dbo].[Property]
END
GO

IF OBJECT_ID('dbo.Township', 'U') IS NOT NULL 
BEGIN
	PRINT 'Dropping table Township'
	DROP TABLE [dbo].[Township]
END
GO

IF OBJECT_ID('dbo.PropertyClass', 'U') IS NOT NULL 
BEGIN
	PRINT 'Dropping table PropertyClass'
	DROP TABLE [dbo].[PropertyClass]
END
GO

CREATE TABLE [dbo].[Property](
	[Pin] [varchar](50) NOT NULL,
	[ClassNum] [smallint] NOT NULL,
	[TownNum] [int] NOT NULL,
	[Volume] [smallint] NULL,
	[LocationId] [varchar](50) NOT NULL,
	[TaxCode] [int] NOT NULL,
	[NeighborhoodId] [int] NOT NULL,
	[HomeImpYear] [smallint] NULL,
	[ResType] [varchar](50) NULL,
	[BuildingUse] [varchar](50) NULL,
	[AptCount] [varchar](50) NULL,
	[CommUnits] [char](1) NULL,
	[ExtDesc] [varchar](50) NOT NULL,
	[FullBath] [tinyint] NULL,
	[HalfBath] [tinyint] NULL,
	[BasementDesc] [varchar](50) NULL,
	[AtticDesc] [varchar](50) NULL,
	[AirCond] [tinyint] NULL,
	[Fireplace] [tinyint] NULL,
	[GarageDesc] [varchar](50) NULL,
	[Age] [smallint] NOT NULL,
	[BuildingSF] [int] NULL,
	[LandSF] [int] NULL,
	[TotalAllBuildingSF] [varchar](50) NULL,
	[UnitsTotal] [varchar](50) NULL,
	[SaleDate] [varchar](50) NULL,
	[SaleAmount] [int] NULL,
 CONSTRAINT [PK_Property] PRIMARY KEY CLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[PropertyAddress](
	[Pin] [varchar](50) NOT NULL,
	[HouseNum] [varchar](50) NOT NULL,
	[StreetDir] [varchar](50) NULL,
	[Street] [varchar](50) NOT NULL,
	[Suffix] [varchar](50) NULL,
	[Apt] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[Zip] [smallint] NULL,
 CONSTRAINT [PK_PropertyAddress] PRIMARY KEY CLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[PropertyClass]    Script Date: 2/8/2016 6:58:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PropertyClass](
	[ClassNum] [smallint] NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_PropertyClass] PRIMARY KEY CLUSTERED 
(
	[ClassNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[Township](
	[TownNum] [int] NOT NULL,
	[Name] [varchar](255) NULL,
 CONSTRAINT [PK_Township] PRIMARY KEY NONCLUSTERED 
(
	[TownNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[PropertyTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pin] [varchar](50) NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_PropertyTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [UC_PropertyTag] ON [dbo].[PropertyTag]
(
	[Pin] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO



ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_PropertyClass] FOREIGN KEY([ClassNum])
REFERENCES [dbo].[PropertyClass] ([ClassNum])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_PropertyClass]
GO
ALTER TABLE [dbo].[Property]  WITH CHECK ADD  CONSTRAINT [FK_Property_Township] FOREIGN KEY([TownNum])
REFERENCES [dbo].[Township] ([TownNum])
GO
ALTER TABLE [dbo].[Property] CHECK CONSTRAINT [FK_Property_Township]
GO
ALTER TABLE [dbo].[PropertyAddress]  WITH CHECK ADD  CONSTRAINT [FK_PropertyAddress_Property] FOREIGN KEY([Pin])
REFERENCES [dbo].[Property] ([Pin])
GO
ALTER TABLE [dbo].[PropertyAddress] CHECK CONSTRAINT [FK_PropertyAddress_Property]
GO
ALTER TABLE [dbo].[PropertyTag]  WITH CHECK ADD  CONSTRAINT [FK_PropertyTag_Property] FOREIGN KEY([Pin])
REFERENCES [dbo].[Property] ([Pin])
GO
ALTER TABLE [dbo].[PropertyTag] CHECK CONSTRAINT [FK_PropertyTag_Property]
GO
