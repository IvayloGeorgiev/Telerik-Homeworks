-- Write a SQL query to display the current date and time in the		--
-- following format "day.month.year hour:minutes:seconds:milliseconds". -- 
-- Search in  Google to find how to format dates in SQL Server.			--

SELECT FORMAT(CURRENT_TIMESTAMP, 'dd.MM.yyyy HH:mm:ss:fff');