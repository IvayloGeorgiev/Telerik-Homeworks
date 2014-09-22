-- Create another table – Logs(LogID, AccountID, OldSum, NewSum).   --
-- Add a trigger to the Accounts table that enters a new entry into --
-- the Logs table every time the sum on an account changes.			--

USE PersonalAccounts
GO

-- Create Table --
IF (OBJECT_ID('dbo.Logs', 'U') IS NULL)	
	BEGIN
		CREATE TABLE Logs(
			[LogID] int NOT NULL identity,
			[AccountID] int NOT NULL,
			[OldSum] money,
			[NewSum] money,
			CONSTRAINT PK_Logs PRIMARY KEY (LogID),
			CONSTRAINT FK_AccountsLogs FOREIGN KEY  (AccountID) REFERENCES Accounts(AccountID)
		)
	END
ELSE 
	PRINT 'Logs exist'	
GO

-- Create Trigger -- 
IF OBJECT_ID('dbo.tr_ChangeBalanceTrigger', 'TR') IS NOT NULL
	DROP TRIGGER dbo.tr_ChangeBalanceTrigger	
GO

CREATE TRIGGER dbo.tr_ChangeBalanceTrigger ON Accounts FOR UPDATE
AS 
	IF EXISTS(SELECT * FROM INSERTED i INNER JOIN deleted d ON i.AccountID = d.AccountID WHERE i.Balance != d.Balance)
		BEGIN
			INSERT INTO Logs(AccountID, OldSum, NewSum)
			SELECT i.AccountID, d.Balance, i.Balance
			FROM inserted i
			INNER JOIN deleted d
			ON i.AccountID = d.AccountID
		END
GO 

---- Tests --
SELECT * FROM Logs
EXEC dbo.usp_DepositMoney 3, 100
EXEC dbo.usp_WithdrawMoney 6, 1000
SELECT * FROM Logs