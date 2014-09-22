-- Write a SQL query to display the average employee salary by department and job title. --

SELECT d.Name as [Department Name], e.JobTitle, AVG(e.Salary) as [Average Salary]
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY [Department Name], [Average Salary];