IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [IdCompany] bigint NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [EstablishmentYear] int NOT NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([IdCompany])
);

GO

CREATE TABLE [Employees] (
    [IdEmployee] bigint NOT NULL IDENTITY,
    [IdCompany] bigint NOT NULL,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [JobTitle] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([IdEmployee]),
    CONSTRAINT [FK_Employees_Companies_IdCompany] FOREIGN KEY ([IdCompany]) REFERENCES [Companies] ([IdCompany]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Employees_IdCompany] ON [Employees] ([IdCompany]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201109183544_InitialMigration', N'3.1.9');

GO

