CREATE TABLE Stocks (
    StoreId INT,
    ProductId INT,
    Quantity INT,
    PRIMARY KEY (StoreId, ProductId),
    FOREIGN KEY (StoreId) REFERENCES Store(StoreId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

INSERT INTO Stocks VALUES
(1,1,20),
(1,2,15),
(1,3,10),
(2,1,12),
(2,4,8),
(3,2,14),
(3,5,6);


ALTER TABLE OrderItems
ADD ProductId INT;

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Product
FOREIGN KEY (ProductId)
REFERENCES Products(ProductId);

UPDATE OrderItems SET ProductId = 1 WHERE ItemId = 1;
UPDATE OrderItems SET ProductId = 2 WHERE ItemId = 2;
UPDATE OrderItems SET ProductId = 5 WHERE ItemId = 3;
UPDATE OrderItems SET ProductId = 3 WHERE ItemId = 4;


SELECT 
    p.ProductName,
    s.StoreName,
    st.Quantity AS AvailableStock,
    SUM(oi.Quantity) AS TotalQuantitySold
FROM Stocks st
INNER JOIN Products p
    ON st.ProductId = p.ProductId
INNER JOIN Store s
    ON st.StoreId = s.StoreId
LEFT JOIN OrderItems oi
    ON st.ProductId = oi.ProductId
GROUP BY 
    p.ProductName,
    s.StoreName,
    st.Quantity
ORDER BY 
    p.ProductName;