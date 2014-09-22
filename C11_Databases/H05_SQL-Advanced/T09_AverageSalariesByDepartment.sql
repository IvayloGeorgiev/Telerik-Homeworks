-- Write a SQL query to find all departments and the average salary for each of them. --

SELECT d.Name as [Department Name], 
AVG(e.Salary) as [Department Average Salary]
FROM [TelerikAcademy].[dbo].[Departments] d
INNER JOIN [TelerikAcademy].[dbo].[Employees] e
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
ORDER BY [Department Average Salary]
