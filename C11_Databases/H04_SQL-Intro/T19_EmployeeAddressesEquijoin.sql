SELECT e.FirstName, e.MiddleName, e.LastName, a.AddressText AS [Address]
FROM [TelerikAcademy].[dbo].[Employees] AS e, [TelerikAcademy].[dbo].[Addresses] AS a
WHERE e.AddressID = a.AddressID;