-- Write SQL statements to insert in the Users table the names of all employees from the Employees table. --
-- Combine the first and last names as a full name. For username use the first letter of the first name + --
-- the last name (in lowercase). Use the same for the password, and NULL for last login time. --


INSERT INTO [TelerikAcademy].[dbo].[Users] (Username, Pass, FullName, LastLoginTime, GroupID)
	SELECT (LOWER(e.FirstName + '.' + e.LastName)) as Username,
	(LOWER(e.FirstName + '.' + e.LastName)) as Pass,
	(e.FirstName + ' ' + e.LastName) as FullName,
	NULL as LastLoginTime,
	NULL as GroupID
	FROM [TelerikAcademy].[dbo].[Employees] e