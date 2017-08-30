CREATE TABLE [dbo].[Voter] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [SessionId] INT NOT NULL,
    [UserId]    INT NOT NULL,
    CONSTRAINT [PK_Voter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Voter_Session] FOREIGN KEY ([SessionId]) REFERENCES [dbo].[Session] ([Id]),
    CONSTRAINT [FK_Voter_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

