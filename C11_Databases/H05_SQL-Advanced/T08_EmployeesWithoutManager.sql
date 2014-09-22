-- Write a SQL query to find the number of all employees that have no manager. --

SELECT COUNT(e.FirstName) as [Employees With Managers]
FROM [TelerikAcademy].[dbo].[Employees] e
WHERE e.ManagerID IS NULL