Datatable Script

create table Products(
id int primary key identity(1,1),
ProductId uniqueidentifier default NewId(),
ProductName nvarchar(max),
StockAvailable nvarchar(max),
CreatedAt datetime2 DEFAULT CURRENT_TIMESTAMP,
UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
)

----if we use stored procedure for saving data so in this condition we use this sql server trigger
--create trigger trg_UpdateTimeEntry
--on Products
--After Update as
--	Update Products set UpdatedAt=CURRENT_TIMESTAMP where Id in (SELECT DISTINCT ID from inserted)

if we use Entity Framework so Triggers we use in Code Side. If we use Stored Procedure for Insert/Update Data then we use Database Side Triggers.

Which ORMs using in this application
--Entity Framework
--Insight Database (Micro ORM)