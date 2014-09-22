-- Write a SQL statement to create a table Users. Users should have username,	  --
-- password, full name and last login time. Choose appropriate data types for	  --
-- the table fields. Define a primary key column with a primary key constraint.   --
-- Define the primary key column as identity to facilitate inserting records.	  --
-- Define unique constraint to avoid repeating usernames.						  --
-- Define a check constraint to ensure the password is at least 5 characters long --

USE TelerikAcademy

CREATE TABLE Users (
	[UserID] int NOT NULL IDENTITY,
	[Username] nvarchar(100) NOT NULL,
	[Pass] nvarchar(100),
	[FullName] nvarchar(100),
	[LastLoginTime] date,
	CONSTRAINT PK_Users PRIMARY KEY (UserID),
	CONSTRAINT AK_Username UNIQUE(Username),
	CONSTRAINT CHK_Pass_Length CHECK (LEN(Pass) > 5)
);