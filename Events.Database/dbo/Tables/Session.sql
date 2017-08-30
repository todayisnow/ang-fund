CREATE TABLE [dbo].[Session] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Presenter]  NVARCHAR (50)  NOT NULL,
    [DurationId] INT            NOT NULL,
    [LevelId]    INT            NOT NULL,
    [Abstract]   NVARCHAR (MAX) NOT NULL,
    [EventId]    INT            NOT NULL,
    CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_Duration] FOREIGN KEY ([DurationId]) REFERENCES [dbo].[Duration] ([Id]),
    CONSTRAINT [FK_Session_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([Id]),
    CONSTRAINT [FK_Session_Level] FOREIGN KEY ([LevelId]) REFERENCES [dbo].[Level] ([Id])
);

