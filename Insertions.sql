-- Inserting sample data into Credentials table
INSERT INTO Credentials (UserID, Username, Password, UserType) VALUES
(1, 'admin1', 'adminpass1', 'admin'),
(2, 'student1', 'studentpass1', 'student'),
(3, 'ta_demo1', 'tadempass1', 'ta'),
(4, 'faculty1', 'facultypass1', 'faculty'),
(5, 'st1','1122','student');

Select * From Credentials;
Select * From TA_Demonstrator;

-- Inserting sample data into Student table
INSERT INTO Student (UserID, Email, CGPA) VALUES
(2, 'student1@example.com', 3.5),
(5,'st1@gmail.com',3.9);

-- Inserting sample data into TA_Demonstrator table
INSERT INTO TA_Demonstrator (UserID, Name, Email, ContactInformation, Qualifications, Availability_Start, Availability_End) VALUES
(3, 'TA Demo 1', 'tademo1@example.com', '123-456-7890', 'MSc in Physics', '08:00:00', '16:00:00');

-- Inserting sample data into FacultyMembers table
INSERT INTO FacultyMembers (UserID, Name, ContactInformation, Department) VALUES
(4, 'Faculty 1', 'faculty1@example.com', 'Computer Science');

-- Inserting sample data into Tasks table
INSERT INTO Tasks (Task_ID, Task_Description, Deadline, Status, Assigned_To, Assigned_By) VALUES
(3, 'Task 3 description', '2023-12-01', 0, 3, 4);
(1, 'Task 1 description', '2023-12-31', 1, 3, 4),
(2, 'Task 2 description', '2023-11-30', 0, NULL, 4);

-- Inserting sample data into Task_Assignment table
INSERT INTO Task_Assignment (Assignment_ID, Task_ID, TA_ID, Assigned_Date) VALUES
(1, 1, 3, '2023-11-15');

-- Inserting sample data into Feedback_Evaluation table
INSERT INTO Feedback_Evaluation (From_Faculty, To_TA, Feedback_Description, Rating, Date) VALUES
(4, 3, 'Good job!', 5, '2023-11-20');

-- Inserting sample data into UserRoles table
INSERT INTO UserRoles (Role_ID, TA_ID, Role_Name, Of_Faculty, Subject) VALUES
(1,3, 'Role 1', 4, 'Subject 1');
