IF db_id('LogData') IS NULL
	CREATE DATABASE LogData
GO

USE LogData

CREATE TABLE Logs
(
	Id INT NOT NULL Identity(1, 1),
	LogText NVARCHAR(100),
	LogDate DATE,	
	CONSTRAINT PK_LogData_Id PRIMARY KEY(Id)
);

--1. Create a table in SQL Server with 10 000 000 log entries (date + text). Search in the table by date range. Check the speed (without caching).
 
 
SET NOCOUNT ON
DECLARE @RowCount INT = 10000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) =
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @DATE datetime =
        DATEADD(MONTH, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Logs(LogText, LogDate)
  VALUES(@Text, @DATE)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF
 
WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogText, LogDate)
  SELECT LogText, LogDate FROM Logs
END
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
 
SELECT * FROM Logs m
WHERE m.LogDate BETWEEN '01-08-1999' AND '01-01-2000'
 
-- takes 21-24 seconds without cache and 1 second with cache
 
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
 
-- takes 8 seconds
 
 
--2.Add an index to speed-up the search by date. Test the search speed (after cleaning the cache).
 
 
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
 
SELECT * FROM Logs m
WHERE m.LogDate BETWEEN '01-08-1999' AND '01-01-2000'
 
-- takes 20-27 seconds
 
-- Conclusion: Index on date was of no use to me whatsoever. Did several tests with dropping and creating
-- index each time and clearing cache.
 
 
 
--3.Add a full text index for the text column. Try to search with and without the full-text index and compare the speed.
 
 
CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF
 
CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_MsgId
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO
 
SELECT * FROM Logs
WHERE CONTAINS(LogText, 'Text%')
 
-- takes 2 seconds
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT COUNT(*) FROM Logs
WHERE CONTAINS(LogText, 'Text%')
 
-- takes 0 seconds
 
DROP FULLTEXT INDEX ON Logs
DROP FULLTEXT CATALOG LogsFullTextCatalog
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Logs
WHERE LogText LIKE 'Text%'
 
-- takes more than a minute
 
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT COUNT(*) FROM Logs
WHERE LogText LIKE 'Text%'
 
-- takes 20 seconds