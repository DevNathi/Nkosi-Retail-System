CREATE PROCEDURE [dbo].[spProductLookUp]
	@Id int 

AS
	
BEGIN 

	set nocount on;

	SELECT [Id],[ProductName],[RetailPrice],[Description],[QuantityInStock],[isTaxable]
	FROM [dbo].[Product]
	WHERE Id = @Id;
END
