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
                        updateCategory.ProductID= categoryList[i].ProductID;
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
}
