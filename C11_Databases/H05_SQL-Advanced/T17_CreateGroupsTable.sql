-- Write a SQL statement to create a table Groups. Groups should have			--
-- unique name (use unique constraint). Define primary key and identity column. --

USE TelerikAcademy

CREATE TABLE Groups (
	[GroupID] int NOT NULL IDENTITY,
	[Name] nvarchar(100) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY (GroupID),
	CONSTRAINT AK_Name UNIQUE (Name)
);
