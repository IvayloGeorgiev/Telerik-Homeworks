-- Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
 
SELECT info.[Department Name], info.JobTitle, info.[Minimum Salary], MAX(em.FirstName + ' ' + em.LastName) as Employee
FROM  [TelerikAcademy].[dbo].[Employees] em
	INNER JOIN(SELECT MIN(e.Salary) AS [Minimum Salary], d.Name AS [Department Name], e.JobTitle, d.DepartmentID
		FROM [TelerikAcademy].[dbo].[Employees] e
			INNER JOIN [TelerikAcademy].[dbo].[Departments] d
			ON e.DepartmentID = d.DepartmentID
		GROUP BY d.Name, e.JobTitle, d.DepartmentID) AS info
	ON info.DepartmentID = em.DepartmentID AND info.JobTitle = em.JobTitle AND info.[Minimum Salary] = em.Salary
GROUP BY info.[Department Name], info.JobTitle, info.[Minimum Salary]
ORDER BY [Department Name], [Minimum Salary]