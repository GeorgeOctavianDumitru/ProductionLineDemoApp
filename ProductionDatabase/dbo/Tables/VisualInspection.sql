CREATE TABLE [dbo].[VisualInspection]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	ProductId int,
	BatchNumber int,
	ProductSerialNumber int,
	ImageLink varchar(max), 
    CONSTRAINT [FK_VisualInspection_ToProducts] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id])
    
)
