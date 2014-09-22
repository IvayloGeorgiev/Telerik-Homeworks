-- Find how to use temporary tables in SQL Server. Using temporary tables backup all --
--  records from EmployeesProjects and restore them back after dropping and re-creating the table. --


-- RUN THIS CODE ONLY AFTER SELECTING TelerikAcademy AS YOUR ACTIVE DATABASE!!!!!! -- 
BEGIN TRAN
SELECT * INTO #TempTable FROM EmployeesProjects
DROP TABLE EmployeesProjects
COMMIT

CREATE TABLE EmployeesProjects(
  EmployeeID int NOT NULL,
  ProjectID int NOT NULL,
  CONSTRAINT PK_EmployeesProjects PRIMARY KEY CLUSTERED (EmployeeID ASC, ProjectID ASC)
)

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees FOREIGN KEY(EmployeeID)
REFERENCES Employees(EmployeeID)
GO

ALTER TABLE EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Projects FOREIGN KEY(ProjectID)
REFERENCES Projects(ProjectID)
GO

INSERT INTO EmployeesProjects
SELECT * FROM #TempTable
GO