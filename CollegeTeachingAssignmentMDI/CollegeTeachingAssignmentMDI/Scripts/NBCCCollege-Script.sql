USE [master]

IF EXISTS (
        SELECT *
        FROM sys.databases
        WHERE name = 'NBCCCollege'
        )
BEGIN
    DROP Database [NBCCCollege]
END
GO

GO
CREATE DATABASE [NBCCCollege]
Go

USE [NBCCCollege]
GO

/*
	Drop FK Contrains on Many-to-Many
*/
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Assignments'))
BEGIN    
	ALTER TABLE Assignments DROP CONSTRAINT IF EXISTS [FK_Assignments_Instructors]
	ALTER TABLE Assignments DROP CONSTRAINT IF EXISTS [FK_Assignments_Courses]	
	ALTER TABLE Assignments DROP CONSTRAINT IF EXISTS [CK_Assignments_Courses_Terms]	
END

GO
DROP TABLE IF EXISTS Assignments
GO

/*
Courses Table
*/
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Courses'))
BEGIN   
	
	ALTER TABLE Courses DROP CONSTRAINT IF EXISTS [CK_Courses_Hours]
	ALTER TABLE Courses DROP CONSTRAINT IF EXISTS [CK_Courses_Credits]
END

GO
DROP TABLE IF EXISTS Courses
GO

CREATE TABLE Courses(
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [nvarchar](50) NOT NULL,
	[Credits] [smallint] NOT NULL,
	[Hours] [smallint] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE Courses WITH CHECK ADD CONSTRAINT [CK_Courses_Credits] CHECK  (([Credits]=(3) OR [Credits]=(2) OR [Credits]=(1)))
GO

ALTER TABLE Courses CHECK CONSTRAINT [CK_Courses_Credits]
GO

ALTER TABLE Courses WITH CHECK ADD CONSTRAINT [CK_Courses_Hours] CHECK  (([Hours]=(135) OR [Hours]=(90) OR [Hours]=(45)))
GO

ALTER TABLE Courses CHECK CONSTRAINT [CK_Courses_Hours]
GO

ALTER TABLE Courses WITH CHECK ADD CONSTRAINT [UQ_Courses_CourseName] UNIQUE ([CourseName])
GO

ALTER TABLE Courses CHECK CONSTRAINT [CK_Courses_Hours]
GO

/*
Instructors Table
*/

DROP TABLE IF EXISTS Instructors
GO

CREATE TABLE Instructors(
	[InstructorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[OfficeNumber] [int] NOT NULL,
	[OnSabbatical] [bit] NOT NULL
 CONSTRAINT [PK_Instructors] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*
	Assignments Table
*/

CREATE TABLE Assignments(
	[CourseId] [int] NOT NULL,
	[InstructorId] [int] NOT NULL,
	[Term] [smallint] NOT NULL,
	[Notes] [nvarchar](4000) NULL
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[InstructorId] ASC,
	[Term] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE Assignments  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Courses] FOREIGN KEY([CourseId])
REFERENCES Courses ([CourseId])
GO

ALTER TABLE Assignments CHECK CONSTRAINT [FK_Assignments_Courses]
GO

ALTER TABLE Assignments WITH CHECK ADD  CONSTRAINT [FK_Assignments_Instructors] FOREIGN KEY([InstructorId])
REFERENCES Instructors ([InstructorId])
GO

ALTER TABLE Assignments CHECK CONSTRAINT [FK_Assignments_Instructors]
GO

ALTER TABLE Assignments
ADD CONSTRAINT CK_Assignments_Courses_Terms CHECK (Term IN (1,2,3,4,5,6))
GO

/*
Seed data
*/
SET IDENTITY_INSERT Instructors ON  
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(1,'Chris','Cusack',3021,0)
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(2,'Stephen','Carter',3022,0)
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(3,'Dave','Burchill',3021,1)
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(4,'Delon','Van de Venter',3022,0)
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(5,'Bonnie','Ryan',3022,0)
INSERT INTO Instructors (InstructorId,FirstName,LastName,OfficeNumber,OnSabbatical) VALUES(6,'Judson','Murray',3020,0)
SET IDENTITY_INSERT Instructors OFF

SET IDENTITY_INSERT Courses ON  
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(1,'Intro to Programming',2,90)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(2,'Intro to C++',2,90)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(3,'N-Tier',3,135)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(4,'Angular',1,45)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(5,'Node',1,45)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(6,'Fundamentals of Web',1,45)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(7,'Server Side Web',3,135)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(8,'Database Programming',2,90)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(9,'WMAD Capstone Project',2,90)
INSERT INTO Courses (CourseId,CourseName,Credits,[Hours]) VALUES(10,'Hybrid Mobile',1,45)
SET IDENTITY_INSERT Courses OFF

INSERT INTO Assignments VALUES(4,1,4,null)
INSERT INTO Assignments VALUES(5,1,4,null)
INSERT INTO Assignments VALUES(1,2,1,null)
INSERT INTO Assignments VALUES(3,2,4,null)
INSERT INTO Assignments VALUES(6,4,1,null)
INSERT INTO Assignments VALUES(6,5,1,null)
INSERT INTO Assignments VALUES(7,5,4,null)
INSERT INTO Assignments VALUES(3,6,4,null)
INSERT INTO Assignments VALUES(7,6,4,null)
INSERT INTO Assignments VALUES(2,1,1,null)
INSERT INTO Assignments VALUES(8,1,3,null)
INSERT INTO Assignments VALUES(9,1,6,null)
