IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Task] (
    [Id] uniqueidentifier NOT NULL,
    [Title] varchar(100) NOT NULL,
    [Completed] bit NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    [LastUpdate] datetime2 NOT NULL,
    [ConclusionDate] datetime2 NULL,
    [ExclusionDate] datetime2 NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20181010030740_v01', N'2.1.4-rtm-31024');

GO

