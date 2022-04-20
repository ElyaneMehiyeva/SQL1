CREATE DATABASE Kitabxana 

USE Kitabxana

CREATE TABLE Authors(
   Id INT PRIMARY KEY IDENTITY,
   Name NVARCHAR(20) NOT NULL,
   Surname NVARCHAR(30) NOT NULL
)



CREATE TABLE Books(
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(100) NOT NULL CHECK (LEN(Name)>2 AND LEN(Name)<100),
  AuthorId INT FOREIGN KEY REFERENCES Authors(Id),
  PageCount INT NOT NULL CHECK (PageCount>10)
)


INSERT INTO Authors (Name,Surname)
VALUES ('William','Shakespeare'),
	   ('Franz','Kafka'),
	   ('Leo','Tolstoy'),
	   ('Jane','Austen'),
	   ('Vladimir','Nabokov'),
	   ('Marcel','Proust');
	   
INSERT INTO Books (Name,AuthorId,PageCount)
VALUES ('Ses ve ofke',1,456),
	   ('Deniz feneri',2,236),
	   ('Solgun Ates',3,321),
	   ('Lolita',4,652),
	   ('Kayip Zamanin Izinde',5,365),
	   ('Yuzyillik yalnizlik',6,524);


CREATE VIEW v_Books_Info
AS
SELECT Books.Id AS 'Book-Id',Books.Name AS 'Book-Name',Books.PageCount AS 'Page-Count',(Authors.Name+' '+Authors.Surname) AS 'Full-Name' FROM Books
JOIN Authors ON Books.AuthorId = Authors.Id



CREATE PROCEDURE p_Books_Search (@search NVARCHAR(100))
AS
SELECT Books.Id AS 'Book-Id',Books.Name AS 'Book-Name',Books.PageCount AS 'Page-Count',(Authors.Name+' '+Authors.Surname) AS 'Full-Name' FROM Books
JOIN Authors ON Books.AuthorId = Authors.Id
WHERE (Authors.Name+' '+Authors.Surname) LIKE '%'+ @search +'%'

EXEC p_Books_Search @search = 'illiam'







CREATE PROCEDURE p_Auth_Insert (@name NVARCHAR(100),@surname NVARCHAR(100))
AS
INSERT INTO Authors (Name,Surname)
VALUES (@name,@surname);

EXEC p_Auth_Insert @name = 'Test', @surname = 'Testov'

CREATE PROCEDURE p_Auth_Delete (@id INT)
AS
DELETE FROM Authors WHERE Id = @id 

EXEC p_Auth_Delete @id = 7

CREATE PROCEDURE p_Auth_Update (@id INT,@newName NVARCHAR(100),@newSurname NVARCHAR(100))
AS
UPDATE Authors 
SET Name = @newName, Surname = @newSurname
WHERE Id = @id

EXEC p_Auth_Update @id = 8,@newName = 'TestName',@newSurname = 'OvTest'

SELECT * FROM Authors