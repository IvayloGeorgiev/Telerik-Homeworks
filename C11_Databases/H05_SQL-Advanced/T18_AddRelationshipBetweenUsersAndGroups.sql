-- Write a SQL statement to add a column GroupID to the table Users.  --
-- Fill some data in this new column and as well in the Groups table. -- 
-- Write a SQL statement to add a foreign key constraint between	  --
-- tables Users and Groups tables.									  --

USE TelerikAcademy

GO
ALTER TABLE Users ADD GroupID int 

GO

INSERT INTO Groups(Name) 
	VALUES
	('Rangers'),
	('Slayers'),
	('Kikomans'),
	('Fans')

GO

ALTER TABLE Users 
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)