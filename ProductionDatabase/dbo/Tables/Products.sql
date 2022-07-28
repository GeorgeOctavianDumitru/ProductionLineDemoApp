CREATE TABLE [dbo].[Products]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	ProductNumber varchar(10) NOT NULL,
	ProductDescription varchar (50) NOT NULL,
	AnualUsage int not null,
	MinimumOrderQty int,
	ProductOwner varchar(50),
	CapacityGroup_id int,
	WorkCentreNumber int, 
    CONSTRAINT [FK_Products_ToTable] FOREIGN KEY ([CapacityGroup_id]) REFERENCES CapacityGroups(Id), 
    CONSTRAINT [FK_Products_ToTable_1] FOREIGN KEY ([WorkCentreNumber]) REFERENCES WorkCentres(Id)
)
