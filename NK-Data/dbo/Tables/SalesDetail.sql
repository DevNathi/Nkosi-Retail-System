CREATE TABLE [dbo].[SalesDetail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SaleId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL DEFAULT 1, 
    [PurchasePrice] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_SalesDetail_ToSale] FOREIGN KEY (SaleId) REFERENCES Sale (Id), 
    CONSTRAINT [FK_SalesDetail_ToProduct] FOREIGN KEY (ProductId) REFERENCES Product (Id)
)
