
----------------------------------------------------
------------CREATE TABLE----------------------------
----------------------------------------------------

use master;
go
drop database if exists QLTheGioiDiDong;
go

create database QLTheGioiDiDong;
go


use QLTheGioiDiDong;
go



 Go
 
--tài khoản đăng nhập
if OBJECT_ID('Accounts') is not null
	Drop Table Accounts;
Create Table Accounts(
AccountID int not null identity(1,1) Primary Key,
UserName varchar(30) not null,
Password varchar(30) not null,
AccountPolicy varchar (30) not null,
);
Go
 --nhóm nhân viên
if OBJECT_ID('EmployeeGroups') is not null
	Drop Table EmployeeGroups;
 Create Table EmployeeGroups(
 GroupID int identity(1,1) not null Primary Key,
 GroupName varchar(30) not null,
 );
 go

 --nhân viên
if OBJECT_ID('Employees') is not null
	Drop Table Employees;
 Create Table Employees(
 EmployeeID int identity(1,1) Primary Key,
 EmployeeName varchar(50) not null,
 Sex varchar(50) not null,
 Salary money not null,
 IDGroup int not null,
 AccountID int unique FOREIGN KEY REFERENCES Accounts( AccountID), 
 CONSTRAINT fk_GroupEmploy_GroupID
 FOREIGN KEY (IDGroup)
 REFERENCES EmployeeGroups (GroupID)
 );
 go

--Loại sản phẩm
 if OBJECT_ID('ProductTypes') is not null
	Drop Table ProductTypes;
Create table ProductTypes (
TypeID int not null identity(1,1) Primary key ,
NameType varchar(30) not null ,
Number int not null
 );
 go

--sản phẩm 
  if OBJECT_ID('Products') is not null
	Drop Table Products;
 Create Table Products(
ProductID int not null identity(1,1) Primary key,
IDType int not null,
ProductName varchar(30) not null,

ProductImg nvarchar(MAX),
ProductColor varchar(30) not null,
ProductCost int not null,
StatusProduct int
CONSTRAINT fk_type_TypeID
FOREIGN KEY (IDType)
REFERENCES ProductTypes (TypeID),
 );
 go

--khách hàng
if OBJECT_ID('Customers') is not null
	Drop Table Customers;
Create Table Customers(
CustomerID int not null identity(1,1) Primary Key,
CustomerName varchar(30) not null,
CustomerPhone int not null,
 );
 Go

--hóa đơn 
if OBJECT_ID('Bills') is not null
	Drop Table Bills;
 Create Table Bills(
 BillID int identity(1,1) Primary Key,
 EmployeeSellID int not null,
 CustomerID int not null,
 ProductName varchar(50) not null,
 SellDate date not null,
 Price money not null,
 --khóa cho Customer
 CONSTRAINT fk_CustomerBuy_CustomerID
FOREIGN KEY (CustomerID)
REFERENCES Customers (CustomerID),
--khóa cho sản phẩm
 ProductID int unique FOREIGN KEY REFERENCES Products( ProductID) not null, 
--khóa cho nhân viên bán được hàng
CONSTRAINT fk_EmployeeSell_EmployeeSellID
FOREIGN KEY ( EmployeeSellID )
REFERENCES Employees( EmployeeID )
 );
 go

 --bảo hành sản phẩm
 if OBJECT_ID('Warranty') is not null
	Drop Table Warranty;
 Create Table Warranty(
WarrantyID int identity(1,1) Primary Key,
BillID int not null,
ProblemProduct varchar(50) not null,
ReceivedDate date not null,
ReleaseDate date not null,
EmployeeID int not null,
WarrantyStatus int not null

CONSTRAINT fk_WarrantyProduct_BillID
FOREIGN KEY (BillID)
REFERENCES Bills (BillID),
);
go


Go

if OBJECT_ID('EmployeeArchive') is not null
	Drop Table EmployeeArchive;

Go
Create Table EmployeeArchive(
STT int identity(1,1) not null,
EmployeeID int not null ,
EmployeeName varchar(30) not null,
Sex varchar(30) not null,
Salary money not null,
GroupID int not null,
AccountID int not null
);

Go

if OBJECT_ID('BillsArchive') is not null
	Drop Table BillsArchive;

Go

