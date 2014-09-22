-- Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name as [Town], COUNT(e.EmployeeID) as [Employees In Town]
FROM [TelerikAcademy].[dbo].[Towns] t
	INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
	ON t.TownID = a.TownID
		INNER JOIN [TelerikAcademy].[dbo].[Employees] e
		ON e.AddressID = a.AddressID
GROUP BY t.Name
ORDER BY [Employees In Town] DESC