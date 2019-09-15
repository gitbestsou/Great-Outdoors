﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorsOrder.Entities
{
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
}