Create Table BillsArchive(
 STT int identity(1,1) not null,
 BillID int not null,
 EmployeeSellID int not null,
 CustomerID int not null,
 ProductName varchar(50) not null,
 SellDate date not null,
 Price money not null,

);

if OBJECT_ID('EmployeeGroupsArchive') is not null
	Drop Table EmployeeGroupsArchive;
Go

Create Table EmployeeGroupsArchive(
 STT int identity(1,1) not null,
 GroupID int not null,
 GroupName varchar(30) not null,

);

if OBJECT_ID('ProductTypesArchive') is not null
	Drop Table ProductTypesArchive;

Go

Create Table ProductTypesArchive(
STT int identity(1,1) not null,
TypeID int not null ,
NameType varchar(30) not null ,
Number int not null

);

if OBJECT_ID('ProductsArchive') is not null
	Drop Table ProductsArchive;

Go

Create Table ProductsArchive(
STT int identity(1,1) not null,
ProductID int not null,
IDType int not null,
ProductName varchar(30) not null,
ProductImg nvarchar(MAX),
ProductColor varchar(30) not null,
ProductCost int not null

);


----------------------------------------------------
--------------VIEW----------------------------------
----------------------------------------------------

--Tạo view kết 2 bảng Employees và EmployeeGroups
IF OBJECT_ID('Employee_EmployeeGroups') IS NOT NULL
DROP VIEW Employee_EmployeeGroups;
GO

CREATE VIEW Employee_EmployeeGroups
AS
SELECT Employees.EmployeeID , Employees.EmployeeName , Employees.Sex , Employees.Salary, EmployeeGroups.GroupName as NameGroup, Employees.AccountID
FROM Employees JOIN EmployeeGroups ON Employees.IDGroup = EmployeeGroups.GroupID; 

Go

--tạo view kết 2 bảng Product và ProductType, xem những sản phẩm mà statusProduct = 1 (Nghĩa là xem những sản phẩm chưa bán)

IF OBJECT_ID('Product_ProductType') IS NOT NULL
DROP VIEW Product_ProductType;
GO

CREATE VIEW Product_ProductType
AS

SELECT Products.ProductID, ProductTypes.NameType as Type , Products.ProductName , Products.ProductColor, Products.ProductCost
FROM Products Join ProductTypes On Products.IDType = ProductTypes.TypeID
Where StatusProduct = 1;

Go

--Xem san pham cua admin(xem tất cả sản phẩm gồm đã bán và chưa bán)

IF OBJECT_ID('Product_ProductType_Admin') IS NOT NULL
DROP VIEW Product_ProductType_Admin;
GO

CREATE VIEW Product_ProductType_Admin
AS

SELECT Products.ProductID, ProductTypes.NameType as Type , Products.ProductName , Products.ProductColor, Products.ProductCost,StatusProduct
FROM Products Join ProductTypes On Products.IDType = ProductTypes.TypeID


Go

--
IF OBJECT_ID('ProductTypesView') IS NOT NULL
DROP VIEW ProductTypesView;
GO

CREATE VIEW ProductTypesView
AS
SELECT NameType , Number
FROM ProductTypes

Go



IF OBJECT_ID('WarrantyView') IS NOT NULL
DROP VIEW WarrantyView;
GO

CREATE VIEW WarrantyView
AS
SELECT BillID,ProblemProduct,ReceivedDate,ReleaseDate,EmployeeID
FROM Warranty

Go


----------------------------------------------------
------------Trigger----------------------------
----------------------------------------------------


--Tạo trigger ALTER DELETE EmployeeGroups - Khi xóa EmployeeGroups dữ liệu sẽ được lưu vào bản EmployeeGroupsArchive để cho việc undo
Go

IF OBJECT_ID('EmployeeGroups_DELETE') IS NOT NULL
DROP TRIGGER EmployeeGroups_DELETE; --trigger
GO


CREATE TRIGGER EmployeeGroups_DELETE
		ON EmployeeGroups
		AFTER DELETE

AS

INSERT INTO EmployeeGroupsArchive 
		  (GroupID,GroupName)
	Select GroupID,GroupName
	From deleted;

Go

