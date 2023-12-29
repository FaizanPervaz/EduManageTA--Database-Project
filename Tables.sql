CREATE TABLE Credentials (
    UserID INT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    UserType VARCHAR(20) 
);

CREATE TABLE Student (
    UserID INT PRIMARY KEY,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CGPA FLOAT (CGPA >= 0.0 AND CGPA <= 4.0),
    FOREIGN KEY (UserID) REFERENCES Credentials(UserID)
);

CREATE TABLE TA_Demonstrator (
    UserID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    ContactInformation VARCHAR(100) NOT NULL,
    Qualifications VARCHAR(200) NOT NULL,
    Availability_Start TIME NOT NULL,
    Availability_End TIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Credentials(UserID)
);

CREATE TABLE FacultyMembers (
    UserID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    ContactInformation VARCHAR(100) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Credentials(UserID)
);

CREATE TABLE COURSES (
    CourseID INT PRIMARY KEY,
    Course_Name VARCHAR(50) NOT NULL,
    CreditHours INT NOT NULL
);

CREATE TABLE Tasks (
    Task_ID INT PRIMARY KEY,
    Task_Description VARCHAR(255),
    Deadline DATE NOT NULL,
	CourseID INT NOT NULL,
    Status BIT,

	FOREIGN KEY (CourseID) REFERENCES COURSES(CourseID)
);

CREATE TABLE TaskAssignments (
    Assignment_ID INT PRIMARY KEY,
    Task_ID INT NOT NULL,
    TA_ID INT NOT NULL,  -- TA who is assigned the task
    Faculty_ID INT NOT NULL,  -- Faculty who assigned the task
    Assigned_Date DATE NOT NULL,
    FOREIGN KEY (Task_ID) REFERENCES Tasks(Task_ID),
    FOREIGN KEY (TA_ID) REFERENCES TA_Demonstrator(UserID),
    FOREIGN KEY (Faculty_ID) REFERENCES FacultyMembers(UserID)
);


CREATE TABLE Feedback_Evaluation (
    Feedback_ID INT IDENTITY(1,1) PRIMARY KEY,
    From_Faculty INT NOT NULL,
    To_TA INT NOT NULL,
    Feedback_Description VARCHAR(255),
    Rating INT NOT NULL CHECK (Rating < 5),
    Date DATE NOT NULL,
    FOREIGN KEY (From_Faculty) REFERENCES FacultyMembers(UserID),
    FOREIGN KEY (To_TA) REFERENCES TA_Demonstrator(UserID)
);

CREATE TABLE Roles (
    Role_ID INT PRIMARY KEY,
    Role_Name VARCHAR(50) NOT NULL,
    Subject VARCHAR(255) NOT NULL
);

CREATE TABLE UserRoles (
    UserRole_ID INT IDENTITY(1,1) PRIMARY KEY,
    TA_ID INT NOT NULL,
    Of_Faculty INT NOT NULL,
    Role_ID INT NOT NULL,
    FOREIGN KEY (TA_ID) REFERENCES TA_Demonstrator(UserID),
    FOREIGN KEY (Of_Faculty) REFERENCES FacultyMembers(UserID),
    FOREIGN KEY (Role_ID) REFERENCES Roles(Role_ID)
);

CREATE Table Logtable(
	LogID INT IDENTITY(1,1),
	UserID INT,
	Activity varchar(30),
	LogDate DATETIME
);
