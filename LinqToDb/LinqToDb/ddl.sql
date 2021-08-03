USE master;
GO

IF EXISTS(SELECT *
          FROM sys.databases
          WHERE name = 'LinqEFCoreTest')
    DROP DATABASE LinqEFCoreTest;
GO

CREATE DATABASE LinqEFCoreTest;
GO

USE LinqEFCoreTest;
GO

-- CUSTOMERS
IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Customer')
    DROP TABLE Customer;
GO

CREATE TABLE Customer
(
    Id     INT NOT NULL PRIMARY KEY,
    Name   VARCHAR(30),
    Salary INT
);
GO

INSERT INTO Customer(Id, Name, Salary)
VALUES (1, 'Tom', 90000),
       (2, 'Dick', 96000),
       (3, 'Harry', 89000),
       (4, 'Mary', 126000),
       (5, 'Jay', 102000);
GO

SELECT *
FROM Customer;

-- PURCHASES
IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Purchase')
    DROP TABLE Purchase;
GO

CREATE TABLE Purchase
(
    Id          INT            NOT NULL IDENTITY PRIMARY KEY,
    Date        DATETIME2      NOT NULL,
    Description NVARCHAR(30)   NOT NULL,
    Price       DECIMAL(12, 2) NOT NULL,
    CustomerId  INT            NOT NULL
        REFERENCES Customer (Id)
)
GO

INSERT INTO Purchase(Date, Description, Price, CustomerId)
VALUES ('2021-01-01 00:00:00', 'Ferrari', 1234567.25, 1),
       ('2021-01-02 00:00:00', 'Lamborghini', 3.99, 1),
       ('2021-01-03 00:00:00', 'Moncler Coat', 100.56, 1),
       ('2021-02-01 00:00:00', 'Nike Air Force 1', 98.97, 2),
       ('2021-02-02 00:00:00', 'Porsche', 999999999.03, 2),
       ('2021-02-03 00:00:00', 'Louis Vuitton', 56.36, 2),
       ('2021-03-05 00:00:00', 'PS4', 5.01, 3),
       ('2021-03-09 00:00:00', 'Xbox 1', 6.98, 3),
       ('2021-03-15 00:00:00', 'Gucci Wallet', 10536.99, 4),
       ('2021-04-22 00:00:00', 'Borgar', 3000.99, 4),
       ('2021-04-23 00:00:00', 'The County of Westchester', 0.23, 5),
       ('2021-04-30 00:00:00', '[REDACTED]', 99999999.99, 5),
       ('2021-05-16 00:00:00', 'Pet Amoeba', 87.81, 5);
GO

SELECT *
FROM Purchase;