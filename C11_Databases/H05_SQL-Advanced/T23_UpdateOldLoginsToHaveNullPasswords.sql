-- Write a SQL statement that changes the password to NULL for all --
-- users that have not been in the system since 10.03.2010. --

UPDATE [TelerikAcademy].[dbo].[Users]
SET LastLoginTime = '20100309'
WHERE LastLoginTime IS NULL

UPDATE [TelerikAcademy].[dbo].[Users]
SET Pass = NULL
WHERE LastLoginTime <= '20100310'