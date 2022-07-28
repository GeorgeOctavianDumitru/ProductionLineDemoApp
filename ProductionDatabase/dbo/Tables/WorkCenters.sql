CREATE TABLE [dbo].[WorkCentres] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [Work Center Description] VARCHAR (250) NULL,
    [Capacity_Group_Id] int
    PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_WorkCentres_ToTable] FOREIGN KEY ([Capacity_Group_Id]) REFERENCES [CapacityGroups](Id)
);

