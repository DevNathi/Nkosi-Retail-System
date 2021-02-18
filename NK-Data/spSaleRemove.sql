CREATE PROCEDURE [dbo].[spSaleRemove]
	@Id int = 0
	
AS
BEGIN
SET NOCOUNT ON

	DELETE FROM Sale
	WHERE [Id] = @Id
END
