SELECT Name AS DepartmentOrTownName
FROM [TelerikAcademy].[dbo].[Departments]
UNION
SELECT Name AS DeparmentOrTownName
FROM [TelerikAcademy].[dbo].[Towns];