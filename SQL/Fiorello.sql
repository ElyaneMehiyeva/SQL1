CREATE DATABASE Flowers_Site

USE Flowers_Site

CREATE TABLE Sliders
(
	ID INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(200) NOT NULL,
	Text NVARCHAR(500) NOT NULL,
	Image NVARCHAR (100) NOT NULL,
	[Order] INT NOT NULL,
)

INSERT INTO Sliders (Title,Text,Image,[Order])
VALUES ('Header 1','Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. ','image1',1),
	   ('Header 2','Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. ','image2',2);


CREATE TABLE Tags
(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
)

INSERT INTO Tags (Name)
VALUES ('Lilies'),
       ('Roses')

CREATE TABLE Categories
(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
)
INSERT INTO Categories(Name)
VALUES ('ARCHIVE'),
       ('Popular')

CREATE TABLE AdditionalInfoTypes
(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
)

CREATE TABLE Products
(
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Price DECIMAL(18,2),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	DiscountAmount DECIMAL(18,2) NOT NULL,
	[Count] TINYINT,
	IsNew BIT,
	Description NVARCHAR(1500) NOT NULL,
	Code NVARCHAR(10) NOT NULL,
	CostPrice DECIMAL(18,2),
)
INSERT INTO Products(Name,Price,CategoryId,DiscountAmount,[Count],IsNew,Description,Code,CostPrice)
VALUES ('Rose',5,1,1,5,0,'Sold','rose123',1),
       ('Papatya',2,1,1,6,0,'New','papatya123',1),
	   ('TulpaN',6,1,1,4,1,'Sale','tulpan 123',1)
CREATE TABLE ProductTags
(
	ID INT PRIMARY KEY IDENTITY,
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	TagId INT FOREIGN KEY REFERENCES Tags(Id),
)
CREATE TABLE ProductImages
(
	ID INT PRIMARY KEY IDENTITY,
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	Image NVARCHAR(100) NOT NULL,
)
CREATE TABLE AdditionalInfos
(
	ID INT PRIMARY KEY IDENTITY,
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	Value NVARCHAR(100),
	AdditionalInfoTypeId INT  FOREIGN KEY REFERENCES AdditionalInfoTypes(Id),
)
CREATE TABLE Users
(
	ID INT PRIMARY KEY IDENTITY,	
	FullName NVARCHAR(35) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Image NVARCHAR(100) NOT NULL,
	PasswordHash NVARCHAR(100) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
	
)
INSERT INTO Users (Fullname,Email,Image,PasswordHash,Address)
VALUES ('Elyane Mehiyeva', 'elyane@gmail.com','image1','elayne132','Qaradag'),
       ('Aynur Islamova', 'aynur@gmail.com','image2','aynur132','Xirdalan')

CREATE TABLE Reviews
(
	ID INT PRIMARY KEY IDENTITY,	
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	UserId INT FOREIGN KEY REFERENCES Users(Id),
	Email NVARCHAR(100) NOT NULL,
	Name NVARCHAR(35) NOT NULL,
	Text NVARCHAR(350) NOT NULL,
	CreatedAt DateTime NOT NULL DEFAULT(GETDATE()),
)
CREATE TABLE Orders
(
	ID INT PRIMARY KEY IDENTITY,	
	UserId INT FOREIGN KEY REFERENCES Users(Id),
	DeliveredAt DateTime NOT NULL DEFAULT(GETDATE()),
	CreatedAt DateTime NOT NULL DEFAULT(GETDATE()),
	Status TINYINT,
	PaymentStatus TINYINT,
	TotalAmount DECIMAL(18,2) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	FullName NVARCHAR(100) NOT NULL,
)

INSERT INTO Orders (UserId,Status,PaymentStatus,TotalAmount,Address,Email,FullName)
VALUES (1,23,12,456,'Baki','baki@gmail.com','Subhan Mehiyev'),
       (2,43,22,46,'Goycay','nar@gmail.com','Arzu Abdullayeva')


CREATE TABLE OrderItems
(
	ID INT PRIMARY KEY IDENTITY,	
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	OrderId INT FOREIGN KEY REFERENCES Orders(Id),
	[Count] INT,
	Price DECIMAL(18,2) NOT NULL,
	DiscountAmount DECIMAL(18,2) NOT NULL,
	CostPrice DECIMAL(18,2) NOT NULL,
	CreatedAt DateTime NOT NULL DEFAULT(GETDATE()),
)

INSERT INTO OrderItems (ProductId,OrderId,[Count],Price,DiscountAmount,CostPrice)
VALUES (1,1,2,5,3,4),
       (2,2,5,12,1,2)

SELECT * FROM Products

SELECT 
O.ID,
O.FullName,
O.Email,
O.DeliveredAt,
O.UserId, 
(SELECT COUNT(*) FROM OrderItems WHERE OrderItems.OrderId = O.ID) AS 'COUNT' FROM Orders AS O
INNER JOIN OrderItems AS OrdI ON OrdI.OrderId = O.ID


SELECT 
O.ID,
O.FullName,
O.Email,
O.DeliveredAt,
O.UserId, 
(SELECT COUNT(*) FROM OrderItems WHERE OrderItems.OrderId = O.ID) AS 'COUNT' FROM Orders AS O
INNER JOIN OrderItems AS OrdI ON OrdI.OrderId = O.ID
WHERE (SELECT COUNT(*) FROM OrderItems WHERE OrderItems.OrderId = O.ID) = 0


SELECT 
O.ID,
O.FullName,
O.Email,
O.DeliveredAt,
O.UserId, 
(SELECT COUNT(*) FROM OrderItems WHERE OrderItems.OrderId = O.ID) AS 'COUNT' FROM Orders AS O
INNER JOIN OrderItems AS OrdI ON OrdI.OrderId = O.ID
WHERE (SELECT COUNT(*) FROM OrderItems WHERE OrderItems.OrderId = O.ID) = 1



SELECT U.ID,U.FullName,U.Email,O.TotalAmount,(SELECT COUNT(*) FROM Orders WHERE O.UserId = U.ID) AS 'TotalOrderCount' FROM Users AS U
JOIN Orders AS O ON O.UserId = U.Id

SELECT U.ID,U.FullName,U.Email,(SELECT SUM(TotalAmount) FROM Orders) AS 'TotalOrderAmount',(SELECT COUNT(*) FROM Orders WHERE O.UserId = U.ID) AS 'TotalOrderCount' FROM Users AS U
JOIN Orders AS O ON O.UserId = U.Id

CREATE PROCEDURE v_GetUserInfo(@fullname NVARCHAR, @email NVARCHAR, @passwordHASH NVARCHAR, @image NVARCHAR , @adress NVARCHAR)
AS
INSERT INTO Users (Fullname,Email,PasswordHash,Image,Address)
VALUES (@fullname,@email,@passwordHASH,@image,@adress)

SELECT Users.ID, Users.FullName, Users.Email FROM Users
