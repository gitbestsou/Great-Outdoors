using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;

namespace GreatOutdoors.DataAccessLayer
{
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
}
