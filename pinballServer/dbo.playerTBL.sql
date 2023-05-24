CREATE TABLE [dbo].[playerTBL] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [username]  NVARCHAR (50) NOT NULL,
    [password]  NVARCHAR (50) NOT NULL,
    [firstName] NVARCHAR (50) NOT NULL,
    [lastName]  NVARCHAR (50) NOT NULL,
    [regDate]   DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

