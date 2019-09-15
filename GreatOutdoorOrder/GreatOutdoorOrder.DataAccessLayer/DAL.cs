﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoorsOrder.Exception;
using GreatOutdoorsOrder.Entities;

namespace GreatOutdoorsOrder.DataAccessLayer
{
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
}
