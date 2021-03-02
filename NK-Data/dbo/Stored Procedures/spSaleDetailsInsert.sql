CREATE PROCEDURE [dbo].[spSaleDetailsInsert]
	
	@UserId int = 0,
	@ProductId int = 0,
	@Quantity NVARCHAR(10) = '',
	@PurchasePrice NVARCHAR = '',
	@Tax NVARCHAR = '' 
AS
BEGIN
	INSERT INTO SalesDetail (SaleId,[ProductId],[Quantity],[PurchasePrice],[Tax])
	VALUES (@UserId,@ProductId,@Quantity,@PurchasePrice,@Tax)
END
