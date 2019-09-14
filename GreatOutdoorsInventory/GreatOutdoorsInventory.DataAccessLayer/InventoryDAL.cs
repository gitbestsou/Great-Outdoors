using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using GreatOutdoorsInventory.Entities;
using GreatOutdoorsInventory.Exceptions;

namespace GreatOutdoorsInventory.DataAccessLayer
{
    public class InventoryDAL
    {
        public static List<Inventory> inventory = new List<Inventory>();

        public bool AddToInventoryDAL(Inventory newProduct)
        {
            bool productAdded = false;
            try
            {
                inventory.Add(newProduct);
                productAdded = true;
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return productAdded;

        }

        public List<Inventory> GetInventoryDAL()
        {
            return inventory;
        }

        public Inventory SearchInventoryDAL(int searchProductID)
        {
            Inventory searchProduct = null;
            try
            {
                foreach (Inventory item in inventory)
                {
                    if (item.ProductID == searchProductID)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new GreatOutdoorsInventoryException(ex.Message);
            }
            return searchProduct;
        }

            public bool UpdateInventoryDAL(Inventory updateProduct)
            {
                bool productUpdated = false;
                try
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (inventory[i].ProductID == updateProduct.ProductID)
                        {
                            updateProduct.ProductQuantity = inventory[i].ProductQuantity;
                            updateProduct.CostPrice = inventory[i].CostPrice;
                            productUpdated = true;
                        }
                    }
                }
                catch (SystemException ex)
                {
                    throw new GreatOutdoorsInventoryException(ex.Message);
                }
                return productUpdated;

            }

            public bool DeleteProductDAL(int deleteProductID)
            {
                bool productDeleted = false;
                try
                {
                    Inventory deleteProduct = null;
                    foreach (Inventory item in inventory)
                    {
                        if (item.ProductID == deleteProductID)
                        {
                            deleteProduct = item;
                        }
                    }

                    if (deleteProduct != null)
                    {
                        inventory.Remove(deleteProduct);
                        productDeleted = true;
                    }
                }
                catch (DbException ex)
                {
                    throw new GreatOutdoorsInventoryException(ex.Message);
                }
                return productDeleted;

            }

        }
    }
