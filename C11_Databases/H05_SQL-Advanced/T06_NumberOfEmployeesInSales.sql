-- Write a SQL query to find the number of employees in the "Sales" department. --

SELECT COUNT(e.FirstName) AS [# of Employees in Sales]
FROM [TelerikAcademy].[dbo].[Employees] e
INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales';