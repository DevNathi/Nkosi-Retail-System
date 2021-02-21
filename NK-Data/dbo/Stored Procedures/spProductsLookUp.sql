CREATE PROCEDURE [dbo].[spProductsLookUp]
	
AS
BEGIN
	set nocount on;

	SELECT Id, ProductName,[Description], RetailPrice, QuantityInStock
	FROM [dbo].[Product]

	Order By ProductName;
END