--Tạo trigger ALTER DELETE Employees - Khi xóa Employees dữ liệu sẽ được lưu vào bản EmployeesArchive để cho việc undo
IF OBJECT_ID('Employees_DELETE') IS NOT NULL
DROP TRIGGER Employees_DELETE;
GO


CREATE TRIGGER Employees_DELETE
		ON Employees
		AFTER DELETE

AS

INSERT INTO EmployeeArchive 
		  (EmployeeID,EmployeeName,Sex,Salary,GroupID,AccountID)
	Select EmployeeID,EmployeeName,Sex,Salary,IDGroup,AccountID
	From deleted;

Go



--Tạo trigger ALTER DELETE ProductTypes - Khi xóa ProductTypes dữ liệu sẽ được lưu vào bản ProductTypesArchive để cho việc undo

IF OBJECT_ID('ProductTypes_DELETE') IS NOT NULL
DROP TRIGGER ProductTypes_DELETE; 
GO


CREATE TRIGGER ProductTypes_DELETE
		ON ProductTypes
		AFTER DELETE

AS


INSERT INTO ProductTypesArchive 
		  (TypeID,NameType,Number)
	Select TypeID,NameType,Number
	From deleted;

Go

--Tạo trigger ALTER DELETE Products - Khi xóa Products dữ liệu sẽ được lưu vào bản ProductsArchive để cho việc undo


IF OBJECT_ID('Products_DELETE') IS NOT NULL
DROP TRIGGER Productss_DELETE; 
GO


CREATE TRIGGER Products_DELETE
		ON Products
		AFTER DELETE

AS


INSERT INTO ProductsArchive 
		  (ProductID,IDType,ProductName,ProductImg,ProductColor,ProductCost)
	Select ProductID,IDType,ProductName,ProductImg,ProductColor,ProductCost
	From deleted;

Go



Go


IF OBJECT_ID('Bills_DELETE') IS NOT NULL
DROP TRIGGER Bills_DELETE;
GO


CREATE TRIGGER Bills_DELETE
		ON Bills
		AFTER DELETE

AS

INSERT INTO BillsArchive 
		  ( BillID,EmployeeSellID,CustomerID,ProductName,SellDate,Price)
	Select BillID,EmployeeSellID,CustomerID,ProductName,SellDate,Price
	From deleted;

Go





----------------------------------------------------
------------STORE PROCEDURES------------------------
----------------------------------------------------
-- Store Procedure Đăng nhập 
if OBJECT_ID('DangNhap') is not null
	Drop Proc DangNhap;
Go
Create Proc DangNhap
			@UserName varchar(30),
			@Password varchar(30),
			@Policy varchar(30),
			@EmployeeID int output
			
As
Begin
		if(@Policy ='Admin')
			Begin
				select @EmployeeID = Count(*) From Accounts Where UserName = @UserName and Password = @Password and AccountPolicy = @Policy;
			End
		Else
			Begin
				Select @EmployeeID = Employees.EmployeeID
			from Accounts Join Employees On Accounts.AccountID = Employees.AccountID
			Where UserName = @UserName and Password = @Password and AccountPolicy = @Policy
				if(@EmployeeID Is Null)
					set @EmployeeID = 0;
				
			END

End

--Go
--Declare @Employeid int
--exec DangNhap 'Nguyen2','123','Admin', @Employeid OUTPUT;
--Print @EmployeID
--
Go


--Lấy thông tin Account
if OBJECT_ID('GetAcc') is not null
	Drop Proc GetAcc;

Go

Create Proc GetAcc
As
Begin
		Select * from Accounts;
		Return;
End


Go

--Lấy thông tin Group

if OBJECT_ID('GetGroup') is not null
	Drop Proc GetGroup
Go

Create Proc GetGroup

As

Select * 
From EmployeeGroups
return

Go

--Lấy thông tin ProductType từ view ProductTypeView

if OBJECT_ID('GetProductType') is not null
	Drop Proc GetProductType;

Go

Create Procedure GetProductType		
As

Select * From ProductTypesView
Return

go


--Lấy thông tin Product từ view Product_ProductType
if OBJECT_ID('GetProduct') is not null
	Drop Proc GetProduct;

Go

CREATE Procedure GetProduct
		
As

Select *
From Product_ProductType
Return

Go

