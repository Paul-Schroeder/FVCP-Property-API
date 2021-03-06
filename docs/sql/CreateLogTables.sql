-- 'CREATE TABLE LogMessageType'
GO
IF OBJECT_ID('dbo.LogMessageType', 'U') IS NOT NULL
BEGIN
	IF EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'dbo.FK_Log_LogMessageType') AND parent_object_id = OBJECT_ID(N'dbo.Log'))
	BEGIN
		ALTER TABLE [dbo].[Log] DROP CONSTRAINT [FK_Log_LogMessageType]
	END
	DROP TABLE [dbo].[LogMessageType]
END
CREATE TABLE [dbo].[LogMessageType](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](1000) NULL,
 CONSTRAINT [PK_LogMessageType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


-- 'Populate [LogMessageType] table.'
GO
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (100, 'Unknown', 'Used when insert does not provide a value.')
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (101, 'Exception_Application', 'Application Exception.')
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (102, 'Exception_Database', 'Exception while accessing database; usually in a repository class.')
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (103, 'Exception_General', 'General exception.')
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (104, 'Exception_Unhandled', 'An unhandled exception occurred and was caught by the last chance global error filter.')
INSERT INTO [dbo].[LogMessageType] ([Id],[Name],[Description]) VALUES (400, 'Unauthorized', 'Security exception.')


-- 'CREATE TABLE Log'
GO
IF OBJECT_ID('dbo.Log', 'U') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Log]
END
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogGuid] uniqueidentifier NOT NULL CONSTRAINT DF_Log_LogGuid DEFAULT(NEWID()), -- WITH VALUES
	[Created] [datetimeoffset](7) NOT NULL CONSTRAINT DF_Log_Created DEFAULT (getdate()),
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[LogMessageTypeID] [int] NOT NULL,
	[HostName] [varchar](255) NOT NULL,
	[ClientIPAddress] [varchar](255) NULL,
	[MethodName] [varchar](255) NULL,
	[UserName] [nvarchar](256) NULL,
	[Message] [varchar](4000) NULL,
	[Exception] [varchar](2000) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[Log]  WITH CHECK ADD  CONSTRAINT [FK_Log_LogMessageType] FOREIGN KEY([LogMessageTypeID])
REFERENCES [dbo].[LogMessageType] ([Id])
GO

ALTER TABLE [dbo].[Log] CHECK CONSTRAINT [FK_Log_LogMessageType]
GO


-- Log_Add stored procedure
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'Log_Add')
   exec('CREATE PROCEDURE [dbo].[Log_Add] AS BEGIN SET NOCOUNT ON; END')
GO
/****
/******************************************************************************
*
* Name:			Log_Add
* Purpose:		Log a message or exception
* Caveats:		User must supply a custom LogMessageTypeId that corresponds to a record in the LogMessageType table.
* Created By:	Paul Schroeder
* Created Date:	January 01, 20xx
* Modifications: 
* Notes:		
* Test Values:	
* 
DECLARE @RC int
DECLARE @Date datetime
DECLARE @Thread varchar(255)
DECLARE @Level varchar(50)
DECLARE @Logger varchar(255)
DECLARE @LogMessageTypeID int
DECLARE @HostName varchar(255)
DECLARE @ClientIPAddress varchar(255)
DECLARE @MethodName [varchar](255)
DECLARE @UserName [varchar](255)
DECLARE @Message varchar(4000)
DECLARE @Exception varchar(2000)
DECLARE @LogGuid nvarchar(36)
DECLARE @LogGuidConvert uniqueidentifier = newid()

SET @Date = getdate()
SET @Thread = 'test thread'
SET @Level = 'test level'
SET @Logger = 'test logger'
SET @LogMessageTypeID = 100
SET @HostName = 'test hostname'
SET @ClientIPAddress = 'test clientip'
SET @MethodName = 'test methodname'
SET @UserName = 'test username'
SET @Message = 'test message'
SET @Exception = 'test exception'
SET @LogGuid = CONVERT(NVARCHAR(36), @LogGuidConvert)
print @LogGuid
EXECUTE @RC = [dbo].[Log_Add] 
   @Date, @Thread, @Level, @Logger, @LogMessageTypeID, @HostName, @ClientIPAddress, @MethodName, @UserName, @Message, @Exception, @LogGuid
GO
******************************************************************************/
*/
ALTER PROCEDURE [dbo].[Log_Add]  
            @Date datetime
           ,@Thread varchar(255)
           ,@Level varchar(50)
           ,@Logger varchar(255)
           ,@LogMessageTypeID int
           ,@HostName varchar(255)
           ,@ClientIPAddress varchar(255)
           ,@MethodName varchar(255)
           ,@UserName varchar(255)
           ,@Message varchar(4000)
           ,@Exception varchar(2000)
		   ,@LogGuid nvarchar(36)
AS  
BEGIN 
SET NOCOUNT ON;

declare @LogGuidConvert uniqueidentifier 

if(@LogGuid is null)
	SET @LogGuidConvert = NEWID()
	
if(@LogGuid is not null)
 SET @LogGuidConvert = CONVERT(UNIQUEIDENTIFIER, @LogGuid)
 
-- Disallow NULL @LogMessageTypeID
IF (@LogMessageTypeID IS NULL)
	SET @LogMessageTypeID = 0 -- Unknown

-- Truncate any excessively long varchars.
IF (LEN(@MethodName) > 255)
	SET @MethodName = LEFT(@Exception, 255)

IF (LEN(@UserName) > 255)
	SET @UserName = LEFT(@UserName, 255)

IF (LEN(@Message) > 4000)
	SET @Message = LEFT(@Message, 4000)

IF (LEN(@Exception) > 2000)
	SET @Exception = LEFT(@Exception, 2000) 

INSERT INTO [dbo].[Log]
           ([Created]
           ,[Thread]
           ,[Level]
           ,[Logger]
           ,[LogMessageTypeID]
           ,[HostName]
           ,[ClientIPAddress]
           ,[MethodName]
           ,[UserName]
           ,[Message]
           ,[Exception]
		   ,[LogGuid]
		   )
     VALUES
           (@Date
           ,@Thread
           ,@Level
           ,@Logger
           ,@LogMessageTypeID
           ,@HostName
           ,@ClientIPAddress
           ,@MethodName
           ,@UserName
           ,@Message
           ,@Exception
		   ,@LogGuidConvert
		   )

END
