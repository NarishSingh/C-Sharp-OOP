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
    Name VARCHAR(30)
);
GO

-- values
INSERT INTO Customer(Id, Name)
VALUES (1, 'Tom'),
       (2, 'Dick'),
       (3, 'Harry'),
       (4, 'Mary'),
       (5, 'Jay');
GO

SELECT * FROM Customer;