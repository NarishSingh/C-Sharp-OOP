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

-- table
IF EXISTS(SELECT *
          FROM sys.tables
          WHERE name = 'Customer')
    DROP TABLE Customer;
GO

CREATE TABLE Customer
(
    Id   INT NOT NULL PRIMARY KEY,
    Name VARCHAR(30),
    Salary INT
);
GO

-- values
INSERT INTO Customer(Id, Name, Salary)
VALUES (1, 'Tom', 90000),
       (2, 'Dick', 96000),
       (3, 'Harry', 89000),
       (4, 'Mary', 126000),
       (5, 'Jay', 102000);
GO

SELECT * FROM Customer;