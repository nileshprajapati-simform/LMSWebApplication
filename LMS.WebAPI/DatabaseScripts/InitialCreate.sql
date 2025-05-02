-- Idempotent SQL script for InitialCreate migration
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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429034719_InitialCreate'
)
BEGIN
    CREATE TABLE [Courses] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        CONSTRAINT [PK_Courses] PRIMARY KEY ([Id])
    );
END;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429034719_InitialCreate'
)
BEGIN
    CREATE TABLE [Users] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(50) NOT NULL,
        [PasswordHash] nvarchar(max) NOT NULL,
        [Role] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429034719_InitialCreate'
)
BEGIN
    CREATE TABLE [Quizzes] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(100) NOT NULL,
        [CourseId] int NOT NULL,
        CONSTRAINT [PK_Quizzes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Quizzes_Courses_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [Courses] ([Id]) ON DELETE CASCADE
    );
END;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429034719_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Quizzes_CourseId] ON [Quizzes] ([CourseId]);
END;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250429034719_InitialCreate'
)
BEGIN
    -- Insert dummy data into Courses table
    INSERT INTO [Courses] ([Name], [Description]) VALUES
    ('Mathematics', 'Basic Mathematics Course'),
    ('Science', 'Introduction to Science'),
    ('History', 'World History Overview');

    -- Insert dummy data into Users table
    INSERT INTO [Users] ([Username], [PasswordHash], [Role]) VALUES
    ('admin', 'hashed_password_1', 'Admin'),
    ('teacher', 'hashed_password_2', 'Teacher'),
    ('student', 'hashed_password_3', 'Student');

    -- Insert dummy data into Quizzes table
    INSERT INTO [Quizzes] ([Title], [CourseId]) VALUES
    ('Math Quiz 1', 1),
    ('Science Quiz 1', 2),
    ('History Quiz 1', 3);

    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250429034719_InitialCreate', N'9.0.4');
END;
COMMIT;
GO

