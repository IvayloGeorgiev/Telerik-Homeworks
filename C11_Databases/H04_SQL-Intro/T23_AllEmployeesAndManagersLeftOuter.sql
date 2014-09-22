SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) AS Employee, 
(m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName) AS Manager
FROM [TelerikAcademy].[dbo].[Employees] e
LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m
	ON e.ManagerID = m.EmployeeID;

