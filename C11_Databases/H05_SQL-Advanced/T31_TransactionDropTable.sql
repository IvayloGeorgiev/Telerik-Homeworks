-- Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data? --

BEGIN TRAN
DROP TABLE [TelerikAcademy].[dbo].[EmployeesProjects]
ROLLBACK TRAN 
-- If we had commited the transaction, we would need to have kept a log of entries and used it to rollback all the necessary data.