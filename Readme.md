# EduManageTA
![Screenshot 2023-12-01 172259](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/77d72a6a-7ca7-4ffd-87d0-55f601a4db18)

## Overview
Streamlining Academic Administration: An Integrated Platform for Managing Teaching Assistants and Lab Demonstrators. This system is designed to improve the administration of Teacher Assistants (TAs) and Lab Demonstrators, focusing on task allocation, rescheduling, and supervision.

## Features
- **Task Management**: Delegation, supervision, and oversight of tasks.
- **Profile Management**: Managing profiles of TAs, faculty, and students.
- **Role-Based Access Control**: Secure authentication and authorization mechanisms.
- **Feedback and Evaluation**: Facilitating feedback submission and performance evaluation.
- **Audit Trail and Information Gathering**: For auditing and accountability purposes.

## Installation
Prerequisites
Windows 7 or later.
Visual Studio (preferably the latest version).
.NET Framework (compatible with the version used in your project).
SQL Server (or any other compatible database system you used).
Steps
Clone the Repository

Open Visual Studio.
Go to File > Clone Repository.
Enter the URL of your GitHub repository.
Choose a local path and clone.
Open the Project

In Visual Studio, go to File > Open > Project/Solution.
Navigate to the cloned repository's directory.
Open the .sln file.
Restore NuGet Packages

Right-click on the solution in the Solution Explorer.
Click on Restore NuGet Packages to ensure all dependencies are properly installed.
Database Setup

Open SQL Server Management Studio.
Connect to your SQL Server instance.
Create a new database for the project (if not already done).
Run the provided SQL scripts to set up tables and initial data (if any).
Update Database Connection String

In your project, find the file where the database connection string is stored.
Update the connection string with your database server details.
Build the Project

In Visual Studio, select Build > Build Solution to compile the project.
Run the Application

After building, click Start or press F5 to run the application.
Ensure the application connects to the database successfully.
Verify Functionality

Test the different functionalities of your application to ensure everything works as expected.
Troubleshooting
Build Errors: Ensure all project dependencies and references are correct. Check for any missing files or incorrect paths.
Database Connection Issues: Verify the connection string and ensure the SQL Server is running.
Runtime Errors: Check the Windows Event Viewer for any application-specific errors that might provide more insight.

## Usage
Detailed guidelines on how to use the various features such as:
- Logging in and profile management for different user roles (Faculty, TA/Demonstrators, Students).
- Task assignment and management.
- Providing and accessing feedback and evaluations.

## Project ScreenShots
![Screenshot 2023-12-01 172451](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/8120a26f-aabb-487a-82c5-99a2f241e1de)
![Screenshot 2023-12-01 172430](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/1f5b790b-6945-4520-93a4-1a5d5c6b21d8)
![Screenshot 2023-12-01 172416](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/cf198cca-bd85-41a2-865a-58bc395c8a6c)
![Screenshot 2023-12-01 172401](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/ea25ccf1-6c82-4fe2-bcc4-110ec7fe7712)
![Screenshot 2023-12-01 172347](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/d3c595f6-abeb-4c0e-b473-03d6f62a05a6)
![Screenshot 2023-12-01 172337](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/1ab8c473-7a4b-4e1d-bd17-412ec17a57d7)
![Screenshot 2023-12-01 172328](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/8c9f6ad4-7ac8-4614-8940-d3ac91bf9594)
![Screenshot 2023-12-01 172310](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/3aaff60a-3e06-4d3b-9518-a2b7cb042225)
![Screenshot 2023-12-01 172259](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/77d72a6a-7ca7-4ffd-87d0-55f601a4db18)

## ERD Diagram
![erd](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/7dac8d5a-65c0-42ac-966a-75fae76121e8)

## EERD Diagram
![eerd](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/3dff0a5b-68f8-41fb-a0c2-11a49d1e3463)

## Relational Database Diagram
![Relational](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/b0d9499e-a611-4ada-8abe-fac7c8285bbe)

## 3NF Normalized Tables 
![Screenshot 2023-12-01 195057](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/af13333e-d850-4d93-8feb-1e1d1876a16f)
![Screenshot 2023-12-01 195117](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/50fd5643-6ba4-4e93-8926-70ad10dc2be8)
![Screenshot 2023-12-01 195109](https://github.com/FaizanPervaz/EduManageTA---Database-Project/assets/121532370/dd0925f1-bd66-4825-92f0-191a7c0edcfa)


