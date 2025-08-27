--DROP DATABASE IF EXISTS MilkmanFarmsDB;
--GO

--CREATE DATABASE MilkmanFarmsDB; 
--GO

USE MilkmanFarmsDB; 
GO

--CREATE TABLE Products (
--	ProductId INT PRIMARY KEY IDENTITY(1,1), 
--	Name VARCHAR(35) NOT NULL, 
--	Price DECIMAL(6, 2) NOT NULL,
--	Category VARCHAR (40), 
--);

--CREATE TABLE Customers (
--	CustomerId INT PRIMARY KEY IDENTITY(1,1), 
--	FirstName VARCHAR(100) NOT NULL,
--	LastName NVARCHAR(100) NOT NULL,
--	Email NVARCHAR(150),
--	Address NVARCHAR(200) NOT NULL, 
--	Phone NVARCHAR(13)
--);

--CREATE TABLE Orders (
--	OrderId INT PRIMARY KEY IDENTITY(1,1), 
--	CustomerId INT FOREIGN KEY REFERENCES Customers(CustomerId), 
--	OrderDate DATE, 
--	OrderTotal DECIMAL(8,2)
--); 

--CREATE TABLE OrderDetails (
--	OrderDetailId INT PRIMARY KEY IDENTITY(1,1), 
--	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId), 
--	ProductId INT FOREIGN KEY REFERENCES Products(ProductId), 
--	Quantity INT -- Quantity of each productid 
--);

--INSERT INTO Products (Name, Price, Category)
--VALUES 
--	('Martins Classic', 7.49, 'Dairy Product'), 
--	('Aunt May Berry Pie', 8.49, 'Dairy Product'), 
--	('Little Chubbs Chocolate Delight', 7.49, 'Dairy Product'),
--	('Martin Cow Plushie', 14.99, 'Merchandise');


---- sample customers 
--INSERT INTO Customers (FirstName, LastName, Email, Phone, StreetAddress, City, State)
--VALUES ('Martin', 'Cow', 'martincow@milkmanfarms.com',
--				1234567890, '432 Cow Prairie Ln', 'Louisville', 'Kentucky'),
				
--	   ('Maybelle', 'Cow', 'Aunt_Mayberry@milkmanfarms.com',
--				2229022133, '502 Moo Moo Blvd', 'Los Angeles', 'California'),

--	   ('Betty Sue', 'Buttersby', 'buttermilk3etty@milkmanfarms.com',
--				1235012559, '432 Grassfed Beef Loop', 'Louisville', 'Kentucky'); 

SELECT * FROM Products;
SELECT * FROM Customers;


