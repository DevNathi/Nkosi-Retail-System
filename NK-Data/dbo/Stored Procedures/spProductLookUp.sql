CREATE PROCEDURE [dbo].[spProductLookUp]
	@Id int = 0

AS
	
BEGIN 

	SELECT [Id],[ProductName],[RetailPrice],[Description],[CreateDate],[LastModified]
	FROM [dbo].[Product]
	WHERE Id = @Id
END
