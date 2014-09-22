-- Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
-- Don't forget to define  identity, primary key and appropriate foreign key. 
--
-- Issue few SQL statements to insert, update and delete of some data in the table.
--
-- Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

USE TelerikAcademy

-- The table --
CREATE TABLE WorkHours(
	[TaskID] int NOT NULL IDENTITY,
	[Task] nvarchar(100) NOT NULL,
	[EmployeeID] int,
	[TaskDate] date,
	[HoursWorked] int,
	[Comments] nvarchar(max),
	CONSTRAINT PK_WorkHours PRIMARY KEY ([TaskID]),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
)

-- WorkHours Log --
CREATE TABLE WorkHoursLogs(
	[LogID] int NOT NULL IDENTITY,
	[LogCommand] nvarchar(50) NOT NULL,	
	[OldTaskID] int,
	[OldTask] nvarchar(100),
	[OldEmployeeID] int,
	[OldTaskDate] date,
	[OldHoursWorked] int,
	[OldComments] nvarchar(max),	
	[NewTaskID] int,
	[NewTask] nvarchar(100),
	[NewEmployeeID] int,
	[NewTaskDate] date,
	[NewHoursWorked] int,
	[NewComments] nvarchar(max),
	CONSTRAINT PK_WorkHoursLogs PRIMARY KEY ([LogID])
)

-- Triggers --
GO
CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS 
	INSERT INTO WorkHoursLogs(LogCommand, NewTaskID, NewTask, NewEmployeeID, NewTaskDate, NewHoursWorked, NewComments)
		SELECT 'insert' as LogCommand,
		i.TaskID as NewTaskID, i.Task as NewTask, i.EmployeeID as NewEmployeeID, i.TaskDate as NewTaskDate, i.HoursWorked as NewHoursWorked, i.Comments as NewComments
		FROM inserted i
GO
CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS 
	INSERT INTO WorkHoursLogs(LogCommand, OldTaskID, OldTask, OldEmployeeID, OldTaskDate, OldHoursWorked, OldComments, NewTaskID, NewTask, NewEmployeeID, NewTaskDate, NewHoursWorked, NewComments)
		SELECT 'update' as LogCommand,		
		d.TaskID as OldTaskID, d.Task as OldTask, d.EmployeeID as OldEmployeeID, d.TaskDate as OldTaskDate, d.HoursWorked as OldHoursWorked, d.Comments as OldComments,
		i.TaskID as NewTaskID, i.Task as NewTask, i.EmployeeID as NewEmployeeID, i.TaskDate as NewTaskDate, i.HoursWorked as NewHoursWorked, i.Comments as NewComments
		FROM Deleted d
		INNER JOIN inserted i ON d.TaskID = i.TaskID
GO
CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS 
	INSERT INTO WorkHoursLogs(LogCommand, OldTaskID, OldTask, OldEmployeeID, OldTaskDate, OldHoursWorked, OldComments)
		SELECT 'delete' as LogCommand,
		d.TaskID as OldTaskID, d.Task as OldTask, d.EmployeeID as OldEmployeeID, d.TaskDate as OldTaskDate, d.HoursWorked as OldHoursWorked, d.Comments as OldComments
		FROM deleted d


-- Inserts, Updates, Delets --
GO
INSERT INTO WorkHours (Task, EmployeeID, TaskDate, HoursWorked, Comments)
	VALUES
	('KendoUI Bug Fixes', 291, '20130707', 6, NULL),
	('JustCode Features', 291, '20130807', 10, NULL),
	('Random Stuff', 4, '20140807', 7, NULL),
	('More random stuff', 4, '20140810', 10, NULL),
	('Lectures', 291, '20130607', 4, NULL),
	('Who knows, I dont', 4, '20131212', 8, NULL),
	('JustCode', 123, '20140708', 6, NULL),
	('Top Secret Project', 12, '20140203', 16, NULL),
	('JustMock', 123, '20140707', 8, NULL)


UPDATE [TelerikAcademy].[dbo].[WorkHours] 
SET Comments = 'Dont enter stupid task names into the databases, dammit'
WHERE EmployeeID = 4 AND Comments IS NULL;

DELETE FROM [TelerikAcademy].[dbo].[WorkHours]
WHERE EmployeeID = 291