--Lấy sản phẩm (Admin sẽ xem được những sản phẩm nào đã bán và những sản phẩm chưa bán)
if OBJECT_ID('GetProductAdmin') is not null
	Drop Proc GetProductAdmin;

Go

CREATE Procedure GetProductAdmin
		
As

Select *
From Product_ProductType_Admin
Return

Go

--Lấy những Products theo Loại Product Truyền vào

if OBJECT_ID('GetProductTheoType') is not null
	Drop Proc GetProductTheoType;

Go

CREATE Procedure GetProductTheoType
		@Type varchar(30)
As
IF(@Type ='ALL')
Begin
Select *
From Product_ProductType
End
Else
Select *
From Product_ProductType
Where Product_ProductType.Type  = @Type
Go


--Lấy thông tin Product theo mã ID

if OBJECT_ID('GetProductTheoID') is not null
	Drop Proc GetProductTheoID;

Go

CREATE Procedure GetProductTheoID
		@ID int
As

Select *
From Product_ProductType
Where Product_ProductType.ProductID = @ID
Go


--Nhân viên bán sản phẩm sẽ cập nhật trạng thái = 0 và Giảm số lượng của Loại sản phẩm đó xuống 1

IF OBJECT_ID('SellProduct') is not null
	Drop proc SellProduct
Go

CREATE Procedure SellProduct
		@ID int
As
begin
	Declare @A int
	Update Products Set StatusProduct = 0 Where ProductID = @ID
	Select @A = IDType
	From Products Join ProductTypes On Products.IDType = TypeID
	Where ProductID = @ID
	Update ProductTypes set Number = Number - 1 where TypeID = @A
end

Go

--Lấy thông tin Employee từ view Employee_EmployeeGroups

if OBJECT_ID('GetEmployees') is not null
	Drop Proc GetEmployees;
Go
Create Proc GetEmployees
		
As
Begin
		select * 
		From Employee_EmployeeGroups
End

Go

--Khi khách hàng đến bảo hành máy , nhân viên kỹ thuật sẽ thêm 1 phiếu bảo hành , 
--Lấy những phiếu bảo hành mà nhân viên đã thêm và Status = 1(Chưa xóa phiếu)

if OBJECT_ID('GetWarranty_Employee') is not null
	Drop Proc GetWarranty_Employee;
Go
Create Proc GetWarranty_Employee
		@EmployeeID int
As
Begin
		select BillID,ProblemProduct,ReceivedDate,ReleaseDate,EmployeeID
		From Warranty
		Where EmployeeID = @EmployeeID and WarrantyStatus = 1
End

Go

--Lấy thông tin tất cả hóa đơn

if OBJECT_ID('GetBill') is not null
	Drop Proc GetBill;
Go

Create Proc GetBill
As
Select * 
From Bills
return

Go

-- Lấy thông tin hóa đơn theo từng nhân viên
if OBJECT_ID('GetEmployeeBill') is not null
	Drop Proc GetEmployeeBill;
		
Go

Create Proc GetEmployeeBill
		@EmployeeID int
As
Select * 
From Bills
Where EmployeeSellID = @EmployeeID
return

Go





--Thêm tài khoảng

if OBJECT_ID('InsertAccount') is not null
	Drop Proc InsertAccount;

Go

Create Proc InsertAccount
		@UserName varchar(30),
		@Password varchar(30),
		@Policy varchar(30) 
As
Begin
		Insert into Accounts (UserName,Password,AccountPolicy) Values(@UserName,@Password,@Policy); 
End


Go
--Thêm nhân viên

if OBJECT_ID('AddEmployee') is not null
	Drop Proc AddEmployee;
Go
Create Proc AddEmployee
			@EmPloyeeName varchar(50),
			@Sex varchar(50),
			@Salary int,
			@GroupID int,
			@AccountID int
As
			
Begin
		Insert into Employees(EmployeeName,Sex,Salary,IDGroup,AccountID) values(@EmPloyeeName,@Sex,Convert(money,@Salary),@GroupID,@AccountID)

End

Go
--Thêm Nhóm Nhân viên
if OBJECT_ID('AddGroup') is not null
	Drop Proc AddGroup;
Go
Create Proc AddGroup
			@GroupName varchar(30)
As
			
Begin
		INSERT EmployeeGroups(GroupName) values(@GroupName)

