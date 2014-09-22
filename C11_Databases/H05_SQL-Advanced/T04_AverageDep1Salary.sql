-- Write a SQL query to find the average salary in the department #1 --

SELECT AVG(Salary) as [Average Salary Dep. 1]
FROM [TelerikAcademy].[dbo].[Employees]
WHERE DepartmentID = 1;