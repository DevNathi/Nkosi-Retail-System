CREATE PROCEDURE [dbo].[spInventoryInsert]
	
	@ProductId int = 0,
	@Quantity int = 0,
	@PurchasePrice NVARCHAR = ''
	
AS
BEGIN
	INSERT INTO Inventory ([ProductId],[Quantity],[PurchasePrice])
	VALUES (@ProductId,@Quantity,@PurchasePrice)
END
