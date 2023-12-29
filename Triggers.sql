CREATE OR ALTER TRIGGER Credentials_trg
ON Credentials
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN CREDENTIALS'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATE IN CREDENTIALS'
	ELSE
        SET @actionType = 'DELETION IN CREDENTIALS'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM deleted;
END;


CREATE OR ALTER TRIGGER Student_trg
ON Student
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
   SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN STUDENTS'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN STUDENTS'
	ELSE
        SET @actionType = 'DELETION IN STUDENTS'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER TA_trg 
ON TA_Demonstrator
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN TA'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN TA'
	ELSE
        SET @actionType = 'DELETION IN TA'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER Faculty_trg 
ON FacultyMembers
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN FACULTY'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN FACULTY'
	ELSE
        SET @actionType = 'DELETION IN FACULTY'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER Tasks_trg 
ON Tasks
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN TASKS'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN TASKS'
	ELSE
        SET @actionType = 'DELETION IN TASKS'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Task_ID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Task_ID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER TaskAssignments_trg
ON TaskAssignments
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN TASKS ASSIGNMENT'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN TASKS ASSIGNMENT'
	ELSE
        SET @actionType = 'DELETION IN TASKS ASSIGNMENT'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Assignment_ID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Assignment_ID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER Feedback_trg 
ON Feedback_Evaluation
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN FEEDBACK'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN FEEDBACK'
	ELSE
        SET @actionType = 'DELETION IN FEEDBACK'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Feedback_ID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Feedback_ID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER Roles_trg
ON Roles
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN ROLES'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN ROLES'
	ELSE
        SET @actionType = 'DELETION IN ROLES'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Role_ID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT Role_ID, @actionType, GETDATE() FROM deleted;
END;

CREATE OR ALTER TRIGGER UserRoles_trg 
ON UserRoles
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actionType NVARCHAR(30);

    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
        SET @actionType = 'INSERTION IN USER ROLES'
    ELSE IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @actionType = 'UPDATTION IN USER ROLES'
	ELSE
        SET @actionType = 'DELETION IN USER ROLES'

    INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserRole_ID, @actionType, GETDATE() FROM inserted;

	INSERT INTO Logtable(UserID, Activity, LogDate)
    SELECT UserRole_ID, @actionType, GETDATE() FROM deleted;
END;



