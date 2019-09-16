﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GO.Entities;
using GO.Exceptions;
using GO.DAL;

namespace GO.BL
{
    public class ProductBL
    {
        private static bool ValidateProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;
            if (product.ProductID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Product ID");

            }
            if (product.ProductName == string.Empty)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Product Name Required");

            }
            if (product.CategoryID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Category ID");

            }

            if (product.SpecificationID <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Specification ID");

            }

            if (product.CostPrice <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Cost Price");

            }

            if (product.SellingPrice <= 0)
            {
                validProduct = false;
                sb.Append(Environment.NewLine + "Invalid Selling Price");

            }

            if (validProduct == false)
                throw new GreatOutdoorsProductException(sb.ToString());
            return validProduct;
        }

        public static bool AddProductBL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                if (ValidateProduct(newProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productAdded = productDAL.AddProductDAL(newProduct);
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productAdded;
        }

        public static List<Product> GetAllProductsBL()
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetAllProductsDAL();
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }

        public static List<Product> GetProductsByNameBL(string productName)
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetProductsByNameDAL(productName);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }

        public static List<Product> GetProductsByCategoryBL(int categoryID)
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetProductsByCategoryDAL(categoryID);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productList;
        }
        public static Product SearchProductBL(int searchProductID)
        {
            Product searchProduct = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                searchProduct = productDAL.SearchProductDAL(searchProductID);
            }
            catch (GreatOutdoorsProductException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchProduct;

        }



        public static bool UpdateProductBL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                if (ValidateProduct(updateProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productUpdated = productDAL.UpdateProductDAL(updateProduct);
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productUpdated;
        }

        public static bool DeleteProductBL(int deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                if (deleteProductID > 0)
                {
                    ProductDAL productDAL = new ProductDAL();
                    productDeleted = productDAL.DeleteProductDAL(deleteProductID);
                }
                else
                {
                    throw new GreatOutdoorsProductException("Invalid Product ID");
                }
            }
            catch (GreatOutdoorsProductException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productDeleted;
        }

    }

    public class RetailerBL
    {
        private static bool ValidateRetailer(Retailer retailer)
        {
            StringBuilder sb = new StringBuilder();
            bool validRetailer = true;
            if (retailer.RetailerID <= 0)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "Invalid Retailer ID");

            }
            if (retailer.UName == string.Empty)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "USer Name Required");

            }
            if (retailer.Password == string.Empty)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "Password Required");

            }
            if (retailer.RetailerName == string.Empty)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "Retailer Name Required");

            }
            if (retailer.Email == string.Empty)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "Email address Required");

            }
            if (retailer.RetailerContactNumber.Length < 10)
            {
                validRetailer = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validRetailer == false)
                throw new GreatOutdoorsException(sb.ToString());
            return validRetailer;
        }
        public static bool AddRetailerBL(Retailer newRetailer)
        {
            bool retailerAdded = false;
            try
            {
                if (ValidateRetailer(newRetailer))
                {
                    RetailerDAL guestDAL = new RetailerDAL();
                    retailerAdded = guestDAL.AddRetailerDAL(newRetailer);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retailerAdded;
        }
        public static List<Retailer> GetAllRetailersBL()
        {
            List<Retailer> retailerList = null;
            try
            {
                RetailerDAL retailerDAL = new RetailerDAL();
                retailerList = retailerDAL.GetAllRetailersDAL();
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retailerList;
        }

        public static Retailer SearchRetailerBL(int searchRetailerID)
        {
            Retailer searchRetailer = null;
            try
            {
                RetailerDAL retailerDAL = new RetailerDAL();
                searchRetailer = retailerDAL.SearchRetailerDAL(searchRetailerID);
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchRetailer;

        }



        public static bool UpdateRetailerBL(Retailer updateRetailer)
        {
            bool retailerUpdated = false;
            try
            {
                if (ValidateRetailer(updateRetailer))
                {
                    RetailerDAL retailerDAL = new RetailerDAL();
                    retailerUpdated = retailerDAL.UpdateRetailerDAL(updateRetailer);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retailerUpdated;
        }

        public static bool DeleteRetailerBL(int deleteRetailerID)
        {
            bool retailerDeleted = false;
            try
            {
                if (deleteRetailerID > 0)
                {
                    RetailerDAL retailerDAL = new RetailerDAL();
                    retailerDeleted = retailerDAL.DeleteRetailerDAL(deleteRetailerID);
                }
                else
                {
                    throw new GreatOutdoorsException("Invalid Retailer ID");
                }
            }
            catch (GreatOutdoorsException)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retailerDeleted;
        }

    }

    public class CategoryBL
    {
        private static bool ValidateCategory(Category category)
        {
            StringBuilder sb = new StringBuilder();
            bool validCategory = true;
            if (category.CategoryID <= 0)
            {
                validCategory = false;
                sb.Append(Environment.NewLine + "Invalid Category ID");

            }
            if (category.CategoryName == string.Empty)
            {
                validCategory = false;
                sb.Append(Environment.NewLine + "Category Name Required");

            }

            if (validCategory == false)
                throw new GreatOutdoorsException(sb.ToString());
            return validCategory;
        }

        public static bool AddGuestBL(Category newCategory)
        {
            bool categoryAdded = false;
            try
            {
                if (ValidateCategory(newCategory))
                {
                    CategoryDAL categoryDAL = new CategoryDAL();
                    categoryAdded = categoryDAL.AddCategoryDAL(newCategory);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return categoryAdded;
        }

        public static List<Category> GetAllCategoriesBL()
        {
            List<Category> categoryList = null;
            try
            {
                CategoryDAL categoryDAL = new CategoryDAL();
                categoryList = categoryDAL.GetAllCategoriesDAL();
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoryList;
        }

        public static Category SearchCategoryBL(int searchCategoryID)
        {
            Category searchCategory = null;
            try
            {
                CategoryDAL categoryDAL = new CategoryDAL();
                searchCategory = categoryDAL.SearchCategoryDAL(searchCategoryID);
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchCategory;

        }

        public static bool UpdateCategoryBL(Category updateCategory)
        {
            bool categoryUpdated = false;
            try
            {
                if (ValidateCategory(updateCategory))
                {
                    CategoryDAL categoryDAL = new CategoryDAL();
                    categoryUpdated = categoryDAL.UpdateCategoryDAL(updateCategory);
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return categoryUpdated;
        }

        public static bool DeleteCategoryBL(int deleteCategoryID)
        {
            bool categoryDeleted = false;
            try
            {
                if (deleteCategoryID > 0)
                {
                    CategoryDAL categoryDAL = new CategoryDAL();
                    categoryDeleted = categoryDAL.DeleteCategoryDAL(deleteCategoryID);
                }
                else
                {
                    throw new GreatOutdoorsException("Invalid Category ID");
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return categoryDeleted;
        }

    }

    public class Order
    {
        private static bool ValidateOrder(Order order)
        {
            StringBuilder sb = new StringBuilder();
            bool validOrder = true;
            if (order.OrderID <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Invalid Guest ID");


            }
            if (order.RetailerID <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.SalesmanID <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.ProductID <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.Quantity <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.SellingPrice <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.TotalAmount <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.AmountPayable <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.FinalDelieveryAddress == string.Empty)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.ChannelOfSale == string.Empty)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.Status == string.Empty)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }
            if (order.CategoryID <= 0)
            {
                validOrder = false;
                sb.Append(Environment.NewLine + "Guest Name Required");

            }


            if (validOrder == false)
                throw new OrderException(sb.ToString());
            return validOrder;
        }

        public static bool AddOrderBL(Order newOrder)
        {
            bool orderAdded = false;
            try
            {
                if (ValidateOrder(newOrder))
                {
                    OrderDAL guestDAL = new OrderDAL();
                    orderAdded = guestDAL.AddOrderDAL(newOrder);
                }
            }
            catch (OrderException)
            {
                throw;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }

            return orderAdded;
        }

        public static List<Order> GetAllOrdersBL()
        {
            List<Order> orderList = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                orderList = orderDAL.GetAllOrdersDAL();
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return orderList;
        }

        public static Order SearcOrderBL(int searchOrderID)
        {
            Order searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.SearchOrderDAL(searchOrderID);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderbyRetailerIDBL(int retailerID)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderByRetailerIDDAL(retailerID);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderByCategoryIDBL(int categoryID)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderByCategoryIDDAL(categoryID);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderBySalessmanIDBL(int salesmanID)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderBySalesmanIDDAL(salesmanID);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderByOfflineBL(string channelofsale)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderByOfflineDAL(channelofsale);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderForOfflineBL()
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderForOfflineSaleDAL();
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> SearcOrderByOnlineBL(string channelofsale)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderByOnlineDAL(channelofsale);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static List<Order> GetOrderByStatusBL(string status)
        {
            List<Order> searchOrder = null;
            try
            {
                OrderDAL orderDAL = new OrderDAL();
                searchOrder = orderDAL.GetOrderByStatusDAL(status);
            }
            catch (OrderException ex)
            {
                throw ex;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return searchOrder;

        }


        public static bool UpdateOrderBL(Order updateOrder)
        {
            bool orderUpdated = false;
            try
            {
                if (ValidateOrder(updateOrder))
                {
                    OrderDAL orderDAL = new OrderDAL();
                    orderUpdated = orderDAL.UpdateOrderDAL(updateOrder);
                }
            }
            catch (OrderException)
            {
                throw;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }

            return orderUpdated;
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

    public class Return_BL
    {
        private static bool ValidateReturn(Return returnobj)
        {
            StringBuilder sb = new StringBuilder();
            bool validReturn = true;
            if (returnobj.ReturnID <= 0)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid Return ID");

            }
            if (returnobj.OrderID <= 0)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid Order ID");

            }
            if (returnobj.ProductID <= 0)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid Product ID");

            }
            if (returnobj.ReasonIncomplete == null)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid IncompleteOrder status");
            }
            if (returnobj.ReasonWrong == null)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid WrongOrder status");
            }

            if (returnobj.ReturnValue <= 0)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid Return Value");
            }
            if (returnobj.ReturnQuantity <= 0)
            {
                validReturn = false;
                sb.Append(Environment.NewLine + "Invalid Return Quantity");

            }


            if (validReturn == false)
                throw new ReturnExceptions(sb.ToString());
            return validReturn;
        }

        public static bool AddReturnBL(Return newReturn)
        {
            bool returnAdded = false;
            try
            {
                if (ValidateReturn(newReturn))
                {
                    Return_DAL returnDAL = new Return_DAL();
                    returnAdded = returnDAL.AddReturnDAL(newReturn);
                }
            }
            catch (ReturnExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnAdded;
        }

        public static List<Return> GetAllReturnsBL()
        {
            List<Return> returnList = null;
            try
            {
                Return_DAL returnDAL = new Return_DAL();
                returnList = returnDAL.GetAllReturnsDAL();
            }
            catch (ReturnExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnList;
        }

        public static Return SearchReturnBL(int searchReturnID)
        {
            Return searchReturn = null;
            try
            {
                Return_DAL returnDAL = new Return_DAL();
                searchReturn = returnDAL.SearchReturnDAL(searchReturnID);
            }
            catch (ReturnExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchReturn;

        }

        public static bool UpdateReturnBL(Return updateReturn)
        {
            bool returnUpdated = false;
            try
            {
                if (ValidateReturn(updateReturn))
                {
                    Return_DAL returnDAL = new Return_DAL();
                    returnUpdated = returnDAL.UpdateReturnDAL(updateReturn);
                }
            }
            catch (ReturnExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnUpdated;
        }

        public static bool DeleteReturnBL(int deleteReturnID)
        {
            bool returnDeleted = false;
            try
            {
                if (deleteReturnID > 0)
                {
                    Return_DAL returnDAL = new Return_DAL();
                    returnDeleted = returnDAL.DeleteReturnDAL(deleteReturnID);
                }
                else
                {
                    throw new ReturnExceptions("Invalid Return ID");
                }
            }
            catch (ReturnExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnDeleted;
        }

        public void OrderForReturn()
        {
            //The order which should be implemented for the corresponding return
        }
        public void TrackReturn()
        {
            //To track return
        }
        public void DeductMoneyFromRevenue()
        {
            //To change the revenue data due to return process
        }
        public void CancelOrder()
        {
            //To cancel online order
        }



    }
    class Specification_BL
    {
        private static bool ValidateSpecification(Specification specification)
        {
            StringBuilder sb = new StringBuilder();
            bool validSpecification = true;
            if (specification.SpecificationID <= 0)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Specification ID");

            }

            if (specification.Color == null)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Color Specification");

            }

            if (specification.Size <= 0)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Specification Value");
            }
            if (specification.Techspec == null)
            {
                validSpecification = false;
                sb.Append(Environment.NewLine + "Invalid Technical Specification");

            }


            if (validSpecification == false)
                throw new SpecificationExceptions(sb.ToString());
            return validSpecification;
        }

        public static bool AddSpecificationBL(Specification newSpecification)
        {
            bool specificationAdded = false;
            try
            {
                if (ValidateSpecification(newSpecification))
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationAdded = specificationDAL.AddSpecificationDAL(newSpecification);
                }
            }
            catch (SpecificationExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return specificationAdded;
        }

        public static List<Specification> GetAllSpecificationsBL()
        {
            List<Specification> specificationList = null;
            try
            {
                Specification_DAL specificationDAL = new Specification_DAL();
                specificationList = specificationDAL.GetAllSpecificationsDAL();
            }
            catch (SpecificationExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return specificationList;
        }

        public static Specification SearchSpecificationBL(int searchSpecificationID)
        {
            Specification searchSpecification = null;
            try
            {
                Specification_DAL specificationDAL = new Specification_DAL();
                searchSpecification = specificationDAL.SearchSpecificationDAL(searchSpecificationID);
            }
            catch (SpecificationExceptions ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchSpecification;

        }

        public static bool UpdateSpecificationBL(Specification updateSpecification)
        {
            bool specificationUpdated = false;
            try
            {
                if (ValidateSpecification(updateSpecification))
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationUpdated = specificationDAL.UpdateSpecificationDAL(updateSpecification);
                }
            }
            catch (SpecificationExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return specificationUpdated;
        }

        public static bool DeleteSpecificationBL(int deleteSpecificationID)
        {
            bool specificationDeleted = false;
            try
            {
                if (deleteSpecificationID > 0)
                {
                    Specification_DAL specificationDAL = new Specification_DAL();
                    specificationDeleted = specificationDAL.DeleteSpecificationDAL(deleteSpecificationID);
                }
                else
                {
                    throw new SpecificationExceptions("Invalid Specification ID");
                }
            }
            catch (SpecificationExceptions)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return specificationDeleted;
        }


    }

    public class Discount_BL
    {
        private static bool ValidateDiscount(Discount_Entities discount)
        {
            StringBuilder sb = new StringBuilder();
            bool validDiscount = true;
            if (discount.OrderID == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "OrderID Required");

            }
            if (discount.RetailerID == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "RetailerID Required");

            }
            if (discount.CategoryDiscount == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "Category Discount Required");
            }
            if (discount.RetailerDiscount == 0)
            {
                validDiscount = false;
                sb.Append(Environment.NewLine + "Retailer Discount Required");
            }
            if (validDiscount == false)
                throw new Discount_Exception(sb.ToString());
            return validDiscount;
        }

        public static bool AddDiscountBL(Discount_Entities newDiscount)
        {
            bool DiscountAdded = false;
            try
            {
                if (ValidateDiscount(newDiscount))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    DiscountAdded = discountDAL.AddDiscountDAL(newDiscount);
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return DiscountAdded;
        }

        public static List<Discount_Entities> GetAllDiscountBL()
        {
            List<Discount_Entities> discountList = null;
            try
            {
                Discount_DAL discountDAL = new Discount_DAL();
                discountList = discountDAL.GetAllDiscountDAL();
            }
            catch (Discount_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return discountList;
        }

        public static Discount_Entities SearchDiscountBL(int searchRetailerID, int searchOrderID)
        {
            Discount_Entities searchDiscount = null;
            try
            {
                Discount_DAL discountDAL = new Discount_DAL();
                searchDiscount = discountDAL.SearchDiscountDAL(searchRetailerID, searchOrderID);
            }
            catch (Discount_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchDiscount;

        }

        public static bool UpdateDiscountBL(Discount_Entities updateDiscount)
        {
            bool discountUpdated = false;
            try
            {
                if (ValidateDiscount(updateDiscount))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    discountUpdated = discountDAL.UpdatedDiscountDAL(updateDiscount);
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return discountUpdated;
        }

        public static bool DeleteDiscountBL(int deleteRetailerID, int deleteOrderID)
        {
            bool discountDeleted = false;
            try
            {
                if ((deleteOrderID > 0) && (deleteRetailerID > 0))
                {
                    Discount_DAL discountDAL = new Discount_DAL();
                    discountDeleted = discountDAL.DeleteDiscountDAL(deleteRetailerID, deleteOrderID);
                }
                else
                {
                    throw new Discount_Exception("Invalid Order ID and Retailer ID");
                }
            }
            catch (Discount_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return discountDeleted;
        }
    }

    public class SalesBL
    {
        private static bool ValidateSalesMan(Sales salesman)
        {
            StringBuilder sb = new StringBuilder();
            bool validSalesMan = true;
            if (salesman.SalesManID <= 0)
            {
                validSalesMan = false;
                sb.Append(Environment.NewLine + "Invalid Sales Man ID");

            }
            if (salesman.SalesManName == string.Empty)
            {
                validSalesMan = false;
                sb.Append(Environment.NewLine + "Sales Man name required");


            }
            if (salesman.SalesManMobile.Length < 10)
            {
                validSalesMan = false;
                sb.Append(Environment.NewLine + "Required 10 Digit Contact Number");
            }
            if (validSalesMan == false)
                throw new GreatOutdoorsSalesException(sb.ToString());
            return validSalesMan;
        }

        public static int AddSalesOrderBL(Order newOrder)
        {
            int salesOrderID = 0;
            try
            {
                if (OrderBL.AddOrderBL(newOrder))
                {
                    salesOrderID = newOrder.OrderID;
                }
            }
            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }

            return salesOrderID;
        }
        public static bool AddSalesBL(int saleOrderID)
        {
            bool saleAdded = false;
            try
            {
                if (saleOrderID >= 0)
                {
                    SalesDAL salesmanDAL = new SalesDAL();
                    saleAdded = salesmanDAL.AddSalesDAL(saleOrderID);
                }
            }
            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return saleAdded;
        }


        public static List<Order> GetAllSalesBL()
        {
            List<Order> salesList = null;
            try
            {
                foreach (int item in SalesDAL.salesIDs)
                {
                    salesList.Add(OrderBL.SearchOrderBL(item));

                }
            }
            catch (GreatOutdoorsSalesException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salesList;
        }

        public static Order SearchSalesOrderBL(int searchSalesID)
        {
            Order searchOrder = null;
            try
            {
                SalesDAL salesDAL = new SalesDAL();
                searchOrder = OrderBL.SearchOrderBL(salesDAL.SearchSalesDAL(searchSalesID));
            }
            catch (GreatOutdoorsSalesException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchOrder;

        }

        public static bool UpdateSalesManBL(Sales updateSalesMan)
        {
            bool salesManUpdated = false;
            try
            {
                if (ValidateSalesMan(updateSalesMan))
                {
                    SalesDAL salesManDAL = new SalesDAL();
                    salesManUpdated = salesManDAL.UpdateSalesManDetailsDAL(updateSalesMan);
                }
            }
            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return salesManUpdated;
        }

        public static List<Order> ViewActiveOrdersBL()
        {
            List<Order> activeOrders = null;

            try
            {
                activeOrders = OrderBL.GetOrderForOfflineSaleBL();
            }

            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return activeOrders;
        }

        public static bool AcceptOrderSalesBL(int activeOrderID)
        {

            bool orderAccepted = false;
            try
            {
                foreach (Order item in OrderBL.GetOrderForOfflineSaleBL())
                {
                    if (item.OrderID == activeOrderID)
                    {
                        item.Status = "Under Processing";
                        orderAccepted = OrderBL.UpdateOrderBL(item);
                    }
                }
            }

            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orderAccepted;

        }

        public static bool ModifyOrderSalesBL(Order updatedOrder)
        {
            bool orderModified = false;
            try
            {
                foreach (Order item in OrderBL.GetOrderForOfflineSaleBL())
                {
                    if (item.OrderID == updatedOrder.OrderID)
                    {

                        orderModified = OrderBL.UpdateOrderBL(updatedOrder);
                    }
                }
            }

            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orderModified;
        }




        public static int ConfirmOrderSalesBL(int confirmOrderID)
        {
            int confirmedOrderID = 0;
            try
            {
                foreach (Order item in OrderBL.GetOrderForOfflineSaleBL())
                {
                    if (item.OrderID == confirmOrderID)
                    {
                        item.Status = "Delivered";
                        if (OrderBL.UpdateOrderBL(item))
                            confirmedOrderID = item.OrderID;
                    }
                }
            }

            catch (GreatOutdoorsSalesException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return confirmedOrderID;
        }

    }

    public class Address_BL
    {
        private static bool ValidateAddress(Address_Entities address)
        {
            StringBuilder sb = new StringBuilder();
            bool validAddress = true;
            if (address.Line1 == string.Empty)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Address Line1 Required");

            }
            if (address.Line2 == string.Empty)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Address Line2 Required");

            }
            if (address.ContactNo.Length != 10 || address.ContactNo.Length != 7)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Required 7 or 10 Digit Contact Number");
            }
            if (address.City == null)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "City Name Required");
            }
            if (address.Pincode.ToString().Length != 6)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "Invalid Pincode");
            }
            if (address.State == null)
            {
                validAddress = false;
                sb.Append(Environment.NewLine + "State Name Required");
            }
            if (validAddress == false)
                throw new AddressException(sb.ToString());
            return validAddress;
        }

        public static bool AddAddressBL(Address_Entities newAddress)
        {
            bool AddressAdded = false;
            try
            {
                if (ValidateAddress(newAddress))
                {
                    Address_DAL addressDAL = new Address_DAL();
                    AddressAdded = addressDAL.AddAddressDAL(newAddress);
                }
            }
            catch (AddressException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AddressAdded;
        }

        public static List<Address_Entities> GetAllAddressBL()
        {
            List<Address_Entities> addressList = null;
            try
            {
                Address_DAL addressDAL = new Address_DAL();
                addressList = addressDAL.GetAllAddressDAL();
            }
            catch (AddressException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return addressList;
        }

        public static Address_Entities SearchAddressBL(int searchAddressID)
        {
            Address_Entities searchAddress = null;
            try
            {
                Address_DAL addressDAL = new Address_DAL();
                searchAddress = addressDAL.SearchAddressDAL(searchAddressID);
            }
            catch (AddressException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchAddress;

        }

        public static bool UpdateAddressBL(Address_Entities updateAddress)
        {
            bool addressUpdated = false;
            try
            {
                if (ValidateAddress(updateAddress))
                {
                    Address_DAL addressDAL = new Address_DAL();
                    addressUpdated = addressDAL.UpdateAddressDAL(updateAddress);
                }
            }
            catch (AddressException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addressUpdated;
        }

        public static bool DeleteAddesstBL(int deleteAddressID)
        {
            bool addressDeleted = false;
            try
            {
                if (deleteAddressID > 0)
                {
                    Address_DAL addressDAL = new Address_DAL();
                    addressDeleted = addressDAL.DeleteAddressDAL(deleteAddressID);
                }
                else
                {
                    throw new AddressException("Invalid Guest ID");
                }
            }
            catch (AddressException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addressDeleted;
        }
    }
}
