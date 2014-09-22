SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) AS [Employee], 
d.Name AS [DepartmentName], 
e.HireDate
FROM [TelerikAcademy].[dbo].[Employees] e
	INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
	AND d.Name IN ('Finance', 'Sales')
	AND YEAR(e.HireDate) BETWEEN 1995 AND 2005	
ORDER BY [DepartmentName], e.HireDate