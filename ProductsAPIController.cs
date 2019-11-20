using Capgemini.GreatOutdoors.BusinessLayer;
using GreatOutdoors.API.Models;
using GreatOutdoors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace GreatOutdoors.API.Controllers
{
    public class ProductsAPIController : ApiController
    {
        //Declaring the product Business Layer 
        private ProductBL productAccessBL;
        

        public ProductsAPIController()
        {
            //Declaring the product Business Layer 
            productAccessBL = new ProductBL();
        }

        public async Task<IHttpActionResult> GetAllProducts()
        {
            // List of the products from Business layer
            List<Product> products = await productAccessBL.GetAllProductsBL();
            //Declaring the product viewModel list
            List<ProductViewModel> productsVM = products
                .Select
                    //Copying details of each product to productViewModel
                    (temp => new ProductViewModel()
                    {
                        ProductID = temp.ProductID,
                        Name = temp.Name,
                        Category = temp.Category,
                        TechnicalSpecifications = temp.TechnicalSpecifications,
                        Stock = temp.Stock,
                        Colour = temp.Colour,
                        Size = temp.Size,
                        CostPrice = temp.CostPrice,
                        SellingPrice = temp.SellingPrice,
                        DiscountPercentage = temp.DiscountPercentage
                    }
                ).ToList();


            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(productsVM);

        }




        public async Task<IHttpActionResult> GetProductByProductID(Guid id) {
            Product currProduct = await productAccessBL.GetProductByProductIDBL(id);

            ProductViewModel productVM = new ProductViewModel()
            {
                ProductID = currProduct.ProductID,
                Name = currProduct.Name,
                Category = currProduct.Category,
                TechnicalSpecifications = currProduct.TechnicalSpecifications,
                Stock = currProduct.Stock,
                Colour = currProduct.Colour,
                Size = currProduct.Size,
                CostPrice = currProduct.CostPrice,
                SellingPrice = currProduct.SellingPrice,
                DiscountPercentage = currProduct.DiscountPercentage
            };

            if (currProduct==null)
            {
                return NotFound();
            }

            return Ok(productVM);


        }


    }
}
