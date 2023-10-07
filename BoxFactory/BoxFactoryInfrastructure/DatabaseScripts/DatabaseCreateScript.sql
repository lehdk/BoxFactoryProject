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

INSERT INTO [Box] ([Width], [Height], [Length], [Weight], [Color], [Price]) VALUES 
    (42, 420, 69, 7, 9, 199),
    (35, 280, 55, 6, 5, 149),
    (48, 360, 70, 8, 4, 219),
    (30, 240, 45, 5, 3, 99),
    (55, 400, 80, 9, 6, 299),
    (40, 320, 60, 7, 2, 179),
    (42, 420, 69, 7, 9, 199),
    (33, 260, 50, 6, 8, 129),
    (46, 380, 65, 8, 1, 239),
    (38, 300, 58, 7, 7, 159),
    (50, 390, 75, 9, 5, 269),
    (34, 270, 52, 6, 4, 139),
    (52, 410, 72, 8, 3, 229),
    (36, 290, 56, 7, 2, 169),
    (44, 370, 62, 8, 6, 209),
    (32, 250, 48, 6, 9, 119),
    (54, 400, 77, 9, 1, 279),
    (39, 310, 59, 7, 8, 149),
    (47, 390, 67, 8, 7, 219),
    (37, 280, 54, 7, 4, 189),
    (51, 420, 74, 9, 3, 259);


INSERT INTO [Orders] ([Buyer]) VALUES ('Test person');
INSERT INTO [OrderLines] ([OrderId], [BoxId], [Amount], [Price]) VALUES (1, 1, 3, 199)