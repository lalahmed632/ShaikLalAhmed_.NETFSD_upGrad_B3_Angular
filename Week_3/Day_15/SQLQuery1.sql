CREATE DATABASE EcommDb;
USE EcommDb;

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE Brands (
    BrandID INT PRIMARY KEY,
    BrandName VARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(150) NOT NULL,
    BrandID INT,
    CategoryID INT,
    Price DECIMAL(10,2),
    
    FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(150),
    City VARCHAR(100)
);

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(150),
    City VARCHAR(100)
);


INSERT INTO Categories VALUES
(1,'Men Clothing'),
(2,'Women Clothing'),
(3,'Footwear'),
(4,'Accessories'),
(5,'Sportswear');


INSERT INTO Brands VALUES
(1,'Nike'),
(2,'Adidas'),
(3,'Puma'),
(4,'Levis'),
(5,'Zara');


INSERT INTO Products VALUES
(1,'Men Casual T-Shirt',1,1,999),
(2,'Women Denim Jacket',5,2,2999),
(3,'Running Shoes',2,3,4599),
(4,'Leather Belt',4,4,1299),
(5,'Sports Track Pants',3,5,1899);


INSERT INTO Customers VALUES
(1,'Rahul Sharma','rahul@gmail.com','Delhi'),
(2,'Ananya Gupta','ananya@gmail.com','Mumbai'),
(3,'Rohit Verma','rohit@gmail.com','Bangalore'),
(4,'Sneha Reddy','sneha@gmail.com','Hyderabad'),
(5,'Arjun Mehta','arjun@gmail.com','Pune');

INSERT INTO Stores VALUES
(1,'Fashion Hub Delhi','Delhi'),
(2,'Style Street Mumbai','Mumbai'),
(3,'Urban Wear Bangalore','Bangalore'),
(4,'Trendy Store Hyderabad','Hyderabad'),
(5,'Elite Fashion Pune','Pune');

SELECT * 
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

SELECT * FROM Categories;
SELECT * FROM Brands;
SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Stores;


------------------ Query 1 -----------------------------------
SELECT 
    p.ProductName, 
    b.BrandId, 
    c.CategoryId

FROM Products p
JOIN Brands b ON p.BrandID = b.BrandID
JOIN Categories c ON p.CategoryID = c.CategoryID;

---------------------------------------------------------------

SELECT CustomerId, CustomerName, City
FROM Customers
WHERE City = 'Hyderabad';


------------------------------------------------------------
SELECT 
    c.CategoryName,
    COUNT(p.ProductID) AS TotalProducts
FROM Categories c
LEFT JOIN Products p ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName;


--------------- QUery 2 -------------------------------------


ALTER TABLE Products
ADD ModelYear INT,
    ListPrice DECIMAL(10,2);

-----------------------------------------------------------------
CREATE VIEW ProductSummary AS
SELECT 
    p.ProductName,
    b.BrandName,
    c.CategoryName,
    p.Price
FROM Products p
JOIN Brands b 
    ON p.BrandID = b.BrandID
JOIN Categories c 
    ON p.CategoryID = c.CategoryID;

SELECT * FROM ProductSummary;
-------------------------------------------------------------
CREATE VIEW ViewOrderDetails AS
SELECT 
    c.CustomerName,
    s.StoreName,
    c.City
FROM Customers c
JOIN Stores s
    ON c.City = s.City;

SELECT * FROM ViewOrderDetails;
-------------------------------------------------------------
CREATE INDEX idxProductsBrandId
ON Products(BrandID);

CREATE INDEX idxProductsCategoryId
ON Products(CategoryID);

SELECT 
    p.ProductName,
    b.BrandName
FROM Products p
JOIN Brands b 
ON p.BrandID = b.BrandID;
--------------------------------------------------------------