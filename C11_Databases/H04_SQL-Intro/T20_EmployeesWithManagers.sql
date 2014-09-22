SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) AS Employee, 
(m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName) AS Manager
FROM [TelerikAcademy].[dbo].[Employees] AS e 
INNER JOIN [TelerikAcademy].[dbo].[Employees] AS m 
	ON e.ManagerID = m.EmployeeID;