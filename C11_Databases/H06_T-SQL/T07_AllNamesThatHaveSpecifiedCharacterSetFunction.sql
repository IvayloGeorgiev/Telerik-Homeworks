-- Define a function in the database TelerikAcademy that returns all Employee's names --
-- (first or middle or last name) and all town's names that are comprised of given set of letters. --
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'. --
USE TelerikAcademy

GO
IF (OBJECT_ID('dbo.ufn_AllNamesComprisedOfSet', 'TF') IS NOT NULL)
	DROP FUNCTION dbo.ufn_AllNamesComprisedOfSet
GO

CREATE FUNCTION dbo.ufn_AllNamesComprisedOfSet (@letterSet nvarchar(max))
RETURNS @Results TABLE
(
	MatchedValues nvarchar(100)
)
BEGIN
	SET @letterSet = '[' + @letterSet + ']' -- Format the letterset
	DECLARE testCursor CURSOR READ_ONLY FOR -- Create a cursor that can itterate over all names (first, middle, last or town)
		SELECT FirstName as [Matches]
		FROM [TelerikAcademy].[dbo].[Employees]
		WHERE FirstName IS NOT NULL
		UNION
		SELECT MiddleName as [Matches]
		FROM [TelerikAcademy].[dbo].[Employees]
		WHERE MiddleName IS NOT NULL
		UNION
		SELECT LastName as [Matches]
		FROM [TelerikAcademy].[dbo].[Employees]
		WHERE LastName IS NOT NULL
		UNION
		SELECT Name as [Matches]
		FROM [TelerikAcademy].[dbo].[Towns]		
		WHERE Name IS NOT NULL

	OPEN testCursor
	DECLARE @match nvarchar(100) 
	FETCH NEXT FROM testCursor INTO @match

	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE @index int = 1 -- Index of the current name.
			DECLARE @toAdd int = 0 -- This is treated as a boolean, 0 is true, 1 is false (To confuse the enemy).
				WHILE @index <= LEN(@match)
					BEGIN
						IF (LOWER(SUBSTRING(@match, @index, 1)) NOT LIKE @letterSet) -- Check if the letter is not in the set of letters. If its not, change the boolean toAdd
							BEGIN													
								SET @toAdd = 1 
								BREAK
							END
						SET @index = @index + 1
					END
				IF @toAdd = 0		
					INSERT INTO @Results (MatchedValues)
						VALUES (@match)
			FETCH NEXT FROM testCursor INTO @match
		END

	CLOSE testCursor
	DEALLOCATE testCursor

	RETURN
END
GO

SELECT *
FROM dbo.ufn_AllNamesComprisedOfSet('oistmiahf')