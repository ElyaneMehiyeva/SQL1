CREATE DATABASE Blog

USE Blog

CREATE TABLE Users(
   Id INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(10) NOT NULL CHECK (LEN(Name) > 3),
   Surname NVARCHAR(20) NOT NULL CHECK (LEN(Surname) > 3),
   Email NVARCHAR(100) NOT NULL UNIQUE CONSTRAINT USR_BL CHECK (LEN(Email) BETWEEN 4 AND 100), 
);

INSERT INTO Users (Name,Surname,Email)
VALUES ('Elyane','Mehiyeva','mehiyevaelya@gmail.com'),
('Gulgun','Mehiyeva','gulgunmehiyeva@gmail.com'),
('Aynur','Islamova','aynurislam@gmail.com'),
('Nermin','Kerimli','kerimlinermin@gmail.com'),
('Entiqe','Mehiyeva','mehiyeva999@gmail.com'),
('Jale','Memmedova','memmeddd@gmail.com'),
('Nurane','Kerimova','kerimova@gmail.com'),
('Dilare','Bagirova','bagirova@gmail.com');



SELECT * FROM Users



CREATE TABLE Posts(
    Id INT PRIMARY KEY IDENTITY,
    LikeCount INT NOT NULL CHECK (LikeCount>=0),
	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
	Title NVARCHAR(500) NOT NULL,
	UserId INT,
	FOREIGN KEY (UserId) REFERENCES Users(Id)
);

INSERT INTO Posts (LikeCount,Title,UserId)
VALUES (9000,'Commands completed successfully.Completion time: 2022-04-12T10:55:12.5429480+04:00',1),
(1256,'Lets get another registrant and see what the data looks like.',3),
(345,'Add default value of datetime field in SQL Server to a timestamp',4),
(311,'Lets get another registrant and see what the data looks like.',3),
(21,'Add default value of datetime field in SQL Server to a timestamp',3),
(512,'Lets get another registrant and see what the data looks like.',5),
(518,'Question In MS Access you can simply type "Now()" as the default attribute of a date field, and every new record gets the current date automatically. Is there a similar way to do this in SQL Server, please? Nothing Ie tried so far works.',1),
(1456,'Lets get another registrant and see what the data looks like.',1),
(1222,'I am using SQL Developer with Oracle DB:',4),
(233,'Lets get another registrant and see what the data looks like.',8),
(45,'Earn 10 reputation (not counting the association bonus) in order to answer this question.',3),
(12345,'When retrieving the values, the front end application/website should transform this value from UTC time to the locale/culture of the user requesting it.',4),
(12,'This worked for me. I am using SQL Developer with Oracle DB:',3),
(0,'To make it simpler to follow, I will summarize the above answers',2),
(890,'Highly active question. Earn 10 reputation (not counting the association bonus) in order to answer this question. The reputation requirement helps protect this question from spam and non-answer activity.',2);

SELECT * FROM Posts

SELECT * FROM Posts ORDER BY LikeCount DESC

SELECT * FROM Posts ORDER BY LikeCount ASC

SELECT COUNT(*) FROM Posts

SELECT COUNT(*) AS 'SAY' FROM Posts

SELECT COUNT(*) AS SAY FROM Posts

SELECT * FROM Posts WHERE LikeCount > 500

SELECT COUNT(*) FROM Posts WHERE LikeCount > 500

SELECT COUNT(*) AS 'RandomName' FROM Posts WHERE LikeCount > 500

SELECT SUM(LikeCount) FROM Posts

SELECT SUM(LikeCount) AS TotalLikeCount FROM Posts

SELECT SUM(LikeCount) AS 'Total Like Count' FROM Posts

SELECT AVG(LikeCount) FROM Posts

SELECT AVG(LikeCount) AS 'Average of LikeCount' FROM Posts


SELECT Name + Surname FROM Users
SELECT Name + Surname AS 'Full Name' FROM Users
SELECT Name + ' ' + Surname AS 'Full Name' FROM Users


SELECT * FROM Posts WHERE LikeCount > 10


SELECT * FROM Users WHERE (SELECT COUNT(*) FROM Posts WHERE (Users.Id = Posts.UserId)) = 0

SELECT * FROM Posts WHERE LikeCount > (SELECT AVG(LikeCount) FROM Posts)

SELECT Name,Title FROM Posts 
INNER JOIN Users On Users.Id = Posts.UserId

SELECT Name as 'Postun Sahibi',Title as 'Postun Bashligi' FROM Posts 
INNER JOIN Users On Users.Id = Posts.UserId
