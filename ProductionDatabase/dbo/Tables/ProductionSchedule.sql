CREATE TABLE [dbo].[ProductionSchedule]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ProductId int,
	OrderNumber varchar(10),
	OrderQty int,
	CustomerId int,
	WCN int,
	CapacityGroupId int, 
	JobStatusId int
    CONSTRAINT [FK_ProductionSchedule_ToTable] FOREIGN KEY ([ProductId]) REFERENCES [Products]([Id]), 
    CONSTRAINT [FK_ProductionSchedule_ToTable_1] FOREIGN KEY ([WCN]) REFERENCES [WorkCentres]([Id]), 
    CONSTRAINT [FK_ProductionSchedule_ToTable_2] FOREIGN KEY ([CapacityGroupId]) REFERENCES [CapacityGroups]([Id]), 
    CONSTRAINT [FK_ProductionSchedule_ToTable_3] FOREIGN KEY ([JobStatusId]) REFERENCES [JobStatus]([Id])
)
