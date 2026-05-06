CREATE TABLE Customers(
    CustomerId INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);

CREATE TABLE Orders(
    OrderId INT PRIMARY KEY,
    CustomerId INT,
    OrderDate DATE NOT NULL,
    OrderStatus VARCHAR(30)
    FOREIGN KEY (CustomerId)
        REFERENCES Customers(CustomerId)
);

INSERT INTO Customers VALUES
(1,'Lal','Ahmed'),
(2,'Sharan','Kumar'),
(3,'Arun','Narendula'),
(4,'Sujal','Bharadhwaj'),
(5,'Vishwajith','Sharma'),
(6,'Revanth','Kumar');

INSERT INTO Orders VALUES
(101,1,'2025-01-10','Completed'),
(102,2,'2025-01-12','Pending'),
(103,3,'2025-01-15','Shipped'),
(104,4,'2025-01-18','Completed'),
(105,5,'2025-01-20','Cancelled'),
(106,6,'2025-01-21','Pending');

INSERT INTO Customers VALUES
(10,'Rahul','Patel');

INSERT INTO Orders VALUES
(107,10,'2025-01-25','Pending');

INSERT INTO Customers VALUES
(11,'Amit','Verma');

SELECT * FROM Customers;
SELECT * FROM Orders;

SELECT 
    c.FirstName,
    c.LastName,
    o.OrderId,
    o.OrderDate,
    o.OrderStatus
FROM Customers AS c
INNER JOIN Orders AS o
ON c.CustomerId = o.CustomerId
WHERE o.OrderStatus = 'Pending' OR o.OrderStatus = 'Completed'
ORDER BY o.OrderDate DESC;
