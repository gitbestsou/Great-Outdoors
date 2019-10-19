using System;
using System.Collections.Generic;
using Capgemini.GreatOutdoors.Contracts.DALContracts;
using Capgemini.GreatOutdoors.Entities;
using Capgemini.GreatOutdoors.Exceptions;
using Capgemini.GreatOutdoors.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace Capgemini.GreatOutdoors.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting products from Products collection.
    /// </summary>
    public class ProductDAL : ProductDALBase, IDisposable
    {

        SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.dbCon);

        /// <summary>
        /// Adds new product to Products collection.
        /// </summary>
        /// <param name="newProduct">Contains the product details to be added.</param>
        /// <returns>Determinates whether the new product is added.</returns>
        public override bool AddProductDAL(Product newProduct)
        {
            bool productAdded = false;
         
            try
            {
                sqlConn.Open();
                newProduct.ProductID = Guid.NewGuid();
                string procName = "[13th Aug CLoud PT Immersive].TeamA.AddProduct";
                SqlCommand cmd = new SqlCommand(procName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prodid", newProduct.ProductID);
                cmd.Parameters.AddWithValue("@prodname", newProduct.ProductName);
                cmd.Parameters.AddWithValue("@category", newProduct.CategoryName.ToString());
                cmd.Parameters.AddWithValue("@stock", newProduct.ProductStock);
                cmd.Parameters.AddWithValue("@size", newProduct.ProductSize);
                cmd.Parameters.AddWithValue("@colour", newProduct.ProductColour);
                cmd.Parameters.AddWithValue("@techspecs", newProduct.ProductTechSpecs);
                cmd.Parameters.AddWithValue("@cprice", newProduct.CostPrice);
                cmd.Parameters.AddWithValue("@sprice", newProduct.SellingPrice);
                cmd.Parameters.AddWithValue("@discount", newProduct.DiscountPercentage);

                int rows = cmd.ExecuteNonQuery();

                if( rows == 1)
                    productAdded = true;
                sqlConn.Close();
            }
            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }
            return productAdded;
        }

        /// <summary>
        /// Gets all products from the collection.
        /// </summary>
        /// <returns>Returns list of all products.</returns>
        public override List<Product> GetAllProductsDAL()
        {
            List<Product> products = new List<Product>();
            
            try
            {
                sqlConn.Open();

                string procName = "TeamA.GetAllProducts";
                SqlCommand cmd = new SqlCommand(procName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                DataSet dtSet = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                
                adp.Fill(dtSet);
                

                for( int i = 0; i < dtSet.Tables[0].Rows.Count; i++)
                {
                    DataRow row = dtSet.Tables[0].Rows[i];
                    Product product = new Product();
                    product.ProductID = (Guid)row["ProductID"];
                    product.ProductName = Convert.ToString(row["Name"]);
                    Enum.TryParse(Convert.ToString(row["Category"]), out Category category);
                    product.CategoryName = category;
                    product.ProductStock = Convert.ToInt32(row["Stock"]);
                    product.ProductSize = Convert.ToString(row["Size"]);
                    product.ProductColour = Convert.ToString(row["Colour"]);
                    product.ProductTechSpecs = Convert.ToString(row["TechnicalSpecifications"]);
                    product.CostPrice = Convert.ToDouble(row["CostPrice"]);
                    product.SellingPrice = Convert.ToDouble(row["SellingPrice"]);
                    product.DiscountPercentage = Convert.ToDouble(row["DiscountPercentage"]);


                    products.Add(product);

                }

                sqlConn.Close();
            }

            catch (GreatOutdoorsException ex)
            {
                throw ex;
            }

            return products;
        }

        /// <summary>
        /// Gets product based on ProductID.
        /// </summary>
        /// <param name="searchProductID">Represents ProductID to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByProductIDDAL(Guid searchProductID)
        {
            Product matchingProduct = new Product();
            try
            {
                //Find Product based on searchProductID
                sqlConn.Open();
                
                string procName = "TeamA.GetProductByProductID";
                SqlCommand cmd = new SqlCommand(procName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prodid", searchProductID);

                SqlDataReader row = cmd.ExecuteReader();

                while (row.Read())
                {
                    matchingProduct.ProductID = row.GetGuid(0);
                    matchingProduct.ProductName = row.GetString(1);
                    Enum.TryParse(row.GetString(2), out Category category);
                    matchingProduct.CategoryName = category;
                    matchingProduct.ProductStock = row.GetInt32(3);
                    matchingProduct.ProductSize = row.GetString(4);
                    matchingProduct.ProductColour = row.GetString(5);
                    matchingProduct.ProductTechSpecs = row.GetString(6);
                    matchingProduct.CostPrice = row.GetDouble(7);
                    matchingProduct.SellingPrice = row.GetDouble(8);
                    matchingProduct.DiscountPercentage = row.GetDouble(9);
                }
                row.Close();


            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets product based on ProductName.
        /// </summary>
        /// <param name="productName">Represents ProductName to search.</param>
        /// <returns>Returns Product object.</returns>
        public override Product GetProductByNameDAL(string productName)
        {
            Product matchingProduct = new Product();
            try
            {
                //Find Product based on searchProductID
                sqlConn.Open();

                string procName = "TeamA.GetProductByName";
                SqlCommand cmd = new SqlCommand(procName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prodname", productName);

                SqlDataReader row = cmd.ExecuteReader();

                while (row.Read())
                {
                    matchingProduct.ProductID = row.GetGuid(0);
                    matchingProduct.ProductName = row.GetString(1);
                    Enum.TryParse(row.GetString(2), out Category category);
                    matchingProduct.CategoryName = category;
                    matchingProduct.ProductStock = row.GetInt32(3);
                    matchingProduct.ProductSize = row.GetString(4);
                    matchingProduct.ProductColour = row.GetString(5);
                    matchingProduct.ProductTechSpecs = row.GetString(6);
                    matchingProduct.CostPrice = row.GetDouble(7);
                    matchingProduct.SellingPrice = row.GetDouble(8);
                    matchingProduct.DiscountPercentage = row.GetDouble(9);
                }
                row.Close();


            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return matchingProduct;
        }

        /// <summary>
        /// Gets product based on email.
        /// </summary>
        /// <param name="CategoryName">Represents Product's Category Name.</param>
        /// <returns>Returns Product object.</returns>
        public override List<Product> GetProductsByCategoryDAL(Category categoryName)
        {
            List<Product> matchingProducts = new List<Product>();
            try
            {
                //Find Product based on searchProductID
                sqlConn.Open();

                string procName = "TeamA.GetProductsByCategory";
                SqlCommand cmd = new SqlCommand(procName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@category", Convert.ToString(categoryName));

                SqlDataReader row = cmd.ExecuteReader();
                Product product = new Product();
                while (row.Read())
                {
                    product.ProductID = row.GetGuid(0);
                    product.ProductName = row.GetString(1);
                    Enum.TryParse(row.GetString(2), out Category category);
                    product.CategoryName = category;
                    product.ProductStock = row.GetInt32(3);
                    product.ProductSize = row.GetString(4);
                    product.ProductColour = row.GetString(5);
                    product.ProductTechSpecs = row.GetString(6);
                    product.CostPrice = row.GetDouble(7);
                    product.SellingPrice = row.GetDouble(8);
                    product.DiscountPercentage = row.GetDouble(9);

                    matchingProducts.Add(product);
                }
                row.Close();


            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return matchingProducts;
        }



        /// <summary>
        /// Updates product based on ProductID.
        /// </summary>
        /// <param name="updateProduct">Represents Product details including ProductID, ProductName etc.</param>
        /// <returns>Determinates whether the existing product is updated.</returns>
        public override bool UpdateProductDAL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                //Find Product based on ProductID
                Product matchingProduct = GetProductByProductIDDAL(updateProduct.ProductID);

                if (matchingProduct != null)
                {
                    //Update product details
                    ReflectionHelpers.CopyProperties(updateProduct, matchingProduct, new List<string>() { "ProductName", "CategoryName", "ProductSize", "ProductColour",
                    "ProductTechSpecs"});
                    productUpdated = true;
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return productUpdated;
        }

        /// <summary>
        /// Update product stock.
        /// </summary>
        /// <param name="updateProduct">Represents Product details including ProductID, ProductName etc.</param>
        /// <returns>Determinates whether the existing product is updated.</returns>

        public override bool UpdateProductStockDAL(Product updateProduct)
        {
            bool stockUpdated = false;
            try
            {
                //Find Product based on ProductID
                Product matchingProduct = GetProductByProductIDDAL(updateProduct.ProductID);

                if (matchingProduct != null)
                {
                    //Update product details
                    ReflectionHelpers.CopyProperties(updateProduct, matchingProduct, new List<string>() { "ProductStock" });
                    stockUpdated = true;
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return stockUpdated;
        }


        /// <summary>
        /// Deletes product based on ProductID.
        /// </summary>
        /// <param name="deleteProductID">Represents ProductID to delete.</param>
        /// <returns>Determinates whether the existing product is updated.</returns>
        public override bool DeleteProductDAL(Guid deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                //Find Product based on searchProductID
                Product matchingProduct = productList.Find(
                    (item) => { return item.ProductID == deleteProductID; }
                );

                if (matchingProduct != null)
                {
                    //Delete Product from the collection
                    productList.Remove(matchingProduct);
                    productDeleted = true;
                }
            }
            catch (GreatOutdoorsException)
            {
                throw;
            }
            return productDeleted;
        }



        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}



