SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) AS Employee, 
(m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName) AS Manager
FROM [TelerikAcademy].[dbo].[Employees] m
RIGHT OUTER JOIN [TelerikAcademy].[dbo].[Employees] e
	ON e.ManagerID = m.EmployeeID;

