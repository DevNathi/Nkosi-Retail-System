﻿CREATE PROCEDURE [dbo].[spSaleDetailsLookUp]
	@Id int = 0
	
AS
BEGIN
	SELECT [Id],[UserId],[ProductId],[Quantity],[PurchasePrice],[Tax]
	FROM [dbo].[SalesDetail]
	WHERE [Id] = @Id
END
