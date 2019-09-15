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
}
