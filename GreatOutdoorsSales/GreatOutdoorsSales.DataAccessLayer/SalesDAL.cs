using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GreatOutdoorsSales.Entities;
using GreatOutdoorsSales.Exceptions;

namespace GreatOutdoorsSales.DataAccessLayer
{
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
}