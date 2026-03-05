
CREATE TABLE Store(
	StoreId INT PRIMARY KEY,
	StoreName VARCHAR(30) NOT NULL,
	City Varchar(40) NOT NULL
);


ALTER TABLE Orders
ADD StoreId INT;


ALTER TABLE Orders
ADD CONSTRAINT OrdersStore
FOREIGN KEY (StoreId)
	REFERENCES Store(StoreId);


INSERT INTO Store VALUES
(1, 'Central Store', 'Hyderabad'),
(2, 'City Mall Store', 'Bangalore'),
(3, 'Metro Store', 'Chennai');


CREATE TABLE OrderItems (
	ItemId INT PRIMARY KEY,
	OrderId INT,
	Quantity INT,
	ListPrice INT,
	Discount DECIMAL(4,2),
	FOREIGN KEY (OrderId)
		REFERENCES Orders(OrderId)
);
INSERT INTO OrderItems VALUES
(1, 101, 2, 12000, 0.10),
(2, 101, 1, 15000, 0.05),
(3, 102, 3, 8000, 0.00),
(4, 104, 1, 35000, 0.15);


SELECT * FROM Store;
SELECT * FROM Orders;
SELECT * FROM OrderItems;


UPDATE Orders SET StoreId = 1 WHERE OrderId = 101;
UPDATE Orders SET StoreId = 2 WHERE OrderId = 102;
UPDATE Orders SET StoreId = 3 WHERE OrderId = 103;
UPDATE Orders SET StoreId = 1 WHERE OrderId = 104;
UPDATE Orders SET StoreId = 2 WHERE OrderId = 105;
UPDATE Orders SET StoreId = 3 WHERE OrderId = 106;
UPDATE Orders SET StoreId = 1 WHERE OrderId = 107;


SELECT 
    s.StoreName,
    SUM(oi.Quantity * oi.ListPrice * (1 - oi.Discount)) AS TotalSales
FROM Store s
INNER JOIN Orders o 
    ON s.StoreId = o.StoreId
INNER JOIN OrderItems oi 
    ON o.OrderId = oi.OrderId
WHERE o.OrderStatus = 'Completed'
GROUP BY s.StoreName
ORDER BY TotalSales DESC;