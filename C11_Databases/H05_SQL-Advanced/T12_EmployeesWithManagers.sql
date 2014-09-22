-- Write a SQL query to find all employees along with their managers.		-- 
-- For employees that do not have manager display the value "(no manager)". --

SELECT e.EmployeeID, e.FirstName + ' ' + e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, '(no manager)') as [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID
