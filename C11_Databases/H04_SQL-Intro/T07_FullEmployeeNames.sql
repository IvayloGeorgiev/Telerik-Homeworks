SELECT (FirstName + ISNULL(' ' + MiddleName, '') + ' ' + LastName) AS FullName 
FROM [TelerikAcademy].[dbo].[Employees];
