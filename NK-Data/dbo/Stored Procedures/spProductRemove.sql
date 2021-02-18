CREATE PROCEDURE [dbo].[spProductRemove]
	@Id int = 0
	
AS
BEGIN
 SET NOCOUNT ON
	DELETE FROM Product
	WHERE [Id] = @Id
End
