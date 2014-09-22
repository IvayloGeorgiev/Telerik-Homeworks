-- Write a stored procedure that selects the full names of all persons. --

USE PersonalAccounts
GO
IF (OBJECT_ID('dbo.usp_SelectFullNames', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_SelectFullNames
GO

CREATE PROC dbo.usp_SelectFullNames
AS 
	SELECT (p.FirstName + ' ' + p.LastName) as [Full Name]
	FROM [PersonalAccounts].[dbo].[Persons] p
GO

EXEC usp_SelectFullNames