USE Northwind
GO

IF (OBJECT_ID('dbo.usp_TotalIncome', 'P') IS NOT NULL)
	DROP PROCEDURE dbo.usp_TotalIncome
GO

CREATE PROC dbo.usp_TotalIncome(@supName nvarchar(40), @startDate Date, @endDate Date)
AS 
	SELECT SUM(allSales.Sale) as AllSales
	FROM
		(SELECT	(o.UnitPrice * o.Quantity) as Sale
		FROM [Order Details] o
			INNER JOIN Orders od
			ON o.OrderID = od.OrderID
				INNER JOIN Products p
				ON p.ProductID = o.ProductID
					INNER JOIN Suppliers s
					ON s.SupplierID = p.SupplierID		
		WHERE s.CompanyName = @supName AND od.OrderDate BETWEEN @startDate AND @endDate) as allSales
GO

EXEC usp_TotalIncome 'Tokyo Traders', '1997-01-01', '1997-12-31';