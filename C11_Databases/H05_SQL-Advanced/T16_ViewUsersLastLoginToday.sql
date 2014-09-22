-- Write a SQL statement to create a view that displays the users from the Users --
-- table that have been in the system today. Test if the view works correctly.   --

USE TelerikAcademy

GO 
IF OBJECT_ID ('UsersTodayView', 'V') IS NOT NULL
	DROP VIEW [UsersTodayView]
GO

CREATE VIEW UsersTodayView
AS
SELECT *
FROM [TelerikAcademy].[dbo].[Users]
WHERE CAST(LastLoginTime as DATE) = CAST(CURRENT_TIMESTAMP AS DATE);