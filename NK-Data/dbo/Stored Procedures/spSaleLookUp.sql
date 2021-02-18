CREATE PROCEDURE [dbo].[spSaleLookUp]
	@Id int = 0
	
AS
BEGIN
	SELECT [Id],[CashierId],[SaleDate],[Subtotal],[Tax],[Total]
	FROM [dbo].[Sale]
	WHERE [Id] = @Id
END
