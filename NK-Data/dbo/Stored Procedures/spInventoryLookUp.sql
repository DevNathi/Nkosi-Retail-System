CREATE PROCEDURE [dbo].[spInventoryLookUp]
	@Id int = 0
	
AS
BEGIN
	SELECT [Id],[ProductId],[Quantity],[PurchasePrice],[PurchaseDate]
	FROM [dbo].[Inventory]
	WHERE [Id] = @Id
END
