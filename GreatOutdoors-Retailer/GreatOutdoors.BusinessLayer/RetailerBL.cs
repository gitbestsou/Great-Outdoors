using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.Entities;
using GreatOutdoors.DataAccessLayer;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.BusinessLayer
{
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
                    throw new GreatOutdoorsException("Invalid Guest ID");
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
}
