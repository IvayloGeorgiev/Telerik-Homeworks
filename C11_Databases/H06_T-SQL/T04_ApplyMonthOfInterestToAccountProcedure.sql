-- Create a stored procedure that uses the function from the previous example to --
-- give an interest to a person's account for one month. It should take the AccountId --
-- and the interest rate as parameters. --

USE PersonalAccounts
GO
IF (OBJECT_ID('dbo.usp_ApplyMonthOfInterestToAccount', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_ApplyMonthOfInterestToAccount
GO

CREATE PROCEDURE dbo.usp_ApplyMonthOfInterestToAccount(@interest float = 0.05, @accId int)
AS 
	UPDATE [PersonalAccounts].[dbo].[Accounts]
	SET Balance = (dbo.ufn_BalanceAfterInterestForMonthPeriod(Balance, @interest, 1))
	WHERE AccountID = @accId
GO

-- Testing, feel free to comment it out. --
SELECT * FROM Accounts
EXEC dbo.usp_ApplyMonthOfInterestToAccount 0.10, 3
SELECT * FROM Accounts
