CREATE TABLE [dbo].[BillsOfMaterials]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ProductNoId int,
	ComponentPartNumber varchar(10),
	NetComponentQty numeric(18,2),
	UnitOfMeasure varchar(3), 
    CONSTRAINT [FK_BillsOfMaterials_ToTable] FOREIGN KEY (ProductNoId) REFERENCES [Products](Id)
)
