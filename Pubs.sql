
USE pubs
GO

IF EXISTS ( SELECT * 
              FROM INFORMATION_SCHEMA.TABLES
			 WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'Countries')
   DROP TABLE dbo.Countries
   GO

	CREATE TABLE dbo.Countries(
		Id INT Identity(1,1) not null primary key,
	   [Name] VARCHAR (100)
	   )

	INSERT INTO dbo.Countries([Name])VALUES ('Argentina') 
	INSERT INTO dbo.Countries([Name])VALUES ('Austria') 
	INSERT INTO dbo.Countries([Name])VALUES ('Belgium') 
	INSERT INTO dbo.Countries([Name])VALUES ('Brazil') 
	INSERT INTO dbo.Countries([Name])VALUES ('Canada') 
	INSERT INTO dbo.Countries([Name])VALUES ('Denmark') 
	INSERT INTO dbo.Countries([Name])VALUES ('Finland') 
	INSERT INTO dbo.Countries([Name])VALUES ('France') 
	INSERT INTO dbo.Countries([Name])VALUES ('Germany') 
	INSERT INTO dbo.Countries([Name])VALUES ('Ireland') 
	INSERT INTO dbo.Countries([Name])VALUES ('Italy') 
	INSERT INTO dbo.Countries([Name])VALUES ('Mexico') 
	INSERT INTO dbo.Countries([Name])VALUES ('Norway') 
	INSERT INTO dbo.Countries([Name])VALUES ('Poland') 
	INSERT INTO dbo.Countries([Name])VALUES ('Portugal') 
	INSERT INTO dbo.Countries([Name])VALUES ('Spain') 
	INSERT INTO dbo.Countries([Name])VALUES ('Sweden') 
	INSERT INTO dbo.Countries([Name])VALUES ('Switzerland') 
	INSERT INTO dbo.Countries([Name])VALUES ('UK') 
	INSERT INTO dbo.Countries([Name])VALUES ('USA') 
	INSERT INTO dbo.Countries([Name])VALUES ('Venezuela')
	
	DROP VIEW IF EXISTS dbo.view_CountryOrdersInfo
	GO

	CREATE VIEW dbo.view_CountryOrdersInfo AS( 
	SELECT D.Id
		 , C.ShipCountry
		 , COUNT(C.ShipCountry)		 AS CountryOrders
		 , SUM(C.OrderTotal)		 AS CountryTotal
		 , SUM(C.OrderTotalDiscount) AS CountryTotalDiscount
		 , AVG(C.OrderTotal)         AS CountryAvg
		 , AVG(C.OrderTotalDiscount) AS CountryAvgDiscount
		 , AVG(C.Freight)            AS FreightAvg
	  FROM dbo.Countries AS D 
	 INNER JOIN 
		(SELECT A.OrderID
			 , A.CustomerID
			 , A.EmployeeID
			 , A.ShipVia
			 , A.Freight
			 , A.ShipCity
			 , A.ShipCountry
			 , SUM(ProdTotal) AS OrderTotal
			 , SUM(ProdTotalDiscount) AS OrderTotalDiscount
		  FROM dbo.Orders AS A
		  INNER JOIN( 
				SELECT OrderID
					 , ProductID
					 , UnitPrice
					 , Quantity
					 , Discount
					 ,(UnitPrice * Quantity)		  AS ProdTotal
					 ,((UnitPrice-Discount)*Quantity) AS ProdTotalDiscount
				  FROM dbo.[Order Details]) AS B ON B.OrderID = A.OrderID
				GROUP BY A.OrderID, A.CustomerID,A.EmployeeID,A.ShipVia,A.Freight
				,A.ShipCity, A.ShipCountry) AS C ON C.ShipCountry = D.[Name]
				GROUP BY D.Id, C.ShipCountry				
	)