End

Go

--Thêm loại sản phẩm
if OBJECT_ID('AddProductType') is not null
	Drop Proc AddProductType		
Go

Create Proc AddProductType
			@NameType varchar(30),
			@Number int
		
As	

Begin

INSERT ProductTypes(NameType,Number) values(@NameType,@Number)

End
Go



--Thêm Sản Phẩm -> số lượng loại sản phẩm tương ứng sẽ tăng lên 1
if OBJECT_ID('AddProduct') is not null
	Drop Proc AddProduct;

Go

Create Proc AddProduct
			@IDType int,
			@ProductName varchar(30),
			@ProductImg nvarchar(MAX),
			@ProductColor varchar(30),
			@ProductCost int
As

Begin
Insert into Products(IDType,ProductName,ProductImg,ProductColor,ProductCost,StatusProduct) values(@IDType,@ProductName,@ProductImg,@ProductColor,@ProductCost,1)
Update ProductTypes Set Number = Number + 1 Where TypeID = @IDType;

end

Go
--Thêm Hóa đơn(Khi bán , nhân viên sẽ thực hiện strore Procedure SellProduct và Addbill)
if OBJECT_ID('AddBill') is not null
	Drop Proc AddBill;

Go

Create Proc AddBill
			@EmployeeID int,
			@CustomerID int,
			@ProductName varchar(30),
			@Price int,
			@ProductID int
As

Begin
Insert into Bills (EmployeeSellID,CustomerID,ProductName,SellDate,Price,ProductID) Values(@EmployeeID,@CustomerID,@ProductName,GetDate(),@Price,@ProductID);

end

Go

--Thêm Khách hàng 

if OBJECT_ID('AddCustomer') is not null
	Drop Proc AddCustomer;
Go
Create Proc AddCustomer
			@CustomerName varchar(30),
			@CustomerPhone int
As
			
Begin
		INSERT Customers(CustomerName,CustomerPhone) values(@CustomerName,@CustomerPhone)

End


--Thêm phiếu bảo hành
Go

if OBJECT_ID('AddWarranty') is not null
	Drop Proc AddWarranty;
Go
Create Proc AddWarranty
			@BillID int,
			@ProblemProduct varchar(50),
			@ReleaseDay date,
			@EmployeeID int
As
			
Begin
		Insert into Warranty(BillID,ProblemProduct,ReceivedDate,ReleaseDate,EmployeeID,WarrantyStatus) Values(@BillID,@ProblemProduct,GetDate(),@ReleaseDay,@EmployeeID,1)

End


--Xóa Nhóm nhân viên
Go


if OBJECT_ID('DeleteGroupEmployee') is not null
	Drop Proc DeleteGroupEmployee;

Go

Create Proc DeleteGroupEmployee
			@GroupID int
As

Begin

Delete from EmployeeGroups Where GroupID = @GroupID

End


--Xóa nhân viên
Go

if OBJECT_ID('DeleteEmployee') is not null
	Drop Proc DeleteEmployee;

Go

go
Create Proc DeleteEmployee
			@EmployeeID int
As

Begin

Delete from Employees Where EmployeeID = @EmployeeID

End

Go

--Xóa loại sản phẩm

if OBJECT_ID('DeleteProductType') is not null
	Drop Proc DeleteProductType;

Go

Create Proc DeleteProductType
			@NameType varchar(30)
As

Begin

Delete from ProductTypes Where NameType = @NameType

End


--Xóa sản phẩm , nếu trạng thái = 0 nghia là đã bán sản phẩm thì hiện lối 'Product is selled'

Go

if OBJECT_ID('DeleteProducts') is not null
	Drop Proc DeleteProducts
Go

Create Proc DeleteProducts
			@ProductID int
As

Begin
Declare @a int
Declare @b int
Select @a = TypeID, @b = StatusProduct
From Products join ProductTypes On Products.IDType = ProductTypes.TypeID
IF(@b = 0)
		THROW 50027, 'Product is Selled.', 1;
Else	
	begin
	Delete from Products Where ProductID = @ProductID
	Update ProductTypes Set Number = Number - 1 Where TypeID = @a
	end

End

Go

--Chứa những hàm xóa ,khi truyền vào thể loại xóa nào thì sẽ chạy store của thể loại đó

