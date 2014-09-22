-- Write a SQL query to find the names and salaries of the employees that have --
-- a salary that is up to 10% higher than the minimal salary for the company.  --

SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) as Employee, 
e.Salary
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.Salary <= 
	(SELECT MIN(Salary) FROM [TelerikAcademy].[dbo].[Employees]) * 1.1
ORDER BY e.Salary;
