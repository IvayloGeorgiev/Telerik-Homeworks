-- * Write a T-SQL script that shows for each town a list of all employees that live in it. 
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva

DECLARE @NamesWithTown TABLE
(
	TownID int,
	TownName nvarchar(100),
	FullName nvarchar(300)	
)

INSERT INTO @NamesWithTown (TownID, TownName, FullName)
	SELECT t.TownID, t.Name, (e.FirstName + ' ' + e.LastName)
	FROM [TelerikAcademy].[dbo].[Employees] e
		INNER JOIN [TelerikAcademy].[dbo].[Addresses] a
		ON e.AddressID = a.AddressID
			INNER JOIN [TelerikAcademy].[dbo].[Towns] t
			ON a.TownID = t.TownID

DECLARE @MaxTownID int
SELECT @MaxTownID = MAX(TownID)
FROM @NamesWithTown

DECLARE @CurrentTownID int
SELECT @CurrentTownID = MIN(TownID)
FROM @NamesWithTown

WHILE @CurrentTownID <= @MaxTownID
	BEGIN
		PRINT  @CurrentTownID		
		DECLARE @Names nvarchar(max), @Town nvarchar(100)
		SET @Names = NULL -- Necessary as the variable value seems to be retained in the database memory
		SELECT @Town = TownName, @Names = COALESCE(@Names + ', ', '') + FullName
		FROM @NamesWithTown
		WHERE TownID = @CurrentTownID		
		IF (@Town IS NOT NULL) -- Just in case some townid are skipped in the database.
			PRINT @Town + ' -> ' + @Names
		SET @CurrentTownID = @CurrentTownID + 1
	END