CREATE TABLE [dbo].[ProductAssemblyInstructions]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ProductId int,
	InstructionStep int,
	ImageLink varchar(max),
	StepDescription varchar(max),
	StepTaktTime_seconds int, 
    CONSTRAINT [FK_ProductAssemblyInstructions_ToTable] FOREIGN KEY ([ProductId]) REFERENCES [Products]([id])
)
