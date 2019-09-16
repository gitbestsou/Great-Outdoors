using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreatOutdoorsSales.Entities;
using GreatOutdoorsSales.DataAccessLayer;
using GreatOutdoorsSales.Exceptions;
using GreatOutdoorsOrder.Entities;
using GreatOutdoorsOrder.BusinessLayer;


namespace GreatOutdoorsSales.BusinessLayer
{
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
}

