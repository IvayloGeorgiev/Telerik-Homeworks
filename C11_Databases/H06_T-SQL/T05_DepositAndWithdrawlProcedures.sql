-- Add two more stored procedures WithdrawMoney( AccountId, money)   --
-- and DepositMoney (AccountId, money) that operate in transactions. --

USE PersonalAccounts
GO
IF (OBJECT_ID('dbo.usp_WithdrawMoney', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_WithdrawMoney
GO

CREATE PROCEDURE dbo.usp_WithdrawMoney(@accId int, @amount money)
AS 
	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE [PersonalAccounts].[dbo].[Accounts]
			SET Balance = Balance - @amount
			WHERE AccountID = @accId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO

GO
IF (OBJECT_ID('dbo.usp_DepositMoney', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_DepositMoney
GO

CREATE PROCEDURE dbo.usp_DepositMoney(@accId int, @amount money)
AS 
	BEGIN TRY 
		BEGIN TRANSACTION
			UPDATE [PersonalAccounts].[dbo].[Accounts]
			SET Balance = Balance + @amount
			WHERE AccountID = @accId
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
GO


-- Testing, feel free to comment it out. --

SELECT * FROM Accounts
EXEC dbo.usp_DepositMoney 3, 100
SELECT * FROM Accounts
EXEC dbo.usp_DepositMoney 6, 1000
SELECT * FROM Accounts
EXEC dbo.usp_WithdrawMoney 10, 10000
SELECT * FROM Accounts
EXEC dbo.usp_DepositMoney 12, 100
SELECT * FROM Accounts