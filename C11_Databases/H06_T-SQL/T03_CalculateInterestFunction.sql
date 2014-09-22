-- Create a function that accepts as parameters – sum, yearly interest rate and number of months. --
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected. --

USE PersonalAccounts

GO
IF (OBJECT_ID('dbo.ufn_BalanceAfterInterestForMonthPeriod', 'FN') IS NOT NULL)
	DROP FUNCTION dbo.ufn_BalanceAfterInterestForMonthPeriod
GO

CREATE FUNCTION dbo.ufn_BalanceAfterInterestForMonthPeriod (@sum money, @yearlyInterest float, @numberOfMonths int)
	RETURNS money
BEGIN
	RETURN @sum +  @sum * (@yearlyInterest / 12) * @numberOfMonths
END
GO

SELECT dbo.ufn_BalanceAfterInterestForMonthPeriod(1000, 0.04, 1) as SumAfterInterest