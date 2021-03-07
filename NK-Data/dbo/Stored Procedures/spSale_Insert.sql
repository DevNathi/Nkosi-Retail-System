﻿CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id int output,
	@CashierId nvarchar(128),
	@SaleDate datetime2,
	@SubTotal money,
	@Tax money,
	@Total money
AS
BEGIN

	set nocount on;
	insert into dbo.Sale(CashierId,SaleDate,SubTotal,Tax,Total)
	values (@CashierId,@SaleDate,@SubTotal,@Tax,@Total)

	select @CashierId = @@IDENTITY;
END
