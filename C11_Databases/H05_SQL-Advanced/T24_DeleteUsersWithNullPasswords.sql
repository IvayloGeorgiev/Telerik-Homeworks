-- Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM [TelerikAcademy].[dbo].[Users]
WHERE Pass IS NULL;