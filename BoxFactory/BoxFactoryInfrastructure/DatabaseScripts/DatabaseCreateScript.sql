USE [BoxFactory]

DROP TABLE IF EXISTS [OrderLines]
DROP TABLE IF EXISTS [Orders]
DROP TABLE IF EXISTS [Box]

CREATE TABLE [Box] (
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [Width] SMALLINT NOT NULL,
    [Height] SMALLINT NOT NULL,
    [Length] SMALLINT NOT NULL,
    [Weight] INT NOT NULL,
    [Color] TINYINT NOT NULL,
    [Price] FLOAT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);

CREATE TABLE [Orders] (
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [Buyer] NVARCHAR(100) NOT NULL,
    [OrderedAt] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [IsShipped] BIT NOT NULL DEFAULT 0
);

CREATE TABLE [OrderLines] (
    [Id] INT IDENTITY(1, 1) PRIMARY KEY,
    [OrderId] INT FOREIGN KEY REFERENCES [Orders]([Id]) ON DELETE CASCADE,
    [BoxId] INT FOREIGN KEY REFERENCES [Box]([Id]),
    [Amount] INT NOT NULL,
    [Price] FLOAT NOT NULL
);

INSERT INTO [Box] ([Width], [Height], [Length], [Weight], [Color], [Price]) VALUES (42, 420, 69, 7, 9, 199);

INSERT INTO [Orders] ([Buyer]) VALUES ('Test person');
INSERT INTO [OrderLines] ([OrderId], [BoxId], [Amount], [Price]) VALUES (1, 1, 3, 199)