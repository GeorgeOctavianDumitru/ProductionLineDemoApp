CREATE PROCEDURE [dbo].[GetProductionSchedule]
	@OrderNumber int = 0
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT 
	 
	 ProductionSchedule.OrderNumber
	,Products.ProductNumber
	,OrderQty
	,Customers.Name as Customer
	,WorkCentres.[Work Center Description]
	,CapacityGroups.CapacityGroupName
	,JobStatus.StatusDescription
FROM
ProductionSchedule INNER JOIN Products 
ON
ProductionSchedule.ProductId=Products.Id
INNER JOIN Customers 
ON
ProductionSchedule.CustomerId=Customers.Id
INNER JOIN WorkCentres
ON
ProductionSchedule.WCN=WorkCentres.Id
INNER JOIN CapacityGroups
ON
ProductionSchedule.CapacityGroupId=CapacityGroups.Id
INNER JOIN JobStatus
ON
ProductionSchedule.JobStatusId=JobStatus.Id
WHERE ProductionSchedule.OrderNumber =  IIF(@OrderNumber IS NULL, ProductionSchedule.OrderNumber, @OrderNumber);
END
GO