﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO.Entities
{
    public abstract class User
    {
        private string _name;
        private string _userName;
        private string _password;
        private string _email;

        public string Name { get => _name; set => _name = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Email { get => _email; set => _email = value; }
        
    }

    public class Admin : User
    {
        private int _adminId;
        public int AdminId { get => _adminId; set => _adminId = value; }

    }
    public class Product
    {
        private int productID;
        public int ProductID { get => productID; set => productID = value; }

        private string productName;

        public string ProductName { get => productName; set => productName = value; }

        private int categoryID;
        public int CategoryID { get => categoryID; set => categoryID = value; }

        private int specificationID;
        public int SpecificationID { get => specificationID; set => specificationID = value; }


        private double costPrice;

        public double CostPrice { get => costPrice; set => costPrice = value; }



        private Boolean available;

        public bool Available { get => available; set => available = value; }

        private double sellingPrice;
        public double SellingPrice { get => sellingPrice; set => sellingPrice = value; }


        public Product()
        {
            ProductID = 0;
            ProductName = string.Empty;
            CategoryID = 0;
            SpecificationID = 0;
            CostPrice = 0;
            SellingPrice = 0;
            Available = false;
        }
    }
    
    
    // Retailer classs 
    public class Retailer:User
    {
        private int _retailerID;
        private string _retailerContactNumber;

        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public string RetailerContactNumber { get => _retailerContactNumber; set => _retailerContactNumber = value; }

        public Retailer()
        {
            RetailerID = 0;
            Name = string.Empty;
            Password = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            RetailerContactNumber = string.Empty;

        }
    }

    public class Category
    {
        private int _productID;
        private int _categoryID;
        private string _categoryName;

        public int ProductID { get => _productID; set => _productID = value; }
        public int CategoryID { get => _categoryID; set => _categoryID = value; }
        public string CategoryName { get => _categoryName; set => _categoryName = value; }


        public Category()
        {
            ProductID = 0;
            CategoryID = 0;
            CategoryName = string.Empty;



        }
    }

    public class Order
    {
        private int _orderID;
        private int _retailerID;
        private int _salesmanID;//order id 
        private int _productID;          //one order id may have multiple product id
        private int _quantity;     //each product has its own quantity
        private int _sellingPrice;       //each product has a unique selling price
        private int _totalAmount;         //_quantity*_sellingPrice
        private int _amountPayable;         //total amount payable
        private string _finalDelieveryAddress;
        private DateTime _timeofsale;           //for time on shelf      
        private string _channelOfSale;          //online or offline
        private string _status;
        private int _categoryID;
        //status of order{in Cart, Under Processing, Processed, Sent for Delivery, Delivered}

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int ProductID { get => _productID; set => _productID = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public int SellingPrice { get => _sellingPrice; set => _sellingPrice = value; }
        public int TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        public int AmountPayable { get => _amountPayable; set => _amountPayable = value; }
        public string FinalDelieveryAddress { get => _finalDelieveryAddress; set => _finalDelieveryAddress = value; }
        public DateTime Timeofsale { get => _timeofsale; set => _timeofsale = value; }
        public string ChannelOfSale { get => _channelOfSale; set => _channelOfSale = value; }
        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public string Status { get => _status; set => _status = value; }
        public int SalesmanID { get => _salesmanID; set => _salesmanID = value; }
        public int CategoryID { get => _categoryID; set => _categoryID = value; }
    }

    public class Inventory
    {
        private int productID;

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private int productQuantity;

        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }


        private double costPrice;

        public double CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }


        public Inventory()
        {
            productID = 0;
            productQuantity = 0;
            costPrice = 0;

        }
    }

    public class Return
    {

        private int _returnID;
        private int _orderID;
        private int _productID;
        private bool _reasonIncomplete;
        private bool _reasonWrong;
        private double _returnValue;
        private int _returnQuantity;

        public int ReturnID { get => _returnID; set => _returnID = value; }
        public int OrderID { get => _orderID; set => _orderID = value; }
        public int ProductID { get => _productID; set => _productID = value; }
        public bool ReasonIncomplete { get => _reasonIncomplete; set => _reasonIncomplete = value; }
        public bool ReasonWrong { get => _reasonWrong; set => _reasonWrong = value; }
        public double ReturnValue { get => _returnValue; set => _returnValue = value; }
        public int ReturnQuantity { get => _returnQuantity; set => _returnQuantity = value; }


    }

    public class Specification
    {
        private int _productID;
        private int _specificationID;
        private string _color;
        private int _size;
        private string _techSpec;


        public int ProductID { get => _productID; set => _productID = value; }
        public int SpecificationID { get => _specificationID; set => _specificationID = value; }
        public string Color { get => _color; set => _color = value; }
        public int Size { get => _size; set => _size = value; }
        public string Techspec { get => _techSpec; set => _techSpec = value; }

    }

    public class Discount_Entities
    {
        private int _orderID;
        private int _retailerID;
        private double _retailerDiscount;
        private double _categoryDiscount;

        public int OrderID { get => _orderID; set => _orderID = value; }
        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public double RetailerDiscount { get => _retailerDiscount; set => _retailerDiscount = value; }
        public double CategoryDiscount { get => _categoryDiscount; set => _categoryDiscount = value; }
    }

    public class Sales
    {
        private int salesManID;

        public int SalesManID
        {
            get { return salesManID; }
            set { salesManID = value; }
        }
        private string salesManName;

        public string SalesManName
        {
            get { return salesManName; }
            set { salesManName = value; }
        }

        private string salesManUserName;

        public string SalesManUserName
        {
            get { return salesManUserName; }
            set { salesManUserName = value; }
        }

        private string salesManPassword;

        public string SalesManPassword
        {
            get { return salesManPassword; }
            set { salesManPassword = value; }
        }

        private string salesManEmail;

        public string SalesManEmail
        {
            get { return salesManEmail; }
            set { salesManEmail = value; }
        }

        private string salesManMobile;

        public string SalesManMobile
        {
            get { return salesManMobile; }
            set { salesManMobile = value; }
        }


        private double salesManSalary;
        public double SalesManSalary
        {
            get { return salesManSalary; }
            set { salesManSalary = value; }
        }

        private double salesManBonus;
        public double SalesManBonus
        {
            get { return salesManBonus; }
            set { salesManBonus = value; }
        }



        public Sales()
        {
            salesManID = 0;
            salesManName = string.Empty;
            salesManUserName = string.Empty;
            salesManPassword = string.Empty;
            salesManEmail = string.Empty;
            salesManMobile = string.Empty;
        }
    }

    public class Address_Entities
    {
        private int _retailerID;
        private int _addressID;
        private string _line1;
        private string _line2;
        private string _city;
        private int _pincode;
        private string _state;
        private string _contactNo;

        public int RetailerID { get => _retailerID; set => _retailerID = value; }
        public int AddressID { get => _addressID; set => _addressID = value; }
        public string Line1 { get => _line1; set => _line1 = value; }
        public string Line2 { get => _line2; set => _line2 = value; }
        public string City { get => _city; set => _city = value; }
        public int Pincode { get => _pincode; set => _pincode = value; }
        public string State { get => _state; set => _state = value; }
        public string ContactNo { get => _contactNo; set => _contactNo = value; }
    }

}
