use master;
go
drop database if exists TheGioiDiDong;
go

create database TheGioiDiDong;
go


use TheGioiDiDong;
go

if OBJECT_ID('ProductsDetail') is not null
	Drop Table ProductsDetail;
use TheGioiDiDong;
go

 Create Table ProductsDetail(
 ProductID int  identity(1,1) not null Primary Key,
 ProductsDetail varchar(1000),
 Producer varchar(50) not null,
 IDType int not null
 --CONSTRAINT fk_ProductsDetail_Products
 --FOREIGN KEY (ProductID, IDType)
 --REFERENCES Products (ProductID, IDType)

 );

 Go
if OBJECT_ID('NumberOfProduct') is not null
	Drop Table NumberOfProduct;

Create Table NumberOfProduct(
ID int not null identity(1,1) primary key,
ProductName varchar(30) 
);
Go
if OBJECT_ID('ProductType') is not null
	Drop Table ProductType;

Create Table ProductType(
IDType int not null Primary Key,
Name varchar not null,
);


 Go
if OBJECT_ID('Products') is not null
	Drop Table Products;

Create table Products (
IDType int not null Primary key,
ProductID int not null identity(10,10),
ProductName varchar(30) not null,
ProductImg Varbinary(MAX),
Number int not null,
ProductCost int not null
CONSTRAINT fk_Products_ProductsID
FOREIGN KEY (ProductID)
REFERENCES ProductsDetail (ProductID),



CONSTRAINT fk_Product_IDType
FOREIGN KEY (IDType)
REFERENCES ProductType (IDType)

--CONSTRAINT fk_Products_ProductsID2
--FOREIGN KEY (ProductID)
--REFERENCES NumberOfProduct (ProductID)


 );



Go
if OBJECT_ID('Employees') is not null
	Drop Table Employees;

 Create Table Employees(
 ID int identity(1,1),
 EmployeeName varchar(50) not null,
 Sex varchar(50) not null,
 Salary money not null,
 IDGroup int not null Primary Key

 );
Go
if OBJECT_ID('EmployeeGroup') is not null
	Drop Table EmployeeGroup;
Go

 Create Table EmployeeGroup(
 IDGroup int not null Primary Key,
 GroupName varchar(30) not null,
 CONSTRAINT fk_EmployeeGroup_IDGroup
   FOREIGN KEY (IDGroup)
   REFERENCES Employees (IDGroup)

 );
Go

if OBJECT_ID('Accounts') is not null
	Drop Table Accounts;
Create Table Accounts(
IDAcc int not null identity(1,1),
UserName varchar(30) not null,
Passwd varchar(30) not null,
AccPolicy varchar (30) not null
);

Go


 
if OBJECT_ID('Customer') is not null
	Drop Table Customer;

Create Table Customer(
IDCustomer int not null identity(1,1) Primary Key,
CustomerName varchar(30) not null,
PhoneNumber int not null,

 );

 Go
if OBJECT_ID('CustomerProduct') is not null
	Drop Table CustomerProduct;

Create Table CustomerProduct(
IDCustomer int not null Primary key,
ProductName varchar(30) not null,
IDProduct int not null
CONSTRAINT fk_CustomerProduct_IDCustomer
FOREIGN KEY (IDCustomer)
REFERENCES Customer (IDCustomer),

); 

-- San pham khach hang da mua
Go


-- insert into Products values
--('Note10Plus', Convert(Varbinary,'D:\HK1 Nam3\ImgHeQuanTri\Note10Plus.png') , 20000000);

Go
 Select * From Products;


-- If OBJECT_ID('insertImgProducts') is not null
--	Drop Proc insertImgProducts;
	
--Go

-- Create Proc insertImgProducts
-- @ProductName Varchar(50),
-- @Img Varchar(255)
 
-- As

-- Begin 

-- Declare @a AS Int;
-- Execute xp_fileexist @Img, @a Output;
-- If(@a = 0)		
--	Raiserror ('File [%s] not found.' , 11, 1 , @Img);
--	Else
--	Begin
--		Declare @cmd AS Varchar(1024)
--		Set @cmd = 'INSERT Into Products (ProductImg) 
--					Select ' +  'BulkColumn from Openrowset' + '(Bulk ''' + @Img + ''', Single_Blob) As Picture 
--					From Products
--					Where ProductName = ' + @ProductName + '' 
--		--	 Value (BulkColumn from Openrowset' + '(Bulk ''' + @Img + ''', Single_Blob) As Picture')
--		--	 Select ' + CONVERT(Varchar, @Id) +',' + + '''' + @ProductName +	''' , BulkColumn from Openrowset' + '(Bulk ''' + @Img + ''', Single_Blob) As Picture'	
--			Exec(@cmd)

--	END
--END
 
-- Go

-- Exec insertImgProducts 'Note10Plus', 'D:\HK1 Nam3\ImgHeQuanTri\Note10Plus.png'
 

INSERT INTO Customer (CustomerName, PhoneNumber)
VALUES ('Hoang Kim Nguyen' , 0352878693);

INSERT INTO CustomerProduct(IDCustomer,ProductName,IDProduct)
VALUES (1,'Note10Plus',33);

INSERT INTO NumberOfProduct(ProductName)
VALUES ('Note10Plus');