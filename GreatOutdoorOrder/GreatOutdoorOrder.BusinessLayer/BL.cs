﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoorsOrder.DataAccessLayer;
using GreatOutdoorsOrder.Entities;
using GreatOutdoorsOrder.Exception;

namespace GreatOutdoorsOrder.BusinessLayer
{
    public class Class1
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
}