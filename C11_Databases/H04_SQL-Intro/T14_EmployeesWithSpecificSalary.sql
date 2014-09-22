SELECT FirstName, MiddleName, LastName, Salary
FROM [TelerikAcademy].[dbo].[Employees]
WHERE Salary IN (25000, 14000, 12500, 23600)
ORDER BY Salary, FirstName, LastName;