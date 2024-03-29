USE [13th Aug CLoud PT Immersive]
GO
/****** Object:  Schema [TeamA]    Script Date: 06-11-2019 09:50:34 ******/
CREATE SCHEMA [TeamA]
GO
/****** Object:  Table [TeamA].[Addresses]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Addresses](
	[AddressID] [uniqueidentifier] NOT NULL,
	[RetailerID] [uniqueidentifier] NOT NULL,
	[Line1] [varchar](100) NOT NULL,
	[Line2] [varchar](100) NULL,
	[City] [varchar](20) NOT NULL,
	[Pincode] [char](6) NOT NULL,
	[State] [varchar](15) NOT NULL,
	[MobileNo] [char](10) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TeamA_Addresses_AddressID] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_MobileNo] UNIQUE NONCLUSTERED 
(
	[MobileNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[Admins]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Admins](
	[AdminID] [uniqueidentifier] NOT NULL,
	[AdminName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TeamA_Admin_AdminID] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[OrderDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[OrderDetails](
	[OrderDetailID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NOT NULL,
	[ProductID] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[DiscountedUnitPrice] [decimal](15, 2) NOT NULL,
	[TotalPrice] [decimal](15, 2) NOT NULL,
	[GiftPacking] [bit] NULL DEFAULT ((0)),
	[AddressID] [uniqueidentifier] NOT NULL,
	[CurrentStatus] [varchar](15) NOT NULL,
	[CreatedDateTime] [datetime] NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TeamA_OrderDetails_OrderDetailID] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[Orders]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Orders](
	[OrderID] [uniqueidentifier] NOT NULL,
	[RetailerID] [uniqueidentifier] NULL,
	[SalespersonID] [uniqueidentifier] NULL,
	[TotalQuantity] [int] NOT NULL,
	[TotalAmount] [decimal](15, 2) NOT NULL,
	[ChannelOfSale] [char](7) NOT NULL,
	[OrderDateTime] [datetime] NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TeamA_Orders_OrderID] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[Products]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Products](
	[ProductID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Category] [varchar](30) NOT NULL,
	[Stock] [int] NULL,
	[Size] [varchar](4) NULL,
	[Colour] [varchar](20) NOT NULL,
	[TechnicalSpecifications] [varchar](5000) NOT NULL,
	[CostPrice] [decimal](15, 2) NULL,
	[SellingPrice] [decimal](15, 2) NULL,
	[DiscountPercentage] [decimal](15, 2) NULL,
 CONSTRAINT [pk_TeamA_Products_ProductID] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[Retailers]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Retailers](
	[RetailerID] [uniqueidentifier] NOT NULL,
	[RetailerName] [varchar](50) NOT NULL,
	[RetailerMobile] [char](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RetailerPassword] [varchar](16) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TeamA_Retailers_RetailerID] PRIMARY KEY CLUSTERED 
(
	[RetailerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_RetailerEmail] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_RetailerMobile] UNIQUE NONCLUSTERED 
(
	[RetailerMobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_RetailerName] UNIQUE NONCLUSTERED 
(
	[RetailerName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_RetailerPassword] UNIQUE NONCLUSTERED 
(
	[RetailerPassword] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[Return]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[Return](
	[ReturnID] [uniqueidentifier] NOT NULL,
	[OrderID] [uniqueidentifier] NULL,
	[ChannelOfReturn] [varchar](7) NOT NULL,
	[ReturnAmount] [decimal](15, 2) NOT NULL,
	[ReturnDateTime] [datetime] NOT NULL,
	[LastModifiedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TeamA_Return_ReturnID] PRIMARY KEY CLUSTERED 
(
	[ReturnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[ReturnDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[ReturnDetails](
	[ReturnDetailID] [uniqueidentifier] NOT NULL,
	[ReturnID] [uniqueidentifier] NULL,
	[ProductID] [uniqueidentifier] NULL,
	[Quantity] [int] NOT NULL,
	[ReasonOfReturn] [varchar](10) NOT NULL,
	[UnitPrice] [decimal](15, 2) NOT NULL,
	[TotalPrice] [decimal](15, 2) NOT NULL,
	[AddressID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TeamA_ReturnDetails_ReturnDetailID] PRIMARY KEY CLUSTERED 
(
	[ReturnDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [TeamA].[SalesPersons]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [TeamA].[SalesPersons](
	[SalespersonID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Mobile] [char](10) NOT NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](12) NOT NULL,
	[JoiningDate] [datetime] NOT NULL,
	[AddressLine1] [varchar](500) NULL,
	[AddressLine2] [varchar](500) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[Pincode] [varchar](6) NULL,
	[Birthdate] [datetime] NOT NULL,
	[LastAccountModifiedDateTime] [datetime] NULL,
	[Salary] [decimal](15, 2) NULL,
	[Bonus] [decimal](15, 2) NULL,
	[Target] [decimal](15, 2) NULL,
 CONSTRAINT [pk_GOUsers_SalesPersons_SalespersonID] PRIMARY KEY CLUSTERED 
(
	[SalespersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uq_TeamA_SalesPersons_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uq_TeamA_SalesPersons_Mobile] UNIQUE NONCLUSTERED 
(
	[Mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uq_TeamA_SalesPersons_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [TeamA].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Addresses_RetailerID] FOREIGN KEY([RetailerID])
REFERENCES [TeamA].[Retailers] ([RetailerID])
GO
ALTER TABLE [TeamA].[Addresses] CHECK CONSTRAINT [FK_TeamA_Addresses_RetailerID]
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Addresses_AddressID] FOREIGN KEY([AddressID])
REFERENCES [TeamA].[Addresses] ([AddressID])
GO
ALTER TABLE [TeamA].[OrderDetails] CHECK CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Addresses_AddressID]
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Orders_OrderID] FOREIGN KEY([OrderID])
REFERENCES [TeamA].[Orders] ([OrderID])
GO
ALTER TABLE [TeamA].[OrderDetails] CHECK CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Orders_OrderID]
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Products_ProductID] FOREIGN KEY([ProductID])
REFERENCES [TeamA].[Products] ([ProductID])
GO
ALTER TABLE [TeamA].[OrderDetails] CHECK CONSTRAINT [FK_TeamA_OrderDetails_TeamA_Products_ProductID]
GO
ALTER TABLE [TeamA].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Orders_TeamA_Retailers_RetailerID] FOREIGN KEY([RetailerID])
REFERENCES [TeamA].[Retailers] ([RetailerID])
GO
ALTER TABLE [TeamA].[Orders] CHECK CONSTRAINT [FK_TeamA_Orders_TeamA_Retailers_RetailerID]
GO
ALTER TABLE [TeamA].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Orders_TeamA_Salespersons_SalespersonID] FOREIGN KEY([SalespersonID])
REFERENCES [TeamA].[SalesPersons] ([SalespersonID])
GO
ALTER TABLE [TeamA].[Orders] CHECK CONSTRAINT [FK_TeamA_Orders_TeamA_Salespersons_SalespersonID]
GO
ALTER TABLE [TeamA].[Return]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Orders_Return_OrderID] FOREIGN KEY([OrderID])
REFERENCES [TeamA].[Orders] ([OrderID])
GO
ALTER TABLE [TeamA].[Return] CHECK CONSTRAINT [FK_TeamA_Orders_Return_OrderID]
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Address_ReturnDetails_AddressID] FOREIGN KEY([AddressID])
REFERENCES [TeamA].[Addresses] ([AddressID])
GO
ALTER TABLE [TeamA].[ReturnDetails] CHECK CONSTRAINT [FK_TeamA_Address_ReturnDetails_AddressID]
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Products_ReturnDetails_ProductID] FOREIGN KEY([ProductID])
REFERENCES [TeamA].[Products] ([ProductID])
GO
ALTER TABLE [TeamA].[ReturnDetails] CHECK CONSTRAINT [FK_TeamA_Products_ReturnDetails_ProductID]
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD  CONSTRAINT [FK_TeamA_Return_ReturnDetails_ReturnID] FOREIGN KEY([ReturnID])
REFERENCES [TeamA].[Return] ([ReturnID])
GO
ALTER TABLE [TeamA].[ReturnDetails] CHECK CONSTRAINT [FK_TeamA_Return_ReturnDetails_ReturnID]
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD CHECK  (([DiscountedUnitPrice]>(0)))
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [TeamA].[OrderDetails]  WITH CHECK ADD CHECK  (([TotalPrice]>(0)))
GO
ALTER TABLE [TeamA].[Orders]  WITH CHECK ADD CHECK  (([ChannelOfSale]='Online' OR [ChannelOfSale]='Offline'))
GO
ALTER TABLE [TeamA].[Orders]  WITH CHECK ADD CHECK  (([TotalAmount]>(0)))
GO
ALTER TABLE [TeamA].[Orders]  WITH CHECK ADD CHECK  (([TotalQuantity]>(0)))
GO
ALTER TABLE [TeamA].[Products]  WITH CHECK ADD  CONSTRAINT [ck_TeamA_Products_CostPriceCanNotBeNegative] CHECK  (([CostPrice]>=(0)))
GO
ALTER TABLE [TeamA].[Products] CHECK CONSTRAINT [ck_TeamA_Products_CostPriceCanNotBeNegative]
GO
ALTER TABLE [TeamA].[Products]  WITH CHECK ADD  CONSTRAINT [ck_TeamA_Products_DiscountPercentageCanNotBeNegative] CHECK  (([DiscountPercentage]>=(0)))
GO
ALTER TABLE [TeamA].[Products] CHECK CONSTRAINT [ck_TeamA_Products_DiscountPercentageCanNotBeNegative]
GO
ALTER TABLE [TeamA].[Products]  WITH CHECK ADD  CONSTRAINT [ck_TeamA_Products_SellingPriceCanNotBeNegative] CHECK  (([SellingPrice]>=(0)))
GO
ALTER TABLE [TeamA].[Products] CHECK CONSTRAINT [ck_TeamA_Products_SellingPriceCanNotBeNegative]
GO
ALTER TABLE [TeamA].[Return]  WITH CHECK ADD CHECK  (([ChannelOfReturn]='Online' OR [ChannelOfReturn]='Offline'))
GO
ALTER TABLE [TeamA].[Return]  WITH CHECK ADD CHECK  (([ReturnAmount]>(0)))
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD CHECK  (([Quantity]>=(0)))
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD CHECK  (([ReasonOfReturn]='Incomplete' OR [ReasonOfReturn]='Wrong'))
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD CHECK  (([TotalPrice]>(0)))
GO
ALTER TABLE [TeamA].[ReturnDetails]  WITH CHECK ADD CHECK  (([UnitPrice]>(0)))
GO
ALTER TABLE [TeamA].[SalesPersons]  WITH CHECK ADD  CONSTRAINT [ck_TeamA_SalesPersons_CheckIfBirthDateIsAfter1950] CHECK  (([Birthdate]>='1950-01-01' AND [Birthdate]<='2012-01-01'))
GO
ALTER TABLE [TeamA].[SalesPersons] CHECK CONSTRAINT [ck_TeamA_SalesPersons_CheckIfBirthDateIsAfter1950]
GO
/****** Object:  StoredProcedure [TeamA].[AddAddress]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[AddAddress]
(
	--Parameters for the AddAddress procedure
	@AddressID uniqueidentifier,
	@RetailerID uniqueidentifier,
	@Line1 varchar(100),
	@Line2 varchar(100),
	@City varchar(20),
	@Pincode char(6),
	@State varchar(15),
	@MobileNo char(10),
	@CreationDateTime DateTime,
	@LastModifiedDateTime DateTime
)
as
begin 
	--Validation of the parameters
	if @AddressID is null 
		throw 5001,'Invalid Address ID',1
	if @RetailerID is null
		throw 5001,'Invalid Retailer ID',1
	if @Line1 is null OR @Line1 = ''
		throw 5001, 'Invalid Line1',1
	if @Line2 is null OR @Line2 = ''
		throw 5001, 'Invalid Line1',1
	if @City is null OR @City = ''
		throw 5001, 'Invalid City',1
	if @Pincode is null OR @Pincode = ''
		throw 5001,'Invalid Pincode',1
	if @State is null OR @State = ''
		throw 5001,'Invalid State',1
	if @MobileNo is null OR @MobileNo = ''
		throw 5001, 'Invalid Mobile Number',1
	if @CreationDateTime is null OR @CreationDateTime = ''
		throw 5001, 'Invalid Creation Date and Time',1
	if @LastModifiedDateTime is null OR @LastModifiedDateTime = ''
		throw 5001, 'Invalid Last Modified Date and Time',1

	
	--Inserting the values to the addresses table. 
	insert into TeamA.Addresses
	values 
	(@AddressID,@RetailerID,@Line1,@Line2,@City,@Pincode,@State,@MobileNo,
	@CreationDateTime,@LastModifiedDateTime)
end

GO
/****** Object:  StoredProcedure [TeamA].[AddAdmin]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Creation of a stored procedure AddAdmin which adds Admin to the Admins Table.
CREATE Procedure [TeamA].[AddAdmin]
(
	--Parameters for the AddAdmin procedure
	@AdminID uniqueidentifier,
	@AdminName varchar(50),
	@Email varchar(50),
	@Password varchar(20),
	@CreationDateTime DateTime,
	@LastModifiedDateTime DateTime
)
as
begin 
	--Validation of the parameters
	if @AdminID is null
		throw 5001,'Invalid Admin ID',1
	if @AdminName is null OR @AdminName = ''
		throw 5001,'Invalid Admin Name',1
	if @Email is null OR @Email = ''
		throw 5001,'Invalid Admin Name',1
	if @Password is null OR @Password = ''
		throw 5001, 'Invalid Admin Password',1
	if @CreationDateTime is null OR @CreationDateTime = ''
	    throw 5001, 'Invalid Creation Date and Time',1
	if @LastModifiedDateTime is null OR @LastModifiedDateTime = ''
		throw 5001, 'Invalid Last Modified Date and Time',1

	
	--Inserting the values to the admins table. 
	insert into TeamA.Admins
	values 
	(@AdminID,@AdminName,@Email,@Password,
	@CreationDateTime,@LastModifiedDateTime)
end

GO
/****** Object:  StoredProcedure [TeamA].[AddOrder]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[AddOrder](@orderID uniqueidentifier, @retailerID uniqueidentifier,@salespersonID uniqueidentifier, @totalQuantity int, @totalAmount decimal(15,2), @channelOfSale char(7))
as
begin

if @orderID is null
throw 50002,'Invalid Order ID',1
if @retailerID is null AND @salespersonID is null
throw 50002, 'Both retailerID and salesmanID are null. ',2
if @totalQuantity = 0
throw 50002,'Total Quantity Entered is 0',3
if @totalAmount = 0
throw 50002, 'Invalid Total Amount',4
if @channelOfSale != 'Offline' AND @channelOfSale != 'Online'
throw 50002,'Invalid Channel Of Sale',5
 begin
 INSERT INTO TeamA.Orders(OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount, ChannelOfSale, OrderDateTime, ModifiedDateTime)
 VALUES(@orderID, @retailerID, @salespersonID, @totalQuantity, @totalAmount, @channelOfSale, sysdatetime(),sysdatetime())
 end
 end 

GO
/****** Object:  StoredProcedure [TeamA].[AddOrderDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[AddOrderDetails](@orderDetailID uniqueidentifier, @orderID uniqueidentifier,@productID uniqueidentifier, @quantity int, @discountedUnitPrice decimal(15,2), @totalPrice decimal(15,2), @giftPacking bit, @addressID uniqueidentifier)
as
begin
if exists (Select OrderDetailID from TeamA.OrderDetails where OrderDetailID = @orderDetailID)
throw 50002, 'Order Detail ID already exists.',0
if @orderDetailID is null
throw 50001,'Invalid Order Detail ID',1
if @orderID is null
throw 50001,'Invalid Order ID',2
if @productID is null
throw 50001, 'Invalid Product ID',3
if @quantity = 0
throw 50001,'Quantity Cannot Be 0',4
if @discountedUnitPrice = 0
throw 50001, 'Invalid Discounted Price',5
if @totalPrice = 0
throw 50001,'Invalid Total Price',6
if @giftPacking <0 OR @giftPacking >1
throw 50001,'Invalid Entry in Gift Packing',7
if @addressID is null
throw 50001, 'Invalid Address ID',8
else
INSERT INTO TeamA.OrderDetails(OrderDetailID, OrderID, ProductID, Quantity, DiscountedUnitPrice, TotalPrice, GiftPacking, AddressID, CurrentStatus, CreatedDateTime, ModifiedDateTime)
VALUES(@orderDetailID, @orderID, @productID, @quantity, @discountedUnitPrice, @totalPrice, @giftPacking, @addressID, 'InCart', sysdatetime(), sysdatetime())
end

GO
/****** Object:  StoredProcedure [TeamA].[AddProduct]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure 
[TeamA].[AddProduct](@prodid uniqueidentifier,@prodname varchar(50),@category varchar(30),@stock int,@size varchar(4),
@colour varchar(20),@techspecs varchar(1000),@cprice money,@sprice money,@discount decimal)
as
begin
begin try
	-- Checks if Product cost price is 0 or not, throws error if blank
	if @cprice = 0
			throw 50001,'Invalid cost price',1

	-- Checks if Product selling price is 0 or not, throws error if blank
	else if @sprice = 0
			throw 50001,'Invalid selling price',1

	-- Inserts product details into Products table
	insert into TeamA.Products(ProductID,[Name],Category,Stock,Size,Colour,TechnicalSpecifications,
	CostPrice,SellingPrice,DiscountPercentage) 
	values(@prodid,@prodname,@category,@stock,@size,@colour,@techspecs,@cprice,
	@sprice,@discount)

end try

begin catch 
	throw		
end catch
end
GO
/****** Object:  StoredProcedure [TeamA].[AddRetailer]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamA].[AddRetailer](@retailerID uniqueidentifier, @retailerName varchar(30),@retailerMobile char(10),@Email varchAR(50),
@retailerPassword varchar(16), @CreationDateTime datetime, @ModifiedDateTime datetime)
AS
  BEGIN
begin try
 if @retailerName =''
   throw 500010,'Retailer Name Is Must',1;
 if @email   =''
   throw 500013,'Retailer Email Is Must',1;
 if @retailerMobile =''
   throw 500014,'Retailer Mobile Is Must',1;
 if exists (select Email from Retailers where Email = @email)
   throw 500011,'Email Already Exist',1;
 if exists (select RetailerMobile from Retailers where RetailerMobile = @retailerMobile)
   throw 500012,'Mobile No. Already Exist',1;
insert into TeamA.Retailers(RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime) values(@retailerID, @retailerName, @retailerMobile,
                    @email, @retailerPassword, @creationDateTime, @modifiedDateTime);
 select @@ROWCOUNT
end try
begin Catch
 throw; ---500000,'Retailer Not Added',1
end catch
  END

GO
/****** Object:  StoredProcedure [TeamA].[AddReturn]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[AddReturn](@returnID uniqueidentifier, @orderID uniqueidentifier, @channelOfReturn varchar(7), @returnAmount decimal(15,2), @returnDateTime datetime,@lastModifiedDateTime datetime)
as
begin
if @returnID is null
throw 50002,'Invalid Return ID',1
if @orderID is null
throw 50002,'Invalid Order ID',2
if @channelOfReturn != 'Offline' AND @channelOfReturn != 'Online'
throw 50002,'Invalid Channel Of Return',3
if @returnAmount = 0
throw 50002,'Invalid Return Amount', 4 
if @returnDateTime is null
throw 50002, 'Date Time cannot be null.',0
if @returnDateTime is null
throw 50002, 'Date Time cannot be null.',0
if @lastModifiedDateTime is null
throw 50002, 'Date Time cannot be null.',0

 begin
 INSERT INTO TeamA.[Return](ReturnID, OrderID, ChannelOfReturn, ReturnAmount, ReturnDateTime, LastModifiedDateTime)
 VALUES(@returnID, @orderID, @channelOfReturn, @returnAmount, @returnDateTime, @lastModifiedDateTime)
 end
end

GO
/****** Object:  StoredProcedure [TeamA].[AddReturnDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[AddReturnDetails](@returnDetailID uniqueidentifier, @returnID uniqueidentifier,@productID uniqueidentifier, @quantity int ,@reasonOfReturn varchar(10), @unitPrice decimal(15,2), @totalPrice decimal(15,2), @addressID uniqueidentifier) as
begin
if @returnDetailID is null
throw 50001,'Invalid Return Detail ID',1
if @returnID is null
throw 50001,'Invalid Return ID',2
if @productID is null
throw 50001, 'Invalid Product ID',3
if @quantity <= 0
throw 500001,'Quantity Entered is 0',4
if @reasonOfReturn !='Wrong' AND @reasonOfReturn != 'Incomplete'
throw 50001, 'Invalid Reason',5
if @UnitPrice = 0
throw 50001, 'Invalid Unit Price',5
if @totalPrice = 0
throw 50001,'Invalid Total Price',6
if @addressID is null
throw 50001, 'Invalid Address ID',0
INSERT INTO TeamA.ReturnDetails(ReturnDetailID, ReturnID, ProductID, Quantity, ReasonOfReturn, UnitPrice, TotalPrice, AddressID)
VALUES(@returnDetailID, @returnID, @productID, @quantity,@reasonOfReturn, @UnitPrice, @totalPrice, @addressID)
end

GO
/****** Object:  StoredProcedure [TeamA].[AddSalesPerson]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure 
[TeamA].[AddSalesPerson](@salespersonid uniqueidentifier,@salespersonname varchar(30),@mobile char(10),
@email varchar(100),@password varchar(12),@salary decimal(15,2),@bonus decimal(15,2),@target decimal(15,2),@joiningdate datetime,
@addressl1 varchar(500),@addressl2 varchar(500),@city varchar(100),@state varchar(100),@pincode varchar(6),
@birthdate datetime,@lastmodified datetime)
as
begin

	-- Inserts the values into the SalesPeople table
	insert into TeamA.SalesPersons (SalespersonID,[Name],Mobile,Email,[Password],Salary,
	Bonus,[Target],JoiningDate,AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,LastAccountModifiedDateTime)
	 values(@salespersonid,@salespersonname,@mobile,
	@email,@password,@salary,@bonus,@target,@joiningdate,@addressl1,@addressl2,@city,@state,@pincode,
	@birthdate,@lastmodified)

end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteAddress]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Creation of a stored procedure DeleteAddress which deletes addresses from the Addesses Table.
CREATE Procedure [TeamA].[DeleteAddress](@AddressID uniqueidentifier)
as 
begin
	--Validation of the parameter
	if @AddressID is null
		throw 5001,'Invalid Address ID',1
	--Exception handling
	begin try
		--Deleting the Address for Addresses table
		delete from TeamA.Addresses where AddressID=@AddressID 
	end try
	begin catch
		PRINT @@ERROR;
		throw 5000,'Values not deleted.',4
		return 0
	end catch
end
GO
/****** Object:  StoredProcedure [TeamA].[DeleteOrderDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[DeleteOrderDetails](@orderDetailID uniqueidentifier)
as
begin

if exists (Select OrderDetailID from TeamA.OrderDetails where OrderDetailID = @orderDetailID )
 begin
 DELETE FROM TeamA.OrderDetails WHERE OrderDetailID = @orderDetailID 
end
else
 throw 50000,'No such record exists.',3


end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteOrderDetailsByOrderID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[DeleteOrderDetailsByOrderID](@orderID uniqueidentifier)
as
begin

if exists (Select OrderID from TeamA.OrderDetails where OrderID = @orderID )
 begin
 DELETE FROM TeamA.OrderDetails WHERE OrderID = @orderID 
end
else
 throw 50000,'No such record exists.',3


end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteOrders]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[DeleteOrders](@orderID uniqueidentifier)
as
begin

if exists (Select OrderID from TeamA.Orders where OrderID = @orderID )
 begin
 DELETE FROM TeamA.Orders WHERE OrderID = @orderID 
end
else
 throw 50000,'No such record exists.',3


end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteProduct]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[DeleteProduct](@prodid uniqueidentifier) as
begin
	-- Deletes product based on given productid
	delete from TeamA.Products where
	ProductID =(  select ProductID from TeamA.Products where ProductID=@prodid)
end
GO
/****** Object:  StoredProcedure [TeamA].[DeleteRetailer]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[DeleteRetailer](@retailerID uniqueidentifier)
as
begin
	begin try         
		if exists (select * from TeamA.Retailers where RetailerID = @retailerID)
			delete from TeamA.Retailers where RetailerID = @retailerID;
	end try
	begin catch
		 PRINT @@ERROR;
		 throw 50016,'Values not deleted.',2
		 return 0
	end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteReturn]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[DeleteReturn](@returnID uniqueidentifier)
as
begin
begin try
DELETE FROM TeamA.[Return] WHERE ReturnID = @returnID
end try
begin catch
 PRINT @@ERROR;
 throw 5006,'Values not deleted.',3
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteReturnDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[DeleteReturnDetails](@returnID uniqueidentifier, @productID uniqueidentifier)
as
begin
begin try
DELETE FROM TeamA.ReturnDetails where ReturnID = @returnID AND ProductID = @productID
end try
begin catch
 PRINT @@ERROR;
 throw 5000,'Values not deleted.',3
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[DeleteSalesPerson]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[DeleteSalesPerson](@salespersonid uniqueidentifier) as
begin
    -- Delete sale person's records from the SalesPeople table based on SalespersonID
	delete from TeamA.SalesPersons where SalespersonID=
	(select SalespersonID from TeamA.SalesPersons where SalespersonID = @salespersonid)

end
GO
/****** Object:  StoredProcedure [TeamA].[GetAddressByAddressID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [TeamA].[GetAddressByAddressID](@AddressID uniqueidentifier)
as 
begin
	--Exception handling
	begin try
		--Select all the addresses of the retailer
		select * from TeamA.Addresses where AddressID = @AddressID
	end try
	begin catch
		PRINT @@ERROR;
		throw 5000,'Invalid values fetched',1
		return 0
	end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAddressByRetailerID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Creation of a stored procedure AddAddress which adds addresses to the Addesses Table.
Create Procedure [TeamA].[GetAddressByRetailerID](@RetailerID uniqueidentifier)
as 
begin
	--Exception handling
	begin try
		--Select all the addresses of the retailer
		select * from TeamA.Addresses where RetailerID = @RetailerID
	end try
	begin catch
		PRINT @@ERROR;
		throw 5000,'Invalid values fetched',1
		return 0
	end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAdminbyEmailAndPassword]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [TeamA].[GetAdminbyEmailAndPassword](@Email varchar(50),@Password varchar(20))
as 
 begin
	begin try
		SELECT * FROM TeamA.Admins where Email=@Email and Password=@Password
	end try
	begin catch
		PRINT @@ERROR;
		throw 5001,'Invalid Values Fetched',6
		return 0
    end catch
 end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllAddresses]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Creation of a stored procedure GetAllAddress which gets all the addresses' data from the Addesses Table. 
Create Procedure [TeamA].[GetAllAddresses]
as
begin
	--Exception handling
	begin try
		--Selecting all the Address from Addresses table
		select * from TeamA.Addresses
	end try
	begin catch
		PRINT @@ERROR;
		throw 5000,'Invalid values fetched',1
		return 0
	end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllOrderDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetAllOrderDetails]
as
begin
Select OrderDetailID, OrderID, ProductID, Quantity, DiscountedUnitPrice, TotalPrice, GiftPacking, AddressID, CurrentStatus
 from TeamA.OrderDetails

end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllOrders]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetAllOrders]
as
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount, ChannelOfSale, OrderDateTime, ModifiedDateTime
from TeamA.Orders
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllProducts]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetAllProducts] as
begin
	-- Returns products table from Products
	select ProductID,[Name],Category,Stock,Size,Colour,TechnicalSpecifications,
	CostPrice,SellingPrice,DiscountPercentage from TeamA.Products
end
GO
/****** Object:  StoredProcedure [TeamA].[GetAllRetailers]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetAllRetailers]
as        
begin            

select RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime from TeamA.Retailers;

end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllReturnDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [TeamA].[GetAllReturnDetails]
 as 
begin
begin
select * from TeamA.ReturnDetails
end
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllReturns]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [TeamA].[GetAllReturns]
 as 
begin
begin
select * from TeamA.[Return]
end
end

GO
/****** Object:  StoredProcedure [TeamA].[GetAllSalesPersons]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetAllSalesPersons] as
begin

	-- Returns the SalesPeople table
	select SalespersonID,[Name],Mobile,Email,[Password],Salary,
	Bonus,[Target],JoiningDate,AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,
	LastAccountModifiedDateTime from TeamA.SalesPersons 
end
GO
/****** Object:  StoredProcedure [TeamA].[GetOrderDetailByOrderDetailID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [TeamA].[GetOrderDetailByOrderDetailID](@orderDetailID uniqueidentifier)
as
begin
if exists (Select OrderDetailID from TeamA.OrderDetails where OrderDetailID = @orderDetailID)
 begin
 Select OrderDetailID, OrderID, ProductID, Quantity, DiscountedUnitPrice, TotalPrice, GiftPacking, AddressID, CurrentStatus, CreatedDateTime, ModifiedDateTime
 from TeamA.OrderDetails where OrderDetailID = @orderDetailID
 end
else
 throw 50000,'Order Detail Does Not Exist.',1

end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrderDetailsByOrderID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[GetOrderDetailsByOrderID](@orderID uniqueidentifier)
as
begin
if exists (Select OrderID from TeamA.OrderDetails where OrderID = @orderID)
 begin
 Select OrderDetailID, OrderID, ProductID, Quantity, DiscountedUnitPrice, TotalPrice, GiftPacking, AddressID, CurrentStatus, CreatedDateTime, ModifiedDateTime
 from TeamA.OrderDetails where OrderID = @orderID
 end
else
 throw 50000,'Order Does Not Exist.',1

end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrderDetailsByProductID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetOrderDetailsByProductID](@productID uniqueidentifier)
as
begin
if exists (Select ProductID from TeamA.OrderDetails where ProductID = @productID)
 begin
 Select OrderDetailID, OrderID, ProductID, Quantity, DiscountedUnitPrice, TotalPrice, GiftPacking, AddressID, CurrentStatus
 from TeamA.OrderDetails where ProductID = @productID
 end
else
 throw 50000,'Product Does Not Exist.',2
end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrdersByOrderID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetOrdersByOrderID](@orderID uniqueidentifier)
as
begin
if exists (Select OrderID from TeamA.Orders where OrderID = @orderID )
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount,
ChannelOfSale, OrderDateTime, ModifiedDateTime from TeamA.Orders where OrderID = @orderID
end 
else
 throw 50005,'Invalid values fetched.',2
end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrdersByRetailerID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[GetOrdersByRetailerID](@retailerID uniqueidentifier)
as
begin
if exists (Select OrderID from TeamA.Orders where RetailerID = @retailerID )
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount,
ChannelOfSale, OrderDateTime, ModifiedDateTime from TeamA.Orders where  RetailerID = @retailerID
end 

else
begin
select * from TeamA.Orders where RetailerID=@retailerID
end
end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrdersBySalespersonID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetOrdersBySalespersonID](@salespersonID uniqueidentifier)
as
begin
if exists (Select OrderID from TeamA.Orders where SalespersonID = @salespersonID)
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount,
ChannelOfSale, OrderDateTime, ModifiedDateTime from TeamA.Orders where  SalespersonID = @salespersonID
end 
else
 throw 50005,'No order found against this salespersonID',3
end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrdersSoldOffline]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetOrdersSoldOffline]
as
begin
if exists (Select OrderID from TeamA.Orders where ChannelOfSale = 'Offline')
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount,
ChannelOfSale, OrderDateTime, ModifiedDateTime from TeamA.Orders where  ChannelOfSale = 'Offline'
end 
else
 throw 50005,'No offline Order Placed.',3
end

GO
/****** Object:  StoredProcedure [TeamA].[GetOrdersSoldOnline]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetOrdersSoldOnline]
as
begin
if exists (Select OrderID from TeamA.Orders where ChannelOfSale = 'Online')
begin
Select OrderID, RetailerID, SalespersonID, TotalQuantity, TotalAmount,
ChannelOfSale, OrderDateTime, ModifiedDateTime from TeamA.Orders where  ChannelOfSale = 'Online'
end 
else
 throw 50005,'No online Order Placed.',3
end

GO
/****** Object:  StoredProcedure [TeamA].[GetProductByName]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetProductByName](@prodname varchar(50)) as
begin
    	--Returns products from the Products table with the given product name
		select ProductID,[Name],Category,Stock,Size,Colour,TechnicalSpecifications,
	CostPrice,SellingPrice,DiscountPercentage from TeamA.Products where [Name] = @prodname 
end
GO
/****** Object:  StoredProcedure [TeamA].[GetProductByProductID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetProductByProductID](@prodid uniqueidentifier) as
begin
 select ProductID,[Name],Category,Stock,Size,Colour,TechnicalSpecifications,
	CostPrice,SellingPrice,DiscountPercentage from TeamA.Products where ProductID = @prodid
end
GO
/****** Object:  StoredProcedure [TeamA].[GetProductsByCategory]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetProductsByCategory](@category varchar(30)) as
begin
    	-- Returns products which belong to the given category
		select ProductID,[Name],Category,Stock,Size,Colour,TechnicalSpecifications,
	CostPrice,SellingPrice,DiscountPercentage from TeamA.Products where Category = @category
end
GO
/****** Object:  StoredProcedure [TeamA].[GetRetailerByEmail]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetRetailerByEmail](@email varchar(50))
as
begin 
if exists (select Email from TeamA.Retailers where Email = @email)
select RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime from TeamA.Retailers where email = @email; 
else
throw   50009,'Retailer Not Found.',1
end

GO
/****** Object:  StoredProcedure [TeamA].[GetRetailerByEmailAndPassword]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamA].[GetRetailerByEmailAndPassword] (@email varchar(50), @retailerPassword varchar(16))
as
begin    
select RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime from TeamA.Retailers where email = @email and RetailerPassword = @retailerPassword;
end

GO
/****** Object:  StoredProcedure [TeamA].[GetRetailerByName]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetRetailerByName](@retailerName varchar(50))
as
begin       
if exists (select RetailerName from TeamA.Retailers where RetailerName = @retailerName)
select RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime from TeamA.Retailers where RetailerName = @retailerName; 
else 
throw   50009,'Retailer Not Found.',1
end

GO
/****** Object:  StoredProcedure [TeamA].[GetRetailerByRetailerID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetRetailerByRetailerID](@retailerID uniqueidentifier)
as
begin             
if exists (select RetailerID from TeamA.Retailers where RetailerID = @retailerID)
begin
select RetailerID, RetailerName, RetailerMobile, Email, RetailerPassword, CreationDateTime, ModifiedDateTime from TeamA.Retailers where RetailerID = @retailerID;
end
else
throw 50009,'Retailer Not Found.',1
end

GO
/****** Object:  StoredProcedure [TeamA].[GetReturnByOrderID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [TeamA].[GetReturnByOrderID](@orderID uniqueidentifier)
as 
begin

begin try
Select * from TeamA.[Return] where OrderID = @orderID
end try
begin catch
 PRINT @@ERROR;
 throw 5005,'Invalid values fetched.',2
 return 0
end catch

end

GO
/****** Object:  StoredProcedure [TeamA].[GetReturnByReturnID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [TeamA].[GetReturnByReturnID](@returnID uniqueidentifier)
as 
begin

begin try
Select * from TeamA.[Return] where ReturnID = @returnID
end try
begin catch
 PRINT @@ERROR;
 throw 5005,'Invalid values fetched.',2
 return 0
end catch

end

GO
/****** Object:  StoredProcedure [TeamA].[GetReturnDetailsByProductID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [TeamA].[GetReturnDetailsByProductID](@productID uniqueidentifier)
as
begin
begin try
Select * from TeamA.ReturnDetails where ProductID = @productID
end try
begin catch
 PRINT @@ERROR;
 throw 5000,'Invalid values fetched.',2
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[GetReturnDetailsByRetailerID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[GetReturnDetailsByRetailerID](@retailerID uniqueidentifier)
as
begin
if exists (Select OrderID from TeamA.Orders where RetailerID = @retailerID )
begin
select ReturnDetailID,TeamA.[ReturnDetails].ReturnID,ProductID,Quantity,ReasonOfReturn,UnitPrice,TotalPrice,AddressID from TeamA.ReturnDetails inner join TeamA.[Return] on TeamA.ReturnDetails.ReturnID = TeamA.[Return].ReturnID inner join TeamA.[Orders]
on TeamA.[Return].OrderID= TeamA.Orders.OrderID where TeamA.Orders.RetailerID = @retailerID;
end 
else
select ReturnDetailID,TeamA.[ReturnDetails].ReturnID,ProductID,Quantity,ReasonOfReturn,UnitPrice,TotalPrice,AddressID from TeamA.ReturnDetails inner join TeamA.[Return] on TeamA.ReturnDetails.ReturnID = TeamA.[Return].ReturnID inner join TeamA.[Orders]
on TeamA.[Return].OrderID= TeamA.Orders.OrderID where TeamA.Orders.RetailerID = @retailerID;
 --throw 50005,'No return found against this retailerID',2
end


GO
/****** Object:  StoredProcedure [TeamA].[GetReturnDetailsByReturnID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[GetReturnDetailsByReturnID](@returnID uniqueidentifier)
as
begin
begin try
Select * from TeamA.ReturnDetails where ReturnID = @returnID
end try
begin catch
 PRINT @@ERROR;
 throw 5007,'Invalid values fetched.',1
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[GetSalesPersonByEmail]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetSalesPersonByEmail](@email varchar(100)) as
begin
	-- Returns Sales person with given email
	 select SalespersonID,[Name],Mobile,Email,[Password],Salary,Bonus,[Target],JoiningDate,
	AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,LastAccountModifiedDateTime
	 from TeamA.SalesPersons where 
	 exists (select Email from TeamA.SalesPersons where Email = @email)
end
GO
/****** Object:  StoredProcedure [TeamA].[GetSalesPersonByEmailAndPassword]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetSalesPersonByEmailAndPassword](@email varchar(100),@password varchar(12)) as
begin
		-- Returns Sales person with given email and password
	select SalespersonID,[Name],Mobile,Email,[Password],Salary,Bonus,[Target],JoiningDate,
	AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,LastAccountModifiedDateTime 
	from TeamA.SalesPersons where Email =
	(select Email from TeamA.SalesPersons where Email = @email 
	and [Password] = @password)
end
GO
/****** Object:  StoredProcedure [TeamA].[GetSalesPersonByName]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetSalesPersonByName](@salespersonname varchar(30)) as
begin
		-- Returns Sales people with given name
		select SalespersonID,[Name],Mobile,Email,[Password],Salary,Bonus,[Target],JoiningDate,
		AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,LastAccountModifiedDateTime
		from TeamA.SalesPersons where
		exists (select [Name] from TeamA.SalesPersons where [Name] = @salespersonname)

end
GO
/****** Object:  StoredProcedure [TeamA].[GetSalesPersonBySalesPersonID]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[GetSalesPersonBySalesPersonID](@salespersonid uniqueidentifier) as
begin
 -- Returns the Sales Person according to his/her ID
 select SalespersonID,[Name],Mobile,Email,[Password],Salary,
	Bonus,[Target],JoiningDate,AddressLine1,AddressLine2,City,[State],Pincode,Birthdate,LastAccountModifiedDateTime
	 from TeamA.SalesPersons  where 
	 SalespersonID = (select SalesPersonID from TeamA.SalesPersons where SalespersonID = @salespersonid)
end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateAddress]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [TeamA].[UpdateAddress](@AddressID uniqueidentifier,@RetailerID uniqueidentifier,
	@Line1 varchar(100),@Line2 varchar(100),@City varchar(50),@Pincode char(6),@State varchar(20),@MobileNo char(10),
	@CreationDateTime DateTime,@LastModifiedDateTime DateTime)
as
begin
	--Validation of the parameters 
	if @AddressID is null 
		throw 5001,'Invalid Address ID',1
	if @RetailerID is null 
		throw 5001,'Invalid Retailer ID',1
	if @Line1 is null OR @Line1 = ''
		throw 5001, 'Invalid Line1',1
	if @Line2 is null OR @Line2 = ''
		throw 5001, 'Invalid Line1',1
	if @City is null OR @City = ''
		throw 5001, 'Invalid City',1
	if @Pincode is null OR @Pincode = ''
		throw 5001,'Invalid Pincode',1
	if @State is null OR @State = ''
		throw 5001,'Invalid State',1
	if @MobileNo is null OR @MobileNo = ''
		throw 5001, 'Invalid Mobile Number',1
	if @CreationDateTime is null OR @CreationDateTime = ''
			throw 5001, 'Invalid Creation Date and Time',1
	if @LastModifiedDateTime is null OR @LastModifiedDateTime = ''
			throw 5001, 'Invalid Last Modified Date and Time',1
	--Exception handling
	begin try
		--Update details in the table
		update TeamA.Addresses
		set
		Line1=@Line1,
		Line2=@Line2,
		City=@City,
		Pincode=@Pincode,
		[State]=@State,
		MobileNo=@MobileNo
		where AddressID=@AddressID
	end try
	begin catch
		PRINT @@ERROR;
		throw 5000,'Values Not Updated',1
		return 0
	end catch
end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateOrder]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[UpdateOrder](@orderID uniqueidentifier, @totalQuantity int, @totalAmount decimal(15,2))
as
begin
if exists (Select OrderID from TeamA.Orders where OrderID = @orderID )
 begin
 Update TeamA.Orders
 SET TotalQuantity = @totalQuantity, TotalAmount = @totalAmount, ModifiedDateTime = sysdatetime()
 where OrderID = @orderID 
 end
else
throw 50000,'No such record exists.',3
end

GO
/****** Object:  StoredProcedure [TeamA].[UpdateOrderDetail]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[UpdateOrderDetail](@orderID uniqueidentifier, @currentStatus varchar(15))
as
begin
if exists (Select OrderID from TeamA.OrderDetails where OrderID = @orderID )
 begin
 Update TeamA.OrderDetails
 SET CurrentStatus = @currentStatus, ModifiedDateTime = sysdatetime()
 where OrderID = @orderID 
 end
else
throw 50000,'No such record exists.',3
end

GO
/****** Object:  StoredProcedure [TeamA].[UpdateOrderDetailForReturn]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [TeamA].[UpdateOrderDetailForReturn](@orderDetailID uniqueidentifier, @currentStatus varchar(15))
as
begin
if exists (Select OrderDetailID from TeamA.OrderDetails where OrderDetailID = @orderDetailID )
 begin
 Update TeamA.OrderDetails
 SET CurrentStatus = @currentStatus, ModifiedDateTime = sysdatetime()
 where OrderDetailID = @orderDetailID
 end
else
throw 50000,'No such record exists.',3
end

GO
/****** Object:  StoredProcedure [TeamA].[UpdateProductDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateProductDetails](@prodid uniqueidentifier, @techspecs varchar(1000),@costprice decimal(15,2),
@sellingprice decimal(15,2)) as
begin
	-- updates products with the given details based on the productid
	update TeamA.Products 
	set TechnicalSpecifications = @techspecs , CostPrice = @costprice, SellingPrice = @sellingprice
	where 
	ProductID =  (select ProductID from TeamA.Products where ProductID=@prodid)
end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateProductDiscount]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateProductDiscount](@prodid uniqueidentifier,@discount decimal(15,2)) as
begin
	-- updates stock of product based on productid
	update TeamA.Products set DiscountPercentage = @discount where
	ProductID= (select ProductID from TeamA.Products where ProductID=@prodid)

end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateProductStock]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateProductStock](@prodid uniqueidentifier,@stock int) as
begin
	-- updates stock of product based on productid
	update TeamA.Products set Stock = @stock where
	ProductID= (select ProductID from TeamA.Products where ProductID=@prodid)

end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateRetailer]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateRetailer](@retailerID uniqueidentifier, @retailerName varchar(50),@retailerMobile char(10), @email varchar(50),
                                        @modifiedDateTime datetime)
as    
begin
begin try
           
		  if exists (select * from TeamA.Retailers where RetailerID = @retailerID)
	        update TeamA.Retailers 
				set
				RetailerName      = @retailerName,
			    RetailerMobile    = @retailerMobile,
				Email             = @email,			    
				ModifiedDatetime  = @modifiedDateTime
			where RetailerID = @retailerID 
											

end try
begin catch
 PRINT @@ERROR;
 throw 50015,'Retailer not updated.',3
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[UpdateRetailerPassword]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*   
  Stored procedure to update retailer password
     Project Name       : GreatOutdoors
	 Use Case           : Retailer
	 Developer Name     : Sarthak lav 
	 Creation Date      : 01/10/2019
	 Modified Date      : 01/10/2019
	 
*/
CREATE procedure [TeamA].[UpdateRetailerPassword](@retailerID uniqueidentifier, @retailerPassword varchar(16), @modifiedDateTime datetime)
as
begin
begin try     
		if exists (select * from TeamA.Retailers where RetailerID = @retailerID)
		   update TeamA.Retailers
		   set
		   RetailerPassword = @retailerPassword,
		   ModifiedDateTime = @modifiedDateTime
		   where RetailerID = @retailerID