If Object_ID('spDelete') IS NOT NULL
	Drop Proc spDelete;
		
Go

Create Proc spDelete
			@Type varchar(30),
			@ID int,
			@NameType varchar(30) = NULL
As
	if(@Type ='Employees')
	Begin		
		Exec DeleteEmployee @ID
	END
	Else if(@Type ='Groups')
	Begin
		Exec DeleteGroupEmployee @ID
	End
	Else if(@Type ='Products')
	Begin
		Exec DeleteProducts @ID
	End
	Else if(@Type = 'ProductType')
	Begin 
		Exec DeleteProductType @NameType
	End
Go


--Undo GroupEmployee , insert GroupEmployee từ bảng EmployeeGroupsArchive(Gồm những thông tin GroupEmployee đã xóa) vào lại bảng EmployeeGroup, Xóa dữ liệu ở bảng lưu trữ đi
if OBJECT_ID('UndoGroupEmployee') is not null
	Drop Proc UndoGroupEmployee
Go

Create Proc UndoGroupEmployee

As

Begin
	

	SET IDENTITY_INSERT EmployeeGroups ON

	INSERT INTO EmployeeGroups(GroupID,GroupName)
	Select Top 1 GroupID,GroupName  From EmployeeGroupsArchive ORDER BY STT DESC;
	Delete EmployeeGroupsArchive Where GroupID = @@IDENTITY;
	SET IDENTITY_INSERT EmployeeGroups OFF

	
End

Go


if OBJECT_ID('UndoEmployee') is not null
	Drop Proc UndoEmployee
Go

Create Proc UndoEmployee

As

Begin
	SET IDENTITY_INSERT Employees ON
	INSERT INTO Employees(EmployeeID,EmployeeName,Sex,Salary,IDGroup,AccountID)
	Select Top 1 EmployeeID,EmployeeName,Sex,Salary,GroupID,AccountID  From EmployeeArchive ORDER BY STT DESC;
	Delete EmployeeArchive Where EmployeeID = @@IDENTITY;
	SET IDENTITY_INSERT Employees OFF

End
Go

if OBJECT_ID('UndoProductTypes') is not null
	Drop Proc UndoProductTypes
Go

Create Proc UndoProductTypes

As

Begin
	

	SET IDENTITY_INSERT ProductTypes ON

	INSERT INTO ProductTypes(TypeID,NameType,Number)
	Select Top 1 TypeID,NameType,Number  From ProductTypesArchive ORDER BY STT DESC;
	Delete ProductTypesArchive Where TypeID = @@Identity;
	SET IDENTITY_INSERT ProductTypes OFF

	
End

Go
--Như những Procedure Undo trên nhưng khi undo thì sẽ tăng số lượng lên 1 của loại sản phẩm tương ứng

if OBJECT_ID('UndoProducts') is not null
	Drop Proc UndoProducts
Go

Create Proc UndoProducts

As

Begin
	Declare @IDType int
	SET IDENTITY_INSERT Products ON
	INSERT INTO Products(ProductID,IDType,ProductName,ProductImg,ProductColor,ProductCost,StatusProduct)
	Select Top 1 ProductID,IDType,ProductName,ProductImg,ProductColor,ProductCost,1  From ProductsArchive ORDER BY STT DESC;
	Declare @ProductID int = @@IDENTITY;
	Select @IDType = IDType From ProductsArchive Where ProductID = @ProductID
	Update ProductTypes Set Number = Number + 1 Where TypeID = @IDType
	Delete ProductsArchive Where ProductID = @ProductID
	--Select @A =  From ProductsArchive Join ProductTypes On ProductsArchive.IDType = ProductTypes.TypeID AND ProductsArchive.ProductID = @ProductID
	SET IDENTITY_INSERT Products OFF


End

Go

--Procedure spUndo để gọi những Undo tương ứng theo thể loại truyền vào
IF OBJECT_ID('spUndo') IS not null
	Drop Proc spUndo

Go

Create Proc spUndo
		@Type varchar(30)
As
	if(@Type ='Employees')
	Begin		
		Exec UndoEmployee
	END
	Else if(@Type ='Groups')
	Begin
		Exec UndoGroupEmployee
	End
	Else if(@Type ='Products')
	Begin
		Exec UndoProducts
	End
	Else if(@Type = 'ProductType')
	Begin 
		Exec UndoProductTypes
	End

