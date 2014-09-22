SELECT e.FirstName, e.MiddleName, e.LastName, a.AddressText AS [Address]
FROM [TelerikAcademy].[dbo].[Employees] AS e 
INNER JOIN [TelerikAcademy].[dbo].[Addresses] AS a 
	ON e.AddressID = a.AddressID;