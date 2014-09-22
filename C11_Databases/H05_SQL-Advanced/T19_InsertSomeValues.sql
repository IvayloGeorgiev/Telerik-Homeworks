-- Write SQL statements to insert several records in the Users and Groups tables. --


GO
INSERT INTO [TelerikAcademy].[dbo].[Groups] (Name)
	VALUES 
	('Slitherin'), ('Random guys'), ('Beer Pongers'), ('Daisies')

GO
INSERT INTO [TelerikAcademy].[dbo].[Users] (Username, Pass, FullName, LastLoginTime, GroupID)
	VALUES
	('sashkata', 'offspring', 'Alexander Bashkov', GETDATE(), 3),
	('Karakonjol', 'eatthemall', 'Bobi Turboto', GETDATE(), 1),
	('RandomDude', 'iamsohighdude', 'Nachko Peshov', GETDATE(), 2),
	('SpecificDude', 'hahahahahaha', 'Pesho Nachkov', GETDATE(), 3)