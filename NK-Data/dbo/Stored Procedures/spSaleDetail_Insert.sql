CREATE PROCEDURE [dbo].[spSaleDetail_Insert]
	@SaleId int,
	@ProductId int,
	@Quantity int,
	@PurchasePrice money,
	@Tax money
AS

BEGIN
		insert into dbo.SalesDetail(SaleId,ProductId,Quantity,PurchasePrice,Tax)
		values (@SaleId,@ProductId,@Quantity,@PurchasePrice,@Tax)
	
End