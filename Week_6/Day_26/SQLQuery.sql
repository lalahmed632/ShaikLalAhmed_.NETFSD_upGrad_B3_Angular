
CREATE DATABASE Products
USE Products;

CREATE TABLE _Products (
ProductId INT PRIMARY KEY IDENTITY(1,1),
ProductName VARCHAR(100),
Category VARCHAR(50),
Price DECIMAL(10,2)
);


-- Insert

CREATE PROCEDURE usp_InsertProduct
@ProductName VARCHAR(100),
@Category VARCHAR(50),
@Price DECIMAL(10,2)
AS
BEGIN
INSERT INTO _Products (ProductName, Category, Price)
VALUES (@ProductName, @Category, @Price);
END

-- view

CREATE PROCEDURE usp_GetAllProducts
AS
BEGIN
SELECT * FROM _Products;
END

-- Update

CREATE PROCEDURE usp_UpdateProduct
@ProductId INT,
@ProductName VARCHAR(100),
@Category VARCHAR(50),
@Price DECIMAL(10,2)
AS
BEGIN
UPDATE _Products
SET ProductName = @ProductName,
Category = @Category,
Price = @Price
WHERE ProductId = @ProductId;
END

-- Delete

CREATE PROCEDURE usp_DeleteProduct
@ProductId INT
AS
BEGIN
DELETE FROM _Products WHERE ProductId = @ProductId;
END

-- get element by id

CREATE PROCEDURE usp_GetProductById
@ProductId INT
AS
BEGIN
SELECT * FROM _Products WHERE ProductId = @ProductId;
END

select * from _products;