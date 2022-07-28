CREATE TABLE [dbo].[TestResults]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	ProductId int,
	TestId int,
	RecorderdValue numeric(18,2),
	Result bit, 
    CONSTRAINT [FK_TestResults_ToTable] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_TestResults_ToTable_1] FOREIGN KEY ([TestId]) REFERENCES [TestRecipes]([Id])


)
