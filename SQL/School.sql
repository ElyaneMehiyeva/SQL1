CREATE DATABASE School

USE School

CREATE TABLE Subjects(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(20) NOT NULL
)

INSERT INTO Subjects (Name)
VALUES ('Rus Dili'),('Riyaziyyat'),('Mentiq'),('Zoologiya'),('Anatomiya'),('Botanika');

CREATE TABLE Groups(
   Id INT PRIMARY KEY IDENTITY,
   No NVARCHAR(10) NOT NULL
)

INSERT INTO Groups (No)
VALUES ('368A2'), ('659A3'), ('520A1')

CREATE TABLE Students(
   Id INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(10) NOT NULL,
   Surname NVARCHAR(10) NOT NULL,
   GroupId INT FOREIGN KEY REFERENCES Groups(Id)
)

INSERT INTO Students (Name,Surname,GroupId)
VALUES ('Elyane','Mehiyeva',1),
       ('Aynur','Islamova',2),
	   ('Subhan','Mehiyev',3),
	   ('Aysu','Mehiyeva',3)


CREATE TABLE Exams(
  Id INT PRIMARY KEY IDENTITY,
  Date DATETIME2 NOT NULL ,
  Subjectid INT FOREIGN KEY REFERENCES Subjects(Id)
)

INSERT INTO Exams (Date,Subjectid)
VALUES ('2022-02-15',4);


INSERT INTO Exams (Date,SubjectId)
VALUES ('2022-03-07',1),('2022-02-22',2),('2022-04-12',3),('2022-04-12',3),('2022-04-12',1),('2022-04-12',2);

CREATE TABLE StudentExams(
  Id INT PRIMARY KEY IDENTITY,
  Result TINYINT NOT NULL,
  StudentId INT FOREIGN KEY REFERENCES Students(Id),
  ExamId INT FOREIGN KEY REFERENCES Exams(Id),
)

INSERT INTO StudentExams (Result, StudentId, ExamId)
VALUES (91,1,1),
       (51,2,3),
	   (65,3,4),
	   (88,4,5)

INSERT INTO StudentExams (Result, StudentId, ExamId)
VALUES (0,1,5)

INSERT INTO StudentExams (Result, StudentId, ExamId)
VALUES (0,2,5)

SELECT Students.Id,Students.Name,Students.Surname,Students.GroupId,Groups.No AS 'Group No' FROM Students
INNER JOIN Groups ON Students.Id = Groups.Id

SELECT S.Id,S.Name,S.Surname,S.GroupId, (SELECT COUNT(*) FROM StudentExams WHERE (S.Id = StudentExams.StudentId)) AS 'Imtahan Sayi' FROM Students as S
INNER JOIN StudentExams AS SE ON SE.StudentId = S.Id

SELECT S.Id,S.Name,(SELECT COUNT(*) FROM Exams WHERE (Exams.Subjectid = S.Id)) AS 'Exam Count' FROM Subjects AS S
FULL OUTER JOIN Exams AS E ON S.Id = E.Subjectid
WHERE (SELECT COUNT(*) FROM Exams WHERE (S.Id = Exams.Subjectid)) = 0


SELECT Exams.Id,Exams.Date,Exams.Subjectid, (SELECT COUNT(*) FROM StudentExams WHERE StudentExams.ExamId = Exams.Id) AS 'Student Count',Subjects.Name FROM Exams
INNER JOIN StudentExams ON Exams.Id = StudentExams.ExamId
INNER JOIN Subjects ON Exams.Subjectid = Subjects.Id
WHERE Exams.Date = '2022-04-12'



SELECT S.Id,S.Name,S.Surname,S.GroupId,(SELECT AVG(Result) FROM StudentExams WHERE StudentExams.StudentId = S.Id) FROM Students as S
FULL OUTER JOIN StudentExams as SE ON S.Id = SE.StudentId
