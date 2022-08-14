IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [RoomExams] (
    [RoomExamID] int NOT NULL IDENTITY,
    [SubjectcID] int NOT NULL,
    [RoomExamName] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_RoomExams] PRIMARY KEY ([RoomExamID])
);
GO

CREATE TABLE [StoryRegisters] (
    [StoryRegisterID] int NOT NULL IDENTITY,
    [RoomExamID] int NOT NULL,
    [UserID] int NOT NULL,
    [PaymentMethod] nvarchar(max) NOT NULL,
    [IsPayment] bit NOT NULL,
    [StoryRegisteryDay] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_StoryRegisters] PRIMARY KEY ([StoryRegisterID])
);
GO

CREATE TABLE [Subjectcs] (
    [SubjectcID] int NOT NULL IDENTITY,
    [TermID] int NOT NULL,
    [SubjectcName] nvarchar(max) NOT NULL,
    [SubjectcDate] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_Subjectcs] PRIMARY KEY ([SubjectcID])
);
GO

CREATE TABLE [Terms] (
    [TermID] int NOT NULL IDENTITY,
    [TermName] nvarchar(max) NOT NULL,
    [TermDateTime] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_Terms] PRIMARY KEY ([TermID])
);
GO

CREATE TABLE [Users] (
    [UserID] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Username] nvarchar(max) NOT NULL,
    [Portestement] nvarchar(max) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Specialization] nvarchar(max) NOT NULL,
    [School] nvarchar(max) NOT NULL,
    [PhoneNumber] int NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Sex] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220814125149_FisrtTable', N'6.0.8');
GO

COMMIT;
GO

