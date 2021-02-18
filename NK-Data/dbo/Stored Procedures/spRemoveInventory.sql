CREATE PROCEDURE [dbo].[spRemoveInventory]
	@Id int = 0
	
AS
BEGIN
	DELETE FROM Inventory
	WHERE [Id] = @Id
END