end try
begin catch
 PRINT @@ERROR;
 throw 50017,'Password not updated.',3
 return 0
end catch
end

GO
/****** Object:  StoredProcedure [TeamA].[UpdateSalesPerson]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateSalesPerson](@salespersonid uniqueidentifier,@name varchar(30),@mobile char(10),@email varchar(100)) as
begin
		update TeamA.SalesPersons
		set [Name] = @name, Email = @email, Mobile = @mobile
		where SalespersonID =  (select SalespersonID from TeamA.SalesPersons where SalespersonID = @salespersonid)
	
end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateSalesPersonDetails]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateSalesPersonDetails](@salespersonid uniqueidentifier,@salary decimal(15,2),@bonus decimal(15,2),@target decimal(15,2)) as
begin
		update TeamA.SalesPersons
		set Salary = @salary, Bonus = @bonus, [Target] = @target
		where SalespersonID =  (select SalespersonID from TeamA.SalesPersons where SalespersonID = @salespersonid)
	
end
GO
/****** Object:  StoredProcedure [TeamA].[UpdateSalesPersonPassword]    Script Date: 06-11-2019 09:50:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [TeamA].[UpdateSalesPersonPassword](@salespersonid uniqueidentifier,@password varchar(12)) as
begin
	 -- Update password of salesperson and lastmodified date time to current date time
		update TeamA.SalesPersons
		set [Password] = @password
	 where SalespersonID = (select SalespersonID from TeamA.SalesPersons where SalespersonID = @salespersonid)

end
GO
