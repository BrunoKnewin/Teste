BEGIN TRANSACTION;
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210430061205_update_user_table', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [CityBorder] DROP CONSTRAINT [FK_CityBorder_City_CityBorderAId];
GO

ALTER TABLE [CityBorder] DROP CONSTRAINT [FK_CityBorder_City_CityBorderBId];
GO

ALTER TABLE [CityBorder] DROP CONSTRAINT [PK_CityBorder];
GO

ALTER TABLE [City] DROP CONSTRAINT [PK_City];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[City]') AND [c].[name] = N'DateTime');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [City] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [City] DROP COLUMN [DateTime];
GO

EXEC sp_rename N'[CityBorder]', N'CitiesBorder';
GO

EXEC sp_rename N'[City]', N'Cities';
GO

EXEC sp_rename N'[CitiesBorder].[IX_CityBorder_CityBorderBId]', N'IX_CitiesBorder_CityBorderBId', N'INDEX';
GO

EXEC sp_rename N'[CitiesBorder].[IX_CityBorder_CityBorderAId]', N'IX_CitiesBorder_CityBorderAId', N'INDEX';
GO

ALTER TABLE [CitiesBorder] ADD CONSTRAINT [PK_CitiesBorder] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Cities] ADD CONSTRAINT [PK_Cities] PRIMARY KEY ([Id]);
GO

ALTER TABLE [CitiesBorder] ADD CONSTRAINT [FK_CitiesBorder_Cities_CityBorderAId] FOREIGN KEY ([CityBorderAId]) REFERENCES [Cities] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [CitiesBorder] ADD CONSTRAINT [FK_CitiesBorder_Cities_CityBorderBId] FOREIGN KEY ([CityBorderBId]) REFERENCES [Cities] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210430142746_update_user_parm_tables_name', N'5.0.5');
GO

COMMIT;
GO

