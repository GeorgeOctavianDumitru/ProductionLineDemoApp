CREATE TABLE [dbo].[Customers]
(
	Id int IDENTITY(1,1) PRIMARY KEY,
	[Name] varchar (250),
	[Country] varchar(2),
	[City] varchar(74),
	[StreetName] varchar(100), 
	[StreetNumber] int,
	[PostCode] varchar(10)

)
