---1.Create a database with two tables:
---Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).

USE TSQLHomework

CREATE TABLE Persons(
	Id int IDENTITY PRIMARY KEY ,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(50)
)
GO

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY,
	PersonId int,
	Balance money
)

ALTER TABLE Accounts
	ADD CONSTRAINT FK_ACCOUNTS_PERSONS
		FOREIGN KEY(PersonId)
		REFERENCES Persons(Id)

GO

---Insert few records for testing.

INSERT INTO Persons 
	VALUES 
	('John', 'Doe', '1234567890'),
	('Strahil', 'Bojikravov', '1234567891'),
	('Peter', 'Parker', '1234567892'),
	('Bruce', 'Wayne', '1234567893')
GO

INSERT INTO Accounts
	VALUES
	(1, 2000),
	(2, 4500),
	(3, 7500),
	(4, 10000)
GO

SELECT p.FirstName, p.LastName, a.Balance
FROM Persons p
JOIN Accounts a
	ON a.PersonId = p.Id
GO

---2.Create a stored procedure that accepts a number as a parameter 
---and returns all persons who have more money in their accounts than the supplied number.

CREATE PROCEDURE usp_PersonsWithMoreMoneyThan(@minimumAmount money = 0)
	AS
		SELECT *
		FROM Persons p
		JOIN Accounts a
			ON a.PersonId = p.Id
		WHERE a.Balance > @minimumAmount
GO

EXEC usp_PersonsWithMoreMoneyThan 7000

GO

---3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
---It should calculate and return the new sum.
---Write a SELECT to test whether the function works as expected.

USE TSQLHomework
GO
CREATE FUNCTION ufn_CalculateInterest(@amount money, @interestPerYear money, @periodInMonths int)
	RETURNS money
	AS
		BEGIN
			DECLARE @result money, @interest money
			SET @interest = @interestPerYear / 12 * @periodInMonths
			SET @result = (@amount * @interest) + @amount

			RETURN @result
		END
GO

USE TSQLHomework

SELECT dbo.ufn_CalculateInterest(1000, 10, 12)

GO

---4. Create a stored procedure that uses the function from the previous example to give an 
---interest to a person's account for one month.
---It should take the AccountId and the interest rate as parameters.

GO

CREATE PROCEDURE usp_AddInterestForOneMonth (@accountID INT,@interest DECIMAL)
	AS
		UPDATE Accounts 
		SET Balance = dbo
			.ufn_CalculateInterest(
				(SELECT a.Balance 
					FROM Accounts a 
					WHERE a.Id = @accountId), 
				@interest, 
				1)
		WHERE Id = @accountId
GO


EXEC usp_AddInterestForOneMonth 1, 10

SELECT *
FROM Accounts a
WHERE a.Id = 1

---5.Add two more stored procedures WithdrawMoney(AccountId, money) 
---and DepositMoney(AccountId, money) that operate in transactions.

GO

CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @amount money)
	AS
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance = (-@amount) + (
			SELECT a.Balance
			FROM Accounts a
			WHERE a.Id = @accountId
		)
		WHERE id = @accountId
	COMMIT

GO

EXEC usp_WithdrawMoney 1, 100

SELECT Balance
FROM Accounts a
WHERE a.Id = 1

GO

CREATE PROCEDURE usp_DepositMoney(@accountId int, @amount money)
	AS
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance = (@amount) + (
			SELECT a.Balance
			FROM Accounts a
			WHERE a.Id = @accountId
		)
		WHERE id = @accountId
	COMMIT

GO

EXEC usp_DepositMoney 1, 100

SELECT Balance
FROM Accounts a
WHERE a.Id = 1

GO

---6.Create another table – Logs(LogID, AccountID, OldSum, NewSum).

CREATE TABLE Logs (
	LogID int IDENTITY PRIMARY KEY,
	AccountID int,
	OldSum money,
	NewSum money
)

GO

---Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum 
---on an account changes.

CREATE TRIGGER tr_AccountUpdate 
ON Accounts
FOR UPDATE
AS
SET NOCOUNT ON
INSERT INTO Logs
SELECT
i.Id,
d.Balance,
i.Balance
FROM INSERTED i, DELETED d
GO

---7.Define a function in the database TelerikAcademy that returns all Employee's names 
---(first or middle or last name) and all town's names that are comprised of given set of letters.
---Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy

GO
CREATE FUNCTION ufn_CheckName (@nameToCheck NVARCHAR(50),@letters NVARCHAR(50)) RETURNS INT
AS
BEGIN
        DECLARE @i INT = 1
		DECLARE @currentChar NVARCHAR(1)
        WHILE (@i <= LEN(@nameToCheck))
			BEGIN
				SET @currentChar = SUBSTRING(@nameToCheck,@i,1)
					IF (CHARINDEX(LOWER(@currentChar),LOWER(@letters)) <= 0) 
						BEGIN  
							RETURN 0
						END
				SET @i = @i + 1
			END
        RETURN 1
END
GO

USE TelerikAcademy

SELECT e.FirstName, e.LastName,t.Name FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID=t.TownID
WHERE 
dbo.ufn_CheckName(e.FirstName,'oistmiahf') = 1 OR 
dbo.ufn_CheckName(e.LastName,'oistmiahf') = 1 OR
dbo.ufn_CheckName(t.Name,'oistmiahf') = 1

---8.Using database cursor write a T-SQL script
---that scans all employees and their addresses and prints all pairs of employees that live in the same town.

USE TelerikAcademy

DECLARE employeeTownCursor CURSOR READ_ONLY FOR
  (SELECT e.FirstName, e.LastName, t.Name FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID=t.TownID)


OPEN employeeTownCursor
DECLARE @firstName NVARCHAR(50), @lastName NVARCHAR(50), @town NVARCHAR(50)

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE employeeTownCursor1 CURSOR READ_ONLY FOR
		(SELECT e.FirstName, e.LastName, t.Name FROM Employees e
		JOIN Addresses a ON e.AddressID = a.AddressID
		JOIN Towns t ON a.TownID=t.TownID)
	OPEN employeeTownCursor1
		DECLARE @firstName1 NVARCHAR(50), @lastName1 NVARCHAR(50), @town1 NVARCHAR(50)
		FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			WHILE @@FETCH_STATUS = 0
			BEGIN
		
				IF(@town = @town1)
				BEGIN
					PRINT @lastname1 + ': ' + @firstname + ' ' +  @lastname + ' ' + @town + ' ' + @firstname1 
				END

			FETCH NEXT FROM employeeTownCursor1 INTO @firstName1, @lastName1,@town1
			END

	CLOSE employeeTownCursor1
	DEALLOCATE employeeTownCursor1

FETCH NEXT FROM employeeTownCursor INTO @firstName, @lastName,@town
END

CLOSE employeeTownCursor
DEALLOCATE employeeTownCursor
