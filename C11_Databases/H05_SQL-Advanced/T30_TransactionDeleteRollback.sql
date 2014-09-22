-- Start a database transaction, delete all employees from the 'Sales' department along --
-- with all dependent records from the pother tables. At the end rollback the transaction. --


BEGIN TRAN

ALTER TABLE [TelerikAcademy].[dbo].[Departments] DROP [FK_Departments_Employees]

DELETE FROM [TelerikAcademy].[dbo].[Employees]
	WHERE DepartmentID = (SELECT DepartmentID 
		FROM [TelerikAcademy].[dbo].[Departments] 
		WHERE Name = 'Sales')

DELETE FROM [TelerikAcademy].[dbo].[Departments]
	WHERE Name = 'Sales'
ROLLBACK TRAN

