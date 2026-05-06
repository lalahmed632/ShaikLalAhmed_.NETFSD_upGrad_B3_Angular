CREATE DATABASE AutoRetail2;
USE AutoRetail2;

CREATE TABLE Products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    stock_quantity INT
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY,
    order_date DATE,
    order_status INT
);

CREATE TABLE Order_Items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES Orders(order_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

INSERT INTO Products VALUES
(1,'Car Battery',10),
(2,'Brake Pad',20),
(3,'Oil Filter',15),
(4,'Head Light',12),
(5,'Engine Oil',25);


INSERT INTO Orders VALUES
(101,'2024-01-10',1),
(102,'2024-01-12',1),
(103,'2024-01-15',2),
(104,'2024-01-18',1),
(105,'2024-01-20',2);

INSERT INTO Order_Items VALUES
(1,101,1,5),
(2,101,3,10),
(3,102,2,15),
(4,102,4,5),
(5,103,5,20);


-------------------------------------------------------- Query 1 --------------------------------------------------------------


ALTER TABLE Products
ADD stock_quantity INT;

UPDATE Products SET stock_quantity = 20 WHERE ProductID = 1;
UPDATE Products SET stock_quantity = 15 WHERE ProductID = 2;


CREATE TRIGGER trg_UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM Products p
        JOIN inserted i ON p.product_id = i.product_id
        WHERE p.stock_quantity < i.quantity
    )
    BEGIN
        RAISERROR ('Insufficient stock for this product',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END


    UPDATE p
    SET p.stock_quantity = p.stock_quantity - i.quantity
    FROM Products p
    JOIN inserted i ON p.product_id = i.product_id;
END;




BEGIN TRANSACTION;

BEGIN TRY

INSERT INTO Orders (order_id, order_date, order_status)
VALUES (106, GETDATE(), 1);

INSERT INTO Order_Items (order_item_id, order_id, product_id, quantity)
VALUES 
(6,106,1,3),
(7,106,2,5);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION;

PRINT 'Order failed due to insufficient stock';

END CATCH;




BEGIN TRANSACTION;

INSERT INTO Orders VALUES (107, GETDATE(),1);

INSERT INTO Order_Items VALUES (8,107,1,50);

COMMIT;


SELECT * FROM Products;
SELECT * FROM Orders;
SELECT * FROM Order_Items;


--------------------------------------------------- Query 2 ---------------------------------------------------------------------

        CREATE PROCEDURE CancelOrder
            @OrderID INT
        AS
        BEGIN

        BEGIN TRY

            BEGIN TRANSACTION

            SAVE TRANSACTION RestoreStockPoint

            UPDATE s
            SET s.StockQuantity = s.StockQuantity + od.Quantity
            FROM Stock s
            JOIN OrderDetails od
                ON s.ProductID = od.ProductID
            WHERE od.OrderID = @OrderID

            UPDATE Orders
            SET OrderStatus = 3
            WHERE OrderID = @OrderID

            COMMIT TRANSACTION

            PRINT 'Order cancelled successfully'

        END TRY


        BEGIN CATCH

            PRINT 'Error occurred. Rolling back to savepoint.'

            ROLLBACK TRANSACTION RestoreStockPoint

        END CATCH

        END


        EXEC CancelOrder 101

        SELECT * FROM Stock

        SELECT OrderID, OrderStatus
        FROM Orders

