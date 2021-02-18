CREATE PROCEDURE [dbo].[spRemoveProduct]
	@Id int = 0
	
AS
BEGIN
	DELETE FROM Product
	WHERE [Id] = @Id
END
