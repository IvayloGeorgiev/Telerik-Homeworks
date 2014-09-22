-- Write a SQL query to find the full name, salary and department of the employees  --
-- that take the minimal salary in their department. Use a nested SELECT statement. --

SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) as Employee, 
e.Salary,
d.Name
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
		(SELECT MIN(Salary) FROM [TelerikAcademy].[dbo].[Employees]
		WHERE DepartmentID = e.DepartmentID)
ORDER BY Salary;
