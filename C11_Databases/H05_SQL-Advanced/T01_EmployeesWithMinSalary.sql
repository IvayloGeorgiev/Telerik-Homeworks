-- Write a SQL query to find the names and salaries of the employees that take --
-- the minimal salary in the company. Use a nested SELECT statement.		   --

SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) as Employee, 
e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary = 
	(SELECT MIN(Salary) FROM [TelerikAcademy].[dbo].[Employees]);
