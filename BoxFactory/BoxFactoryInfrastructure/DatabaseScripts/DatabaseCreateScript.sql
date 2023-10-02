USE [BoxFactory]

DROP TABLE IF EXISTS [Box]

CREATE TABLE [Box] (
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [Width] SMALLINT NOT NULL,
    [Height] SMALLINT NOT NULL,
    [Length] SMALLINT NOT NULL,
    [Weight] INT NOT NULL,
    [Color] TINYINT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);

INSERT INTO [Box] ([Width], [Height], [Length], [Weight], [Color]) VALUES (42, 420, 69, 7, 9);