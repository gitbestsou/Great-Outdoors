﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using GO.Entities;
using static GO.Exceptions.Exceptions;

namespace GO.DAL
{
    public class ProductDAL
    {
        public static List<Product> productList = new List<Product>();

        public bool AddProductDAL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                productList.Add(newProduct);
                productAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return productAdded;

        }

        public List<Product> GetAllProductsDAL()
        {
            return productList;
        }

        public Product SearchProductDAL(int searchProductID)
        {
            Product searchProduct = null;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductID == searchProductID)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return searchProduct;
        }

        public List<Product> GetProductsByNameDAL(string productName)
        {
            List<Product> searchProduct = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductName == productName)
                    {
                        searchProduct.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return searchProduct;
        }

        public List<Product> GetProductsByCategoryDAL(int categoryID)
        {
            List<Product> searchProduct = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.CategoryID == categoryID)
                    {
                        searchProduct.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return searchProduct;
        }

        public bool UpdateProductDAL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                for (int i = 0; i < productList.Count; i++)
                {
                    if (productList[i].ProductID == updateProduct.ProductID)
                    {
                        updateProduct.ProductName = productList[i].ProductName;
                        updateProduct.CategoryID = productList[i].CategoryID;
                        updateProduct.SpecificationID = productList[i].SpecificationID;
                        updateProduct.CostPrice = productList[i].CostPrice;
                        updateProduct.SellingPrice = productList[i].SellingPrice;
                        updateProduct.Available = productList[i].Available;
                        productUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return productUpdated;

        }

        public bool DeleteProductDAL(int deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                Product deleteProduct = null;
                foreach (Product item in productList)
                {
                    if (item.ProductID == deleteProductID)
                    {
                        deleteProduct = item;
                    }
                }

                if (deleteProduct != null)
                {
                    productList.Remove(deleteProduct);
                    productDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GOException(ex.Message);
            }
            return productDeleted;

        }

    }
    public class RetailerDAL
    {
        public static List<Retailer> retailerList = new List<Retailer>();

        public bool AddRetailerDAL(Retailer newRetailer)
        {
            bool retailerAdded = false;
            try
            {
                retailerList.Add(newRetailer);
                retailerAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return retailerAdded;

        }

        public List<Retailer> GetAllRetailersDAL()
        {
            return retailerList;
        }

        public Retailer SearchRetailerDAL(int searchRetailerID)
        {
            Retailer searchRetailer = null;
            try
            {
                foreach (Retailer item in retailerList)
                {
                    if (item.RetailerID == searchRetailerID)
                    {
                        searchRetailer = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return searchRetailer;
        }

        public List<Retailer> GetRetailerByNameDAL(string retailerName)
        {
            List<Retailer> searchRetailer = new List<Retailer>();
            try
            {
                foreach (Retailer item in retailerList)
                {
                    if (item.RetailerName == retailerName)
                    {
                        searchRetailer.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return searchRetailer;
        }


        public bool UpdateRetailerDAL(Retailer updateRetailer)
        {
            bool retailerUpdated = false;
            try
            {
                for (int i = 0; i < retailerList.Count; i++)
                {
                    if (retailerList[i].RetailerID == updateRetailer.RetailerID)
                    {
                        updateRetailer.RetailerName = retailerList[i].RetailerName;
                        updateRetailer.RetailerContactNumber = retailerList[i].RetailerContactNumber;
                        retailerUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GOException(ex.Message);
            }
            return retailerUpdated;

        }
        public bool DeleteRetailerDAL(int deleteRetailerID)
        {
            bool retailerDeleted = false;
            try
            {
                Retailer deleteRetailer = null;
                foreach (Retailer item in retailerList)
                {
                    if (item.RetailerID == deleteRetailerID)
                    {
                        deleteRetailer = item;
                    }
                }

                if (deleteRetailer != null)
                {
                    retailerList.Remove(deleteRetailer);
                    retailerDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GOException(ex.Message);
            }
            return retailerDeleted;

        }
    }

    public class CategoryDAL
    {

        public static List<Category> categoryList = new List<Category>();

        public bool AddCategoryDAL(Category newCategory)
        {
            bool categoryAdded = false;
            try
            {
                categoryList.Add(newCategory);
                categoryAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return categoryAdded;

        }


        public List<Category> GetAllCategoriesDAL()
        {
            return categoryList;
        }

        public Category SearchCategoryDAL(int searchCategoryID)
        {
            Category searchCategory = null;
            try
            {
                foreach (Category item in categoryList)
                {
                    if (item.CategoryID == searchCategoryID)
                    {
                        searchCategory = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchCategory;
        }
        public List<Category> GetCategoriesByNameDAL(string categoryName)
        {
            List<Category> searchCategory = new List<Category>();
            try
            {
                foreach (Category item in categoryList)
                {
                    if (item.CategoryName == categoryName)
                    {
                        searchCategory.Add(item);
                    }
                }

            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return searchCategory;
        }

        public bool UpdateCategoryDAL(Category updateCategory)
        {
            bool categoryUpdated = false;
            try
            {
                for (int i = 0; i < categoryList.Count; i++)
                {
                    if (categoryList[i].CategoryID == updateCategory.CategoryID)
                    {
                        updateCategory.CategoryName = categoryList[i].CategoryName;
                        updateCategory.ProductID = categoryList[i].ProductID;
                        categoryUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return categoryUpdated;

        }
        public bool DeleteCategoryDAL(int deleteCategoryID)
        {
            bool categoryDeleted = false;
            try
            {
                Category deleteCategory = null;
                foreach (Category item in categoryList)
                {
                    if (item.CategoryID == deleteCategoryID)
                    {
                        deleteCategory = item;
                    }
                }

                if (deleteCategory != null)
                {
                    categoryList.Remove(deleteCategory);
                    categoryDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GreatOutdoorsException(ex.Message);
            }
            return categoryDeleted;

        }

    }

    public class OrderDAL
    {
        public static List<Order> orderList = new List<Order>();

        public bool AddOrderDAL(Order newOrder)
        {
            bool orderAdded = false;
            try
            {
                orderList.Add(newOrder);
                orderAdded = true;
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return orderAdded;

        }

        public List<Order> GetAllOrdersDAL()
        {
            return orderList;
        }

        public Order SearchOrderDAL(int searchOrderID)
        {
            Order searchOrder = null;
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.OrderID == searchOrderID)
                    {
                        searchOrder = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderByRetailerIDDAL(int RetailerID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.RetailerID == RetailerID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderByCategoryIDDAL(int categoryID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.CategoryID == categoryID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderBySalesmanIDDAL(int salesmanID)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.SalesmanID == salesmanID)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderByOfflineDAL(string ChannelOfSale)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Offline")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderForOfflineSaleDAL()
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Offline" && item.Status == "In Cart")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderByOnlineDAL(string ChannelOfSale)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.ChannelOfSale == "Online")
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }

        public List<Order> GetOrderByStatusDAL(string CurrentStatus)
        {
            List<Order> searchOrder = new List<Order>();
            try
            {
                foreach (Order item in orderList)
                {
                    if (item.Status == CurrentStatus)
                    {
                        searchOrder.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return searchOrder;
        }


        public bool UpdateOrderDAL(Order updateOrder)
        {
            bool OrderUpdated = false;
            try
            {
                for (int i = 0; i < orderList.Count; i++)
                {
                    if (orderList[i].OrderID == updateOrder.OrderID)
                    {
                        updateOrder.Status = orderList[i].Status;

                        OrderUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new OrderException(ex.Message);
            }
            return OrderUpdated;

        }


    }


    public class InventoryDAL
    {
        public static List<Inventory> inventory = new List<Inventory>();

        public bool AddToInventoryDAL(Inventory newProduct)
        {
            bool productAdded = false;
            try
            {
                inventory.Add(newProduct);
                productAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return productAdded;

        }

        public List<Inventory> GetInventoryDAL()
        {
            return inventory;
        }

        public Inventory SearchInventoryDAL(int searchProductID)
        {
            Inventory searchProduct = null;
            try
            {
                foreach (Inventory item in inventory)
                {
                    if (item.ProductID == searchProductID)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return searchProduct;
        }

        public bool UpdateInventoryDAL(Inventory updateProduct)
        {
            bool productUpdated = false;
            try
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].ProductID == updateProduct.ProductID)
                    {
                        updateProduct.ProductQuantity = inventory[i].ProductQuantity;
                        updateProduct.CostPrice = inventory[i].CostPrice;
                        productUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return productUpdated;

        }

        public bool DeleteProductDAL(int deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                Inventory deleteProduct = null;
                foreach (Inventory item in inventory)
                {
                    if (item.ProductID == deleteProductID)
                    {
                        deleteProduct = item;
                    }
                }

                if (deleteProduct != null)
                {
                    inventory.Remove(deleteProduct);
                    productDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return productDeleted;

        }

    }

    public class Return_DAL
    {
        public static List<Return> returnList = new List<Return>();

        public bool AddReturnDAL(Return newReturn)
        {
            bool returnAdded = false;
            try
            {
                returnList.Add(newReturn);
                returnAdded = true;
            }
            catch (SystemException ex)
            {
                throw new ReturnExceptions(ex.Message);
            }
            return returnAdded;

        }

        public List<Return> GetAllReturnsDAL()
        {
            return returnList;
        }

        public Return SearchReturnDAL(int searchReturnID)
        {
            Return searchReturn = null;
            try
            {
                foreach (Return item in returnList)
                {
                    if (item.ReturnID == searchReturnID)
                    {
                        searchReturn = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new ReturnExceptions(ex.Message);
            }
            return searchReturn;
        }


        public bool UpdateReturnDAL(Return updateReturn)
        {
            bool returnUpdated = false;
            try
            {
                for (int i = 0; i < returnList.Count; i++)
                {
                    if (returnList[i].ReturnID == updateReturn.ReturnID)
                    {
                        updateReturn.OrderID = returnList[i].OrderID;
                        updateReturn.ProductID = returnList[i].ProductID;
                        updateReturn.ReasonIncomplete = returnList[i].ReasonIncomplete;
                        updateReturn.ReasonWrong = returnList[i].ReasonWrong;
                        updateReturn.ReturnValue = returnList[i].ReturnValue;
                        updateReturn.ReturnQuantity = returnList[i].ReturnQuantity;
                        returnUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new ReturnExceptions(ex.Message);
            }
            return returnUpdated;

        }

        public bool DeleteReturnDAL(int deleteReturnID)
        {
            bool returnDeleted = false;
            try
            {
                Return deleteReturn = null;
                foreach (Return item in returnList)
                {
                    if (item.ReturnID == deleteReturnID)
                    {
                        deleteReturn = item;
                    }
                }

                if (deleteReturn != null)
                {
                    returnList.Remove(deleteReturn);
                    returnDeleted = true;
                }
            }
            catch (DbException ex)
            {
                throw new ReturnExceptions(ex.Message);
            }
            return returnDeleted;

        }


    }

    public class Specification_DAL
    {
        public static List<Specification> specificationList = new List<Specification>();

        public bool AddSpecificationDAL(Specification newSpecification)
        {
            bool specificationAdded = false;
            try
            {
                specificationList.Add(newSpecification);
                specificationAdded = true;
            }
            catch (SystemException ex)
            {
                throw new SpecificationExceptions(ex.Message);
            }
            return specificationAdded;

        }

        public List<Specification> GetAllSpecificationsDAL()
        {
            return specificationList;
        }

        public Specification SearchSpecificationDAL(int searchSpecificationID)
        {
            Specification searchSpecification = null;
            try
            {
                foreach (Specification item in specificationList)
                {
                    if (item.SpecificationID == searchSpecificationID)
                    {
                        searchSpecification = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new SpecificationExceptions(ex.Message);
            }
            return searchSpecification;
        }


        public bool UpdateSpecificationDAL(Specification updateSpecification)
        {
            bool specificationUpdated = false;
            try
            {
                for (int i = 0; i < specificationList.Count; i++)
                {
                    if (specificationList[i].SpecificationID == updateSpecification.SpecificationID)
                    {
                        updateSpecification.ProductID = specificationList[i].ProductID;
                        updateSpecification.Color = specificationList[i].Color;
                        updateSpecification.Size = specificationList[i].Size;
                        updateSpecification.Techspec = specificationList[i].Techspec;
                        specificationUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new SpecificationExceptions(ex.Message);
            }
            return specificationUpdated;

        }

        public bool DeleteSpecificationDAL(int deleteSpecificationID)
        {
            bool specificationDeleted = false;
            try
            {
                Specification deleteSpecification = null;
                foreach (Specification item in specificationList)
                {
                    if (item.SpecificationID == deleteSpecificationID)
                    {
                        deleteSpecification = item;
                    }
                }

                if (deleteSpecification != null)
                {
                    specificationList.Remove(deleteSpecification);
                    specificationDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new SpecificationExceptions(ex.Message);
            }
            return specificationDeleted;

        }

    }

    public class Discount_DAL
    {
        public static List<Discount_Entities> discountList = new List<Discount_Entities>();

        public bool AddDiscountDAL(Discount_Entities discount)
        {
            bool discountAdded;
            try
            {
                discountList.Add(discount);
                discountAdded = true;
            }
            catch (SystemException ex)
            {
                throw new Discount_Exception(ex.Message);
            }
            return discountAdded;

        }

        public List<Discount_Entities> GetAllDiscountDAL()
        {
            return discountList;
        }

        public Discount_Entities SearchDiscountDAL(int searchRetailerID, int searchOrderID)
        {
            Discount_Entities searchDiscount = null;
            try
            {
                foreach (Discount_Entities discount in discountList)
                {
                    if ((discount.OrderID == searchOrderID) && (discount.RetailerID == searchRetailerID))
                    {
                        searchDiscount = discount;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Discount_Exception(ex.Message);
            }
            return searchDiscount;
        }

        public bool UpdatedDiscountDAL(Discount_Entities updateDiscount)
        {
            bool DiscountUpdated = false;
            try
            {
                for (int i = 0; i < discountList.Count; i++)
                {
                    if ((discountList[i].RetailerID == updateDiscount.RetailerID) && (discountList[i].OrderID == updateDiscount.OrderID))
                    {
                        discountList[i].RetailerDiscount = updateDiscount.RetailerDiscount;
                        discountList[i].CategoryDiscount = updateDiscount.CategoryDiscount;
                        DiscountUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new Discount_Exception(ex.Message);
            }
            return DiscountUpdated;

        }

        public bool DeleteDiscountDAL(int deleteRetailerID, int deleteOrderID)
        {
            bool discountDeleted = false;
            try
            {
                Discount_Entities deleteDiscount = null;
                foreach (Discount_Entities item in discountList)
                {
                    if ((item.OrderID == deleteOrderID) && (item.RetailerID == deleteRetailerID))
                    {
                        deleteDiscount = item;
                    }
                }

                if (deleteDiscount != null)
                {
                    discountList.Remove(deleteDiscount);
                    discountDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new Discount_Exception(ex.Message);
            }
            return discountDeleted;

        }

    }

    public class SalesDAL
    {
        public static List<int> salesIDs = new List<int>();
        Sales salesman = new Sales();

        public bool AddSalesDAL(int saleOrderID)
        {
            bool saleAdded = false;
            try
            {
                salesIDs.Add(saleOrderID);
                saleAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsSalesException(ex.Message);
            }
            return saleAdded;

        }

        public List<int> GetSalesDAL()
        {
            return salesIDs;
        }

        public int SearchSalesDAL(int searchSalesID)
        {
            int searchSales = 0;
            try
            {
                foreach (int item in salesIDs)
                {
                    if (item == searchSalesID)
                    {
                        searchSales = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsSalesException(ex.Message);
            }
            return searchSales;
        }

        public bool UpdateSalesManDetailsDAL(Sales updateSalesMan)
        {
            bool salesManUpdated = false;
            try
            {
                updateSalesMan.SalesManName = salesman.SalesManName;
                updateSalesMan.SalesManMobile = salesman.SalesManMobile;
                updateSalesMan.SalesManEmail = salesman.SalesManEmail;
                salesManUpdated = true;

            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsSalesException(ex.Message);
            }
            return salesManUpdated;

        }


    }

    public class Address_DAL
    {
        public static List<Address_Entities> addressList = new List<Address_Entities>();

        public bool AddAddressDAL(Address_Entities address)
        {
            bool addressAdded;
            try
            {
                addressList.Add(address);
                addressAdded = true;
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return addressAdded;

        }

        public List<Address_Entities> GetAllAddressDAL()
        {
            return addressList;
        }

        public Address_Entities SearchAddressDAL(int searchAddressID)
        {
            Address_Entities searchAddress = null;
            try
            {
                foreach (Address_Entities address in addressList)
                {
                    if (address.AddressID == searchAddressID)
                    {
                        searchAddress = address;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return searchAddress;
        }

        public bool UpdateAddressDAL(Address_Entities updateAddress)
        {
            bool AddressUpdated = false;
            try
            {
                for (int i = 0; i < addressList.Count; i++)
                {
                    if (addressList[i].AddressID == updateAddress.AddressID)
                    {
                        addressList[i].Line1 = updateAddress.Line1;
                        addressList[i].Line2 = updateAddress.Line2;
                        addressList[i].City = updateAddress.City;
                        addressList[i].Pincode = updateAddress.Pincode;
                        addressList[i].State = updateAddress.State;
                        addressList[i].ContactNo = updateAddress.ContactNo;
                        AddressUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new AddressException(ex.Message);
            }
            return AddressUpdated;

        }

        public bool DeleteAddressDAL(int deleteAddressID)
        {
            bool addressDeleted = false;
            try
            {
                Address_Entities deleteAddress = null;
                foreach (Address_Entities item in addressList)
                {
                    if (item.AddressID == deleteAddressID)
                    {
                        deleteAddress = item;
                    }
                }

                if (deleteAddress != null)
                {
                    addressList.Remove(deleteAddress);
                    addressDeleted = true;
                }
            }
            catch (Exception ex)
            {
                throw new AddressException(ex.Message);
            }
            return addressDeleted;

        }

    }
}
