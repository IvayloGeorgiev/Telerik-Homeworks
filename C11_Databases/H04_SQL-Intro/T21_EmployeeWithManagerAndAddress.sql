SELECT (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + e.LastName) AS Employee, 
(m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName) AS Manager,
a.AddressText AS EmployeeAddress
FROM [TelerikAcademy].[dbo].[Employees] e 
	LEFT OUTER JOIN [TelerikAcademy].[dbo].[Employees] m 
		ON e.ManagerID = m.EmployeeID
	LEFT OUTER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID;
-- Using left outer join as we have to list ALL employees and both managerid and addressid in Employee can be NULL. --