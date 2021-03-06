﻿---04.find all information about all departments--- 

USE TelerikAcademy

SELECT * 
FROM Departments

---05.find all department names---

USE TelerikAcademy

SELECT Name AS [Department Name]
FROM Departments

---06.find the salary of each employee---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees

---07.full name of each employee---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees

---08.find the email addresses of each employee---

USE TelerikAcademy

SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

---09.find all different employee salaries---

USE TelerikAcademy

SELECT DISTINCT (Salary) AS [Distinct Salaries]
FROM Employees 
ORDER BY Salary

---10.find all information about the employees whose job title is “Sales Representative“.---

USE TelerikAcademy

SELECT *
FROM Employees e
WHERE e.JobTitle LIKE 'Sales%'

---11.find the names of all employees whose first name starts with "SA"---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE FirstName LIKE 'SA%'
ORDER BY FirstName

---12.find the names of all employees whose lASt name contains "ei"---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE LAStName LIKE '%ei%'
ORDER BY FirstName

---13.find the salary of all employees whose salary is in the range [20000…30000].---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary>=20000 AND Salary<=30000
ORDER BY Salary

---14.find the names of all employees whose salary is 25000, 14000, 12500 or 23600.---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees
WHERE Salary IN(12500,14000,23600,25000)
ORDER BY Salary

---15.find all employees that do not have manager---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], 
ISNULL(CAST(ManagerID AS char(10)),'no manager') AS Manager
FROM Employees 
WHERE ManagerID IS NULL

---16.to find all employees that have salary more than 50000. Order them in decreasing order by salary.---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM Employees 
WHERE Salary>=50000
ORDER BY Salary DESC

---17.find the top 5 best paid employees---

USE TelerikAcademy

SELECT FirstName + ' ' + LastName AS [Full Name], Salary
FROM (SELECT TOP 5 Salary, FirstName, LastName FROM Employees) es
ORDER BY Salary DESC

---18.find all employees along with their address.Use inner join with ON clause.---

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], a.AddressText
 FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID

---19.find all employees and their address.Use equijoins (conditions in the WHERE clause).---

USE TelerikAcademy

SELECT e.FirstName + ' ' +e.LastName AS [Full Name], a.AddressText, a.TownID
FROM Employees e,Addresses a 
WHERE e.AddressID=a.AddressID

---20.find all employees along with their manager.---

USE TelerikAcademy

SELECT e.FirstName + ' ' +e.LastName AS [Employee Full Name],m.FirstName + ' ' +m.LAStName AS [Manager Full Name]
FROM Employees e
	JOIN Employees m 
		ON e.ManagerID=m.EmployeeID

---21.find all employees, along with their manager and their address.---
---Join the 3 tables: Employees e, Employees m and Addresses a.---

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Employee], 
	   ea.AddressText as [EmployeeAddress],
	   m.FirstName + ' ' + m.LastName as [Manager],
	   em.AddressText as [ManagerAddress]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses ea
		ON e.AddressID = ea.AddressID
	JOIN Addresses em
		ON e.ManagerID = m.EmployeeID AND m.AddressID = em.AddressID

---22.find all departments and all town names AS a single list.Use UNION.---

USE TelerikAcademy

SELECT d.Name
FROM Departments d
UNION
SELECT t.Name
FROM Towns t

---23.find all the employees and the manager for each of them--- 
---along with the employees that do not have manager.Use right outer join.--- 

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Employee], 
	   m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
	RIGHT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

---Rewrite the query to use left outer join.---

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Employee], 
	   m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

---24.find the names of all employees from the departments---
--- "Sales" and "Finance" whose hire year is between 1995 and 2005.---

USE TelerikAcademy

SELECT E.FirstName + ' ' + e.LastName AS [Full Name], d.Name AS [Department], e.HireDate
FROM Employees e 
  JOIN Departments d
    ON d.DepartmentID=e.DepartmentID AND d.Name IN ('Sales','Finance')
WHERE e.HireDate BETWEEN '1995-1-1' AND '2005-1-1'

---another way---

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name AS [Department], e.HireDate
FROM Employees e 
	JOIN Departments d 
		ON e.DepartmentID = d.DepartmentID AND (d.Name = 'Sales' OR d.Name = 'Finance')
WHERE (CONVERT(datetime,e.HireDate,102) >= '1995' AND CONVERT(datetime,e.HireDate,102)<='2005')