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

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Username');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [Username] nvarchar(max) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Specialization');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Users] ALTER COLUMN [Specialization] nvarchar(max) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Sex');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Users] ALTER COLUMN [Sex] nvarchar(max) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'School');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Users] ALTER COLUMN [School] nvarchar(max) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Portestement');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Users] ALTER COLUMN [Portestement] nvarchar(max) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] int NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Image');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Users] ALTER COLUMN [Image] nvarchar(max) NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(max) NULL;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'DateOfBirth');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Users] ALTER COLUMN [DateOfBirth] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220814125416_sencond-Table', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [Password] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220816092510_AddPasswordForUser', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Password');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Users] ALTER COLUMN [Password] nvarchar(max) NOT NULL;
ALTER TABLE [Users] ADD DEFAULT N'' FOR [Password];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220816092855_AddPasswordForUserNotNull', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Username');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Users] ALTER COLUMN [Username] nvarchar(max) NOT NULL;
ALTER TABLE [Users] ADD DEFAULT N'' FOR [Username];
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
ALTER TABLE [Users] ADD DEFAULT N'' FOR [Email];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220816143808_NotNullEmailAndUsernameUser', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Users] ADD [UserType] int NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220817035911_AddUserTypeToUser', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [StoryRegisters] ADD [SubjectcID] int NULL;
GO

ALTER TABLE [StoryRegisters] ADD [SubjectcName] int NULL;
GO

ALTER TABLE [StoryRegisters] ADD [TermID] int NULL;
GO

ALTER TABLE [StoryRegisters] ADD [TermName] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220817081458_StoryRegister', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StoryRegisters]') AND [c].[name] = N'SubjectcName');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [StoryRegisters] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [StoryRegisters] ALTER COLUMN [SubjectcName] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220817082012_StoryRegister2', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StoryRegisters]') AND [c].[name] = N'TermName');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [StoryRegisters] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [StoryRegisters] ALTER COLUMN [TermName] nvarchar(max) NOT NULL;
ALTER TABLE [StoryRegisters] ADD DEFAULT N'' FOR [TermName];
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StoryRegisters]') AND [c].[name] = N'TermID');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [StoryRegisters] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [StoryRegisters] ALTER COLUMN [TermID] int NOT NULL;
ALTER TABLE [StoryRegisters] ADD DEFAULT 0 FOR [TermID];
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StoryRegisters]') AND [c].[name] = N'SubjectcName');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [StoryRegisters] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [StoryRegisters] ALTER COLUMN [SubjectcName] nvarchar(max) NOT NULL;
ALTER TABLE [StoryRegisters] ADD DEFAULT N'' FOR [SubjectcName];
GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[StoryRegisters]') AND [c].[name] = N'SubjectcID');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [StoryRegisters] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [StoryRegisters] ALTER COLUMN [SubjectcID] int NOT NULL;
ALTER TABLE [StoryRegisters] ADD DEFAULT 0 FOR [SubjectcID];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220817082236_StoryRegister3', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [StoryRegisters];
GO

CREATE TABLE [HistoryRegisterTerms] (
    [StoryRegisterID] int NOT NULL IDENTITY,
    [RoomExamID] int NOT NULL,
    [UserID] int NOT NULL,
    [SubjectcID] int NOT NULL,
    [SubjectcName] nvarchar(max) NOT NULL,
    [TermID] int NOT NULL,
    [TermName] nvarchar(max) NOT NULL,
    [PaymentMethod] nvarchar(max) NOT NULL,
    [IsPayment] bit NOT NULL,
    [StoryRegisteryDay] datetime2 NOT NULL,
    [Status] bit NOT NULL,
    [IsDelete] bit NOT NULL,
    [UpdatedTime] datetime2 NULL,
    [CreatedTime] datetime2 NULL,
    CONSTRAINT [PK_HistoryRegisterTerms] PRIMARY KEY ([StoryRegisterID])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220819092231_RenameStory', N'6.0.8');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220821043025_changeFullDB', N'6.0.8');
GO

COMMIT;
GO

