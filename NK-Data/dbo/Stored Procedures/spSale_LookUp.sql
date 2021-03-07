CREATE PROCEDURE [dbo].[spSale_LookUp]
	@CashierId nvarchar (128),
	@SaleDate datetime2
	
AS
BEGIN
	SELECT [Id]
	FROM [dbo].[Sale]
	WHERE CashierId = @CashierId and SaleDate = @SaleDate;
END
