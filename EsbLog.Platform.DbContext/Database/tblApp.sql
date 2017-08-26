CREATE TABLE [dbo].[tblApp]
(
    [Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [AppName] NVARCHAR(100) NULL, 
    [Code] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(100) NULL, 
    [PublicKey] NVARCHAR(50) NOT NULL, 
    [Creation] DATETIME NOT NULL DEFAULT GETDATE()
)
