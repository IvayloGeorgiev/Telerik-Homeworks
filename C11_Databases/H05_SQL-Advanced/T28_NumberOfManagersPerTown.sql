SELECT t.Name AS Town, COUNT(m.ManagerID) AS [# of Managers]
FROM 
	(SELECT DISTINCT ManagerID
	FROM [TelerikAcademy].[dbo].[Employees] man
	WHERE ManagerID IS NOT NULL) m
		INNER JOIN [TelerikAcademy].[dbo].[Employees] e
		ON m.ManagerID = e.EmployeeID
			INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
			ON a.AddressID = e.AddressID		
				INNER JOIN [TelerikAcademy].[dbo].[Towns] t
				ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [# of Managers] DESC