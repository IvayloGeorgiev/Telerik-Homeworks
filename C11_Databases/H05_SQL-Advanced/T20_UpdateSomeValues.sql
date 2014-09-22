-- Write SQL statements to update some of the records in the Users and Groups tables. --

UPDATE [TelerikAcademy].[dbo].[Users]
SET GroupID = 1, LastLoginTime = GETDATE()
WHERE GroupID = 3

UPDATE [TelerikAcademy].[dbo].[Users]
SET GroupID = 2, LastLoginTime = GETDATE()
WHERE GroupID > 4;