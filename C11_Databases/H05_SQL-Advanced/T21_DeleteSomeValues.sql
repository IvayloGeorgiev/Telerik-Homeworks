-- Write SQL statements to delete some of the records from the Users and Groups tables. --

DELETE FROM [TelerikAcademy].[dbo].[Groups]
WHERE GroupID IN
	(SELECT g.GroupID
	FROM [TelerikAcademy].[dbo].[Groups] g
	LEFT OUTER JOIN [TelerikAcademy].[dbo].[Users] u
		ON g.GroupID = u.GroupID
	GROUP BY g.GroupID
	HAVING COUNT(u.GroupID) = 0)

DELETE FROM [TelerikAcademy].[dbo].[Users]
WHERE LastLoginTime < '20140101'