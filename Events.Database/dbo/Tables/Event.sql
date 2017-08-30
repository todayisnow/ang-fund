CREATE TABLE [dbo].[Event] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Date]       DATETIME       NOT NULL,
    [Price]      MONEY          NOT NULL,
    [ImageUrl]   NVARCHAR (250) NOT NULL,
    [OnlineUrl]  NVARCHAR (250) NULL,
    [LocationId] INT            NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Event_Location] FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id])
);

