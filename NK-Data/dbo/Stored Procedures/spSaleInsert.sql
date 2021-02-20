CREATE PROCEDURE [dbo].[spSaleInsert]
	
	@CashierId NVARCHAR (128) = '',
	@SaleDate DATETIME2 (7),
	@SubTotal NVARCHAR = '',
	@Tax NVARCHAR = '',
	@Total NVARCHAR  = ''

AS
BEGIN
	INSERT INTO dbo.Sale ([CashierId],[SaleDate],[Subtotal],[Tax],[Total])
	VALUES(@CashierId,@SaleDate,@Subtotal,@Tax,@Total)
END