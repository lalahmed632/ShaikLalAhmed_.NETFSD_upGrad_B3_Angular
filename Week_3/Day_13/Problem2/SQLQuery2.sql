CREATE TABLE Products(

ProductId INT PRIMARY KEY,
ProductName VARCHAR(30) NOT NULL,
ListPrice INT NOT NULL,
ModelYear Date NOT NULL

);
INSERT INTO Products VALUES
(1, 'Mountain Bike', 12000, '2023-01-01'),
(2, 'Road Bike', 15000, '2022-01-01'),
(3, 'Electric Bike', 35000, '2024-01-01'),
(4, 'Hybrid Bike', 18000, '2023-06-01'),
(5, 'Kids Bike', 8000, '2021-01-01');

INSERT INTO Products VALUES
(6, 'Playing Cards', 200, '2021-02-01'),
(7, 'Toy Car', 300, '2021-07-01'),
(8, 'Business Board Game', 500, '2021-02-01');

CREATE TABLE Brands(

BrandId INT PRIMARY KEY ,
ProductId INT,
BrandName VARCHAR(50)

FOREIGN KEY (ProductId)
	REFERENCES Products(ProductId)

);
INSERT INTO Brands VALUES
(101, 1, 'Trek'),
(102, 2, 'Giant'),
(103, 3, 'Specialized'),
(104, 4, 'Cannondale'),
(105, 5, 'Hero');

INSERT INTO Brands VALUES
(106, 6, 'Funskool'),
(107, 7, 'Hot Wheels'),
(108, 8, 'Hasbro');

CREATE TABLE Categories(

CategoryId INT PRIMARY KEY ,
ProductId INT,
CategoryName VARCHAR(30),
FOREIGN KEY (ProductId)
	REFERENCES Products(ProductId)

);
INSERT INTO Categories VALUES
(201, 1, 'Mountain'),
(202, 2, 'Road'),
(203, 3, 'Electric'),
(204, 4, 'Hybrid'),
(205, 5, 'Kids');

INSERT INTO Categories VALUES
(206, 6, 'Card Game'),
(207, 7, 'Toy'),
(208, 8, 'Board Game');

SELECT * FROM Products;
SELECT * FROM Brands;
SELECT * FROM Categories;


SELECT
	p.ProductName,
	b.BrandName,
	c.CategoryName,
	p.ModelYear,
	p.ListPrice
FROM Products AS p
INNER JOIN Brands AS b
ON p.ProductId = b.ProductId
INNER JOIN Categories AS c
ON p.ProductId = c.ProductId
WHERE p.ListPrice > 500
ORDER BY p.ListPrice ;
