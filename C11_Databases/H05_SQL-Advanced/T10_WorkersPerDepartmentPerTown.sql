-- Write a SQL query to find the count of all employees in each department and for each town. --

SELECT d.Name AS [Department Name], t.Name AS [Town Name], COUNT(e.FirstName) AS [# of Employees]
FROM [TelerikAcademy].[dbo].[Employees] e
INNER JOIN [TelerikAcademy].[dbo].[Departments] d
	ON e.DepartmentID = d.DepartmentID
INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON a.AddressID = e.AddressID	
	INNER JOIN [TelerikAcademy].[dbo].[Towns] t		
		ON t.TownID = a.TownID
GROUP BY d.Name, t.Name;