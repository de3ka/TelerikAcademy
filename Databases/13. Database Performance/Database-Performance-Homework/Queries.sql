USE LogsDB;
-----------------------------------------------------------------------------------------
-- TASK 01: Create a table in SQL Server with 10 000 000 log entries (date + text). 
-- Search in the table by date range. Check the speed (without caching).                               
-----------------------------------------------------------------------------------------

SELECT * FROM Logs
WHERE Date >= CAST('20000101 01:01:15.000' AS DATETIME)
	AND DATE <= CAST('20000101 01:01:25.000' AS DATETIME)

-----------------------------------------------------------------------------------------
-- TASK 02: Add an index to speed-up the search by date. Test the search speed (after 
-- cleaning the cache).                               
-----------------------------------------------------------------------------------------

CREATE INDEX IDX_Logs_Date
ON Logs(Date)

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE Date >= CAST('20000101 01:01:15.000' AS DATETIME)
	AND DATE <= CAST('20000101 01:01:25.000' AS DATETIME)

-----------------------------------------------------------------------------------------
-- TASK 03: Add a full text index for the text column. Try to search with and without 
-- the full-text index and compare the speed.                              
-----------------------------------------------------------------------------------------

-- Creating full-text catalog and full-text index
CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

-- You have to rename the primary key constraint to PK_Logs before this operation
CREATE FULLTEXT INDEX ON Logs(Text)
KEY INDEX PK_Logs  
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO


-- Searching without full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Logs
WHERE Text LIKE 'Today'
GO

-- Searching with full-text index
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM Logs
WHERE CONTAINS(Text, 'Today')
GO

-----------------------------------------------------------------------------------------
-- TASK 04: Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random 
-- dates) to certain partition (e.g. year 1995).                           
-----------------------------------------------------------------------------------------


-- Without partitioning
CREATE SCHEMA `logsdb`;

CREATE TABLE `logsdb`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Text` TEXT NOT NULL,
	`Date` DATETIME NOT NULL,
	PRIMARY KEY (`Id`));

-- With partitioning
CREATE SCHEMA `logsdb`;

CREATE TABLE `logsdb`.`logs` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Text` TEXT NOT NULL,
	`Date` DATETIME NOT NULL,
	PRIMARY KEY (`Id`, `Date`)
) PARTITION BY RANGE(YEAR(Date)) (
    PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010),
    PARTITION p3 VALUES LESS THAN MAXVALUE
);

-- EXPLAIN PARTITIONS SELECT * FROM Logs;