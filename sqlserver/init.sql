CREATE DATABASE transactions_db;
GO

USE transactions_db;
GO

CREATE TABLE transactions (
    id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    amount DECIMAL(10,2) NOT NULL,
    transaction_date DATETIME DEFAULT CURRENT_TIMESTAMP
);
GO

INSERT INTO transactions (user_id, amount) VALUES
(1, 100.50),
(2, 200.75);
GO