using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreatOutdoors.DataAccessLayer;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;
namespace GreatOutdoors.BusinessLayer
{
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
}
