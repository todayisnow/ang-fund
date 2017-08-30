CREATE TABLE [dbo].[Duration] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [NameAr] NVARCHAR (50) NOT NULL,
    [NameEn] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Duration] PRIMARY KEY CLUSTERED ([Id] ASC)
);

