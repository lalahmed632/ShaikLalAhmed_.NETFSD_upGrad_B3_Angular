CREATE DATABASE SalesDb
USE SalesDB

CREATE TABLE Stores (
    StoreID INT PRIMARY KEY,
    StoreName VARCHAR(100),
    Location VARCHAR(100)
);


CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Price DECIMAL(10,2)
);


CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    StoreID INT,
    OrderDate DATE,
    DiscountPercent DECIMAL(5,2),
    FOREIGN KEY (StoreID) REFERENCES Stores(StoreID)
);


CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Stores VALUES
(1, 'Central Store', 'Hyderabad'),
(2, 'City Mall Store', 'Vijayawada'),
(3, 'Metro Store', 'Visakhapatnam');


INSERT INTO Products VALUES
(1, 'Laptop', 60000),
(2, 'Mobile', 25000),
(3, 'Headphones', 2000),
(4, 'Keyboard', 1500),
(5, 'Mouse', 800),
(6, 'Monitor', 12000);


INSERT INTO Orders VALUES
(101, 1, '2025-01-10', 10),
(102, 1, '2025-01-15', 5),
(103, 2, '2025-02-10', NULL),
(104, 3, '2025-02-15', 8),
(105, 2, '2025-03-01', 12);

INSERT INTO OrderDetails VALUES
(1, 101, 1, 1),
(2, 101, 3, 2),
(3, 102, 2, 1),
(4, 102, 5, 3),
(5, 103, 4, 2),
(6, 103, 6, 1),
(7, 104, 2, 2),
(8, 104, 3, 1),
(9, 105, 1, 1),
(10,105, 6, 2);


SELECT * FROM Stores
SELECT * FROM Products
SELECT * FROM Orders
SELECT * FROM OrderDetails

------------------------------ Query 1 --------------------

CREATE PROCEDURE TotalSalesPerStore
AS
    BEGIN
        SELECT 
            s.StoreID,
            s.StoreName,
            SUM(p.Price * od.Quantity) AS TotalSales
            FROM Stores s
            INNER JOIN Orders o 
                ON s.StoreID = o.StoreID
            INNER JOIN OrderDetails od
                ON o.OrderID = od.OrderID
            INNER JOIN Products p
                ON od.ProductID = p.ProductID
            GROUP BY s.StoreID,s.StoreName;

    END

    EXEC TotalSalesPerStore


    CREATE PROCEDURE GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
    AS
    BEGIN
        SELECT *
        FROM Orders
        WHERE OrderDate BETWEEN @StartDate AND @EndDate;
    END;

    EXEC GetOrdersByDateRange '2025-01-01', '2025-02-01';


    CREATE FUNCTION fn_CalculateDiscountPrice
    (
            @Price DECIMAL(10,2),
            @DiscountPercent DECIMAL(5,2)
    )
    RETURNS DECIMAL(10,2)
    AS
    BEGIN
         RETURN @Price - (@Price * ISNULL(@DiscountPercent,0) / 100);
    END;

    SELECT dbo.fn_CalculateDiscountPrice(1000,10) AS FinalPrice;



    CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.ProductID,
        p.ProductName,
        SUM(od.Quantity) AS TotalSold
    FROM Products p
    INNER JOIN OrderDetails od 
        ON p.ProductID = od.ProductID
    GROUP BY p.ProductID, p.ProductName
    ORDER BY SUM(od.Quantity) DESC
);

SELECT * FROM dbo.fn_Top5SellingProducts();


----------------------------------------- Query 2---------------------------------------------------

CREATE TABLE Stock
(
    ProductID INT PRIMARY KEY,
    StockQuantity INT,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Stock VALUES
(1,10),
(2,20),
(3,50),
(4,30),
(5,40),
(6,15);


SELECT * FROM Stock


CREATE TRIGGER trg_UpdateStock
ON OrderDetails
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Stock s ON i.ProductID = s.ProductID
        WHERE s.StockQuantity < i.Quantity
    )
    BEGIN
        RAISERROR ('Not enough stock available',16,1)
        ROLLBACK TRANSACTION
        RETURN
    END

    UPDATE s
    SET s.StockQuantity = s.StockQuantity - i.Quantity
    FROM Stock s
    JOIN inserted i
    ON s.ProductID = i.ProductID

END

INSERT INTO OrderDetails VALUES (11,101,1,2)

-------------------------------------------- Query 3 ----------------------------------------------------------------

ALTER TABLE Orders
ADD OrderStatus INT,
    ShippedDate DATE;

    SELECT * FROM Orders

    CREATE TRIGGER trg_OrderStatusValidation
ON Orders
AFTER UPDATE
AS
BEGIN

    IF EXISTS (
        SELECT *
        FROM inserted
        WHERE OrderStatus = 4 AND ShippedDate IS NULL
    )
    BEGIN
        RAISERROR ('Shipped Date cannot be NULL when order is completed',16,1)
        ROLLBACK TRANSACTION
    END

END

    UPDATE Orders
    SET OrderStatus = 4
    WHERE OrderID = 101

        UPDATE Orders
    SET OrderStatus = 4,
        ShippedDate = '2025-03-10'
    WHERE OrderID = 101

    ---------------------------------------------------- Query 4 -------------------------------------------------------

    CREATE PROCEDURE CalculateRevenue
AS
BEGIN
DECLARE @OrderID INT
DECLARE @StoreID INT
DECLARE @Discount DECIMAL(5,2)
DECLARE @Revenue DECIMAL(10,2)

DECLARE order_cursor CURSOR FOR
SELECT OrderID, StoreID, DiscountPercent
FROM Orders

OPEN order_cursor

FETCH NEXT FROM order_cursor
INTO @OrderID, @StoreID, @Discount

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @Revenue =
        SUM(p.Price * od.Quantity)
    FROM OrderDetails od
    JOIN Products p
    ON od.ProductID = p.ProductID
    WHERE od.OrderID = @OrderID

    SET @Revenue = @Revenue - (@Revenue * ISNULL(@Discount,0)/100)

    PRINT 'OrderID: ' + CAST(@OrderID AS VARCHAR)
    PRINT 'Revenue: ' + CAST(@Revenue AS VARCHAR)

    FETCH NEXT FROM order_cursor
    INTO @OrderID, @StoreID, @Discount

END

CLOSE order_cursor
DEALLOCATE order_cursor
END

EXEC CalculateRevenue
