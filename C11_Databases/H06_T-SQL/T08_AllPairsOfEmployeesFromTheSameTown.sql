DECLARE employeeCursor CURSOR READ_ONLY FOR
	SELECT e.EmployeeID, (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' +  e.LastName) as FullName, t.TownID
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID
			INNER JOIN [TelerikAcademy].[dbo].[Towns] t
			ON a.TownID = t.TownID
	ORDER BY TownID

-- Using database cursor write a T-SQL script that scans all employees and       --
-- their addresses and prints all pairs of employees that live in the same town. --

DECLARE @EmployeesWithTownName TABLE
(
	EmployeeID int,
	EmployeeName nvarchar(300),
	TownID int,
	TownName nvarchar(100)
);

INSERT INTO @EmployeesWithTownName
	SELECT e.EmployeeID, (e.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' +  e.LastName) as FullName, t.TownID, t.Name
		FROM [TelerikAcademy].[dbo].[Employees] e
			INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
			ON e.AddressID = a.AddressID
				INNER JOIN [TelerikAcademy].[dbo].[Towns] t
				ON a.TownID = t.TownID
		ORDER BY TownID

DECLARE @EmployeesInSameTown TABLE
(
	FirstEmployee nvarchar(300),
	SecondEmployee nvarchar(300),
	Town nvarchar(100)
)

DECLARE @AllocatedEmployees TABLE
(
	EmployeeID int
)

OPEN employeeCursor
DECLARE @eID int, @eFullName nvarchar(300), @tID int
FETCH NEXT FROM employeeCursor INTO @eID, @eFullName, @tID
WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO @EmployeesInSameTown (FirstEmployee, SecondEmployee, Town)
			SELECT @eFullName, et.EmployeeName, et.TownName
			FROM @EmployeesWithTownName et
			WHERE @eID != et.EmployeeID AND @tID = et.TownID AND et.EmployeeID NOT IN (SELECT al.EmployeeID  FROM @AllocatedEmployees al)
		INSERT INTO @AllocatedEmployees (EmployeeID)
			VALUES (@eID)
		FETCH NEXT FROM employeeCursor INTO @eID, @eFullName, @tID
	END
CLOSE employeeCursor

SELECT *
FROM @EmployeesInSameTown

DEALLOCATE employeeCursor