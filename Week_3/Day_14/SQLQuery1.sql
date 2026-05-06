
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(50)
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    discontinued BIT,
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE archived_orders (
    order_id INT,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT
);

INSERT INTO categories VALUES
(1, 'Mountain Bikes'),
(2, 'Road Bikes'),
(3, 'Electric Bikes');


INSERT INTO products VALUES
(101, 'Trail Bike', 1, 2019, 1200, 0),
(102, 'Speed Bike', 2, 2020, 1500, 0),
(103, 'Eco Ride', 3, 2021, 2000, 0),
(104, 'Hill Master', 1, 2018, 1800, 1),
(105, 'Street Racer', 2, 2022, 2200, 0);


INSERT INTO customers VALUES
(1, 'John', 'Smith', 'john@gmail.com'),
(2, 'Alice', 'Brown', 'alice@gmail.com'),
(3, 'David', 'Lee', 'david@gmail.com'),
(4, 'Emma', 'Wilson', 'emma@gmail.com')


INSERT INTO stores VALUES
(1, 'Central Store'),
(2, 'City Bike Hub');;


INSERT INTO orders VALUES
(1001, 1, 4, '2024-01-10', '2024-01-15', '2024-01-14', 1),
(1002, 2, 2, '2024-02-05', '2024-02-10', '2024-02-11', 1),
(1003, 3, 4, '2024-03-01', '2024-03-05', '2024-03-04', 2),
(1004, 1, 3, '2023-01-01', '2023-01-05', '2023-01-04', 2);


INSERT INTO order_items VALUES
(1, 1001, 101, 2, 1200, 0.10),
(2, 1001, 102, 1, 1500, 0.05),
(3, 1002, 103, 1, 2000, 0.00),
(4, 1003, 105, 3, 2200, 0.15),
(5, 1004, 104, 1, 1800, 0.20);

INSERT INTO stocks VALUES
(1, 101, 10),
(1, 102, 5),
(1, 103, 0),
(2, 104, 0),
(2, 105, 8);

--------------------------------- Query 1 -------------------------
SELECT 
    CONCAT(product_name, ' (', model_year, ')') AS product_details,
    list_price,
    (
        SELECT AVG(p2.list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS category_avg_price,
    list_price - (
        SELECT AVG(p3.list_price)
        FROM products p3
        WHERE p3.category_id = p1.category_id
    ) AS price_difference
FROM products p1
WHERE list_price >
(
    SELECT AVG(p4.list_price)
    FROM products p4
    WHERE p4.category_id = p1.category_id
);


------------------------------- Query 2 ---------------------------------

SELECT 
    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
    total_value,
    CASE
        WHEN total_value > 10000 THEN 'Premium'
        WHEN total_value BETWEEN 5000 AND 10000 THEN 'Regular'
        ELSE 'Basic'
    END AS customer_category
FROM customers c
JOIN
(
    SELECT 
        o.customer_id,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_value
    FROM orders o
    JOIN order_items oi ON o.order_id = oi.order_id
    GROUP BY o.customer_id
) AS order_totals
ON c.customer_id = order_totals.customer_id

UNION

SELECT 
    CONCAT(first_name, ' ', last_name) AS customer_name,
    NULL AS total_value,
    'No Orders' AS customer_category
FROM customers
WHERE customer_id NOT IN
(
    SELECT DISTINCT customer_id FROM orders
);

------------------------ Query 3 ------------------------------------------------

SELECT 
    s.store_name,
    p.product_name,
    SUM(oi.quantity) AS total_quantity_sold,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_revenue
FROM stores s
JOIN orders o ON s.store_id = o.store_id
JOIN order_items oi ON o.order_id = oi.order_id
JOIN products p ON oi.product_id = p.product_id
JOIN stocks st ON p.product_id = st.product_id AND s.store_id = st.store_id
WHERE st.quantity = 0
GROUP BY s.store_name, p.product_name;


SELECT product_id
FROM order_items
INTERSECT
SELECT product_id
FROM stocks
WHERE quantity = 0;

SELECT product_id
FROM order_items
EXCEPT
SELECT product_id
FROM stocks
WHERE quantity > 0;

UPDATE stocks
SET quantity = 0
WHERE product_id IN
(
    SELECT product_id
    FROM products
    WHERE discontinued = 1
);




--------------------------------- Query 4 ------------------------------------------------------------

INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());


SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
    SELECT COUNT(*)
    FROM orders o2
    WHERE o2.customer_id = orders.customer_id
    AND order_status = 4
);

        SELECT 
        order_id,
        DATEDIFF(day, order_date, shipped_date) AS processing_delay
    FROM orders;


    SELECT 
    order_id,
    order_date,
    required_date,
    shipped_date,
    CASE
        WHEN shipped_date > required_date THEN 'Delayed'
        ELSE 'On Time'
    END AS delivery_status
FROM orders;