CREATE PROCEDURE [dbo].[spUserLookUp]
	@Id nvarchar(128)
	
AS
begin

	set nocount on;

	select AuthUserId, FirstName, LastName, EmailAddress, CreateDate
	from [dbo].[User]
	where AuthUserId = @Id;
end
