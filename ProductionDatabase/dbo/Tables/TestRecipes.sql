CREATE TABLE [dbo].[TestRecipes]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ProductId int,
	WCN_Testing int,
	TestName varchar(50),
	MinValue numeric(18,2),
	MaxValue numeric(18,2),
	Tollerance numeric(18,2), 
    CONSTRAINT [FK_TestRecipes_ToTable] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_TestRecipes_ToTable_1] FOREIGN KEY (WCN_Testing) REFERENCES [WorkCentres]([Id])
)
