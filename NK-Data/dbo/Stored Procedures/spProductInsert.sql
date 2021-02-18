CREATE PROCEDURE [dbo].[spProductInsert]
	
	@ProductName NVARCHAR (100),
	@RetailPrice  MONEY,
	@Description  NVARCHAR (MAX) = ' '
	
AS
BEGIN
	INSERT INTO Product([ProductName],[RetailPrice],[Description])
	VALUES (@ProductName,@RetailPrice,@Description)
END