Go

--Cập nhật giá trị Salary, AccountID của nhân viên, Cập nhật nhóm nhân viên

if OBJECT_ID('UpdateEmployee') is not null
	Drop Proc UpdateEmployee
Go

Create Proc UpdateEmployee
			@EmployeeID int,
			@Salary int,
			@GroupName varchar(30),
			@EmployeeAcc int

As
Begin
Update Employee_EmployeeGroups set Salary = Convert(money,@Salary) , AccountID = @EmployeeAcc where EmployeeID = @EmployeeID;
Update Employee_EmployeeGroups set NameGroup = @GroupName Where EmployeeID = @EmployeeID;
End

Go
--Cập nhật sản phẩm

if OBJECT_ID('UpdateProducts') is not null
	Drop Proc UpdateProducts
Go

Create Proc UpdateProducts
			@ProductID int,
			@ProductCost int,
			@ProductColor varchar(30)
As
Begin

Update Product_ProductType set  ProductCost = @ProductCost,ProductColor = @ProductColor Where ProductID = @ProductID
End


Go
--Lấy thông tin tên. nhóm của 1 nhân viên theo ID
If Object_ID('GetInfoEmployees') is not null
	Drop Proc GetInfoEmployees
Go

Create Proc GetInfoEmployees
			@EmployeeID int,
			@EmployeeName varchar(30) Out,
			@EmployeeGroup varchar(30) out
As
	Begin
		Select @EmployeeName = EmployeeName, @EmployeeGroup = EmployeeGroups.GroupName
		From Employees Join EmployeeGroups On Employees.IDGroup = EmployeeGroups.GroupID 
		Where Employees.EmployeeID = @EmployeeID
	End
Go

--Seach thông tin những hóa đơn của mỗi khách hàng theo sdt và nhân viên đã bán hóa đơn đó dùng index
 If Object_ID('seachindexseekcustomers') is not null
	Drop Proc seachindexseekcustomers
				
Go

Create Proc seachindexseekcustomers
			@PhoneNumber int
As
select BillID,ProductName,Price,ProductID,SellDate,EmployeeName
From Employees, Bills join Customers On Bills.CustomerID = Customers.CustomerID
Where Bills.EmployeeSellID = Employees.EmployeeID and CustomerPhone = @PhoneNumber

Go


--SQL dynamic--------------------------

-- If Object_ID('GetData') is not null
--	Drop Proc GetData		
--Go


--Create Proc GetData
--		@Type varchar(50) 
--As
--BEGIN
--DECLARE @sql AS NVARCHAR(1000);

--SELECT @sql = 'SELECT *
--				FROM '
--				+ CASE
--				WHEN @Type = 'Products' THEN  'dbo.Product_ProductType'  
--				WHEN @Type = 'ProductType' THEN  'dbo.ProductTypesView' 
--				WHEN @Type = 'Customer' THEN	'dbo.Customers'
--				WHEN @Type = 'Groups' THEN	'dbo.EmployeeGroups'
--				WHEN @Type = 'Employees' THEN	'dbo.Employee_EmployeeGroups'
--				WHEN @Type = 'Bills' THEN	'dbo.Bills'
--				ELSE 'Product_ProductType_Admin'
--			  END+'					   
--			   ';
-- EXEC sp_executesql @sql
-- END


-- exec GetData 'Bills'

Go
--Thêm vào view dung trigger
if OBJECT_ID('AddViewEmployee_EmployeeGroups') is not null
	Drop Proc AddViewEmployee_EmployeeGroups;
Go
Create Proc AddViewEmployee_EmployeeGroups
			@EmployeeName varchar(50),
			@Sex varchar(50) ,
			@Salary money ,
			@NameGroup varchar(30),
			@AccountID int
As
			
Begin
		Insert into Employee_EmployeeGroups (EmployeeName,Sex,Salary,NameGroup,AccountID) Values(@EmployeeName,@Sex,@Salary,@NameGroup,@AccountID)

End




--Seach sản phẩm theo giá tiền và loại sản phẩm dùng index
Go

if OBJECT_ID('SeachProduct') is not null
	drop proc SeachProduct
