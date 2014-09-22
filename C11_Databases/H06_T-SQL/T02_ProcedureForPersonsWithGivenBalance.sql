-- Create a stored procedure that accepts a number as a parameter and returns all --
-- persons who have more money in their accounts than the supplied number. -- 

USE PersonalAccounts
GO
IF (OBJECT_ID('dbo.usp_PersonsWithGivenBalance', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_PersonsWithGivenBalance
GO

CREATE PROCEDURE dbo.usp_PersonsWithGivenBalance(@targetBalance money = 100)
AS 
	SELECT p.*, a.Balance, @targetBalance as [Desired Balance]
	FROM [PersonalAccounts].[dbo].[Persons] p
		INNER JOIN [PersonalAccounts].[dbo].[Accounts] a
		ON p.PersonID = a.PersonID
	WHERE a.Balance > @targetBalance
	ORDER BY a.Balance
GO

EXEC usp_PersonsWithGivenBalance
EXEC usp_PersonsWithGivenBalance 1000