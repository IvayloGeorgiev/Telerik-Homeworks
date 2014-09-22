-- Define a .NET aggregate function StrConcat that takes as input a sequence of strings --
-- and return a single string that consists of the input strings separated by ','. --
-- For example the following SQL statement should return a single string: --

-- Most of the code was copied from http://www.mssqltips.com/sqlservertip/2022/concat-aggregates-sql-server-clr-function/ --
-- Did a minor change to the aggregator DLL so that it will work with a preset delimiter instead of using the user supplied one. -- 
IF OBJECT_ID('dbo.StringConcat', 'AF') IS NOT NULL
	DROP AGGREGATE StringConcat

IF EXISTS(SELECT * FROM sys.assemblies WHERE NAME = 'ud_String')
	DROP ASSEMBLY ud_string

DECLARE @filePath nvarchar(200);
SET @filePath = 'C:\Users\Coyote\Documents\SQL Server Management Studio\T-SQL\' -- Change the path to wherever you are testing the homeworks.

CREATE ASSEMBLY ud_String
	FROM @filePath + 'StringAggregateCreator.dll'
	WITH PERMISSION_SET = SAFE

CREATE AGGREGATE StringConcat(
	@Value nvarchar(max)
) 
RETURNS nvarchar(max)
EXTERNAL Name [ud_String].[StringConcat]
GO

sp_configure 'clr enabled', 1
RECONFIGURE

GO
SELECT [dbo].StringConcat(FirstName + ' ' + LastName)
FROM [TelerikAcademy].[dbo].Employees