Go
Create Proc SeachProduct
			@Min int,
			@Max int,
			@NameType varchar(50)
As
Begin
		if(@NameType ='ALL')
		begin
			select ProductID,ProductName,ProductCost
			from Products 
			Where ProductCost> @Min and  ProductCost < @Max and StatusProduct = 1
		end
		else
		begin
			select ProductID,ProductName,ProductCost
			from Products Join ProductTypes on IDType = TypeID
			Where ProductCost> @Min and  ProductCost < @Max and NameType = @NameType and StatusProduct = 1
		end
End
--Lấy thông tin hóa đơn theo Tháng

GO

if OBJECT_ID('GetBillMonth') is not null
	drop proc GetBillMonth
Go
Create Proc GetBillMonth
		@Month int
As
Begin
		Select * From Bills
		Where Convert(int,Month(SellDate)) = @Month;
End



----------------------------------------------------
------------FUNCTION--------------------------------
----------------------------------------------------
Go
--Trả về nhóm loại sản phẩn khi nhập vào Tên Nhóm sản phẩm

if OBJECT_ID('GetIDType') is not null
	Drop FUNCTION GetIDType;

Go

CREATE FUNCTION GetIDType
		(@NameType varchar(30))
		Returns int
As
Begin
Return (Select TypeID
From ProductTypes
Where NameType = @NameType);

End
Go


--Trả  về Nhóm nhân viên khi nhập vào tên nhóm nhân viên 
if OBJECT_ID('GetGroupID') is not null
	Drop FUNCTION GetGroupID;

Go

CREATE FUNCTION GetGroupID
		(@NameGroup varchar(30))
		Returns int
As
Begin
Return (Select GroupID
From EmployeeGroups
Where EmployeeGroups.GroupName = @NameGroup);

End
Go

--Trả về ID nhân viên khi đăng nhập vào hệ thống(Admin ko cần )


if OBJECT_ID('GetEmployeeID') is not null
	Drop Function GetEmployeeID;

Go

Create Function GetEmployeeID
		(@UserName varchar(30),
		@Password varchar(30),
		@Policy varchar(30))
		returns int
As
Begin

		return (Select Employees.EmployeeID
		from Accounts join Employees On Accounts.AccountID = Employees.AccountID
		Where UserName = @UserName and Password = @Password and AccountPolicy = @Policy)
End

Go

--Lấy tên của khách hàng khi nhập sdt khách hàng
if OBJECT_ID('GetCustomerName') is not null
	Drop FUNCTION GetCustomerName;

Go

CREATE FUNCTION GetCustomerName
		(@PhoneNumber int)
		Returns varchar(30)
As
Begin
Return(Select CustomerName
From Customers
Where CustomerPhone = @PhoneNumber);
End

GO


--Lấy ID khách hàng khi nhập SDT
if OBJECT_ID('GetCustomerID') is not null
	Drop FUNCTION GetCustomerID;

Go

CREATE FUNCTION GetCustomerID
		(@PhoneNumber int)
		Returns int
As
Begin
Return(Select CustomerID
From Customers
Where CustomerPhone = @PhoneNumber);
End

GO

--Lấy giá tiền khi nhập vào ID sản phẩm
if OBJECT_ID('GetProductCost') is not null
	Drop FUNCTION GetProductCost;

Go

CREATE FUNCTION GetProductCost
		(@ProductID int)
		Returns int
As
Begin
Return(Select ProductCost
From Products
Where ProductID = @ProductID);
End

Go







if OBJECT_ID('FunctionLayImg') is not null
	Drop FUNCTION FunctionLayImg;

Go

CREATE FUNCTION FunctionLayImg
		(@ProductID INT )
		Returns nvarchar(MAX)
As
Begin
Return (Select ProductImg
From Products
Where ProductID = @ProductID);

End
Go








if OBJECT_ID('Revenue') is not null
	Drop FUNCTION Revenue;

Go

CREATE FUNCTION Revenue
		(@Month int)
		Returns money
As
Begin
Return (Select Sum(Price)
From Bills
Where YEAR(GetDate()) = YEAR(SellDate) and Convert(int,MONTH(Bills.SellDate)) =  @Month);
End
Go

declare @A money
exec @A = Revenue 12
print @A



