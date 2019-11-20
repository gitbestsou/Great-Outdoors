using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capgemini.GreatOutdoors.BusinessLayer;
using GreatOutdoors.Entities;
using GreatOutdoors.MVC.Models;

/*Products Controller which contains methods to perform Create, Edit, Delete and Display Products
Project name : Great Outdoors
Developer name: Madhuri Vemulapaty
Use case : Products
Creation date : 25/10/2019
Last modified : 29/10/2019
 */

namespace GreatOutdoors.MVC.Controllers
{
    public class ProductsController : Controller
    {
        // URL:Products/Create
        /// <summary>
        /// Method to display and take the values of Add New Product form
        /// </summary>
        /// <returns> Returns view of add product form</returns>
        public ActionResult Create()
        {
            //Creating ViewModel object
            ProductViewModel productViewModel = new ProductViewModel();

            //Calling View and passing ViewModel object to view
            return View(productViewModel);
        }

        /// <summary>
        /// Method to Add new product to database
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns>returns view of index of products if product is added successfully or displays error message</returns>
        [HttpPost]
        public async Task<ActionResult> Create(ProductViewModel productViewModel)
        {
            bool isAdded = false;
            Product product = new Product();
            //Copying the values of the form to Product entity
            product.ProductID = productViewModel.ProductID;
            product.Name = productViewModel.Name;
            product.Category = productViewModel.Category;
            product.Colour = productViewModel.Colour;
            product.Size = productViewModel.Size;
            product.TechnicalSpecifications = productViewModel.TechnicalSpecifications;
            product.Stock = productViewModel.Stock;
            product.SellingPrice = productViewModel.SellingPrice;
            product.DiscountPercentage = productViewModel.DiscountPercentage;
            product.CostPrice = productViewModel.CostPrice;

            ProductBL productBL = new ProductBL();
            //Adding the new product to the Database
            isAdded = await productBL.AddProductBL(product);

            if (isAdded)
                //Redirecting to Index of Products if addition is successful
                return RedirectToAction("Index", "Products");
            else
                //Displaying error message if addition is unsuccessful
                return Content("Product couldn't be added");

        }


        // URL:Products/Edit
        /// <summary>
        /// Method to display the edit form of selected product
        /// </summary>
        /// <param name="id">Id of the selected product</param>
        /// <returns>Returns the view of edit form</returns>
        public async Task<ActionResult> Edit(Guid id)
        {
            //Creating ViewModel object
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();


            //Retrieving the selected product and itś details by ID
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50075/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductsAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ProductViewModel>>();
                    readTask.Wait();

                    productViewModel = readTask.Result;
                }
            }
            //Product product = await productBL.GetProductByProductIDBL(id);





            //Calling View and passing ViewModel object to view
            return View(productViewModel[0]);
        }

        /// <summary>
        /// Method to post the edit form data and store the updated details in the database
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns>Returns index view of products if edit is successful or displays error message</returns>

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel productViewModel)
        {

            ProductBL productBL = new ProductBL();
            Product product = await productBL.GetProductByProductIDBL(productViewModel.ProductID);

            //Updating the product details from the edit form
            product.SellingPrice = productViewModel.SellingPrice;
            product.TechnicalSpecifications = productViewModel.TechnicalSpecifications;
            product.DiscountPercentage = productViewModel.DiscountPercentage;
            product.Stock = productViewModel.Stock;
            product.CostPrice = productViewModel.CostPrice;

            //Calling methods to update details in the database
            bool details = await productBL.UpdateProductDetailsBL(product);
            bool stock = await productBL.UpdateProductStockBL(product);
            bool discount = await productBL.UpdateProductDiscountBL(product);

            if (details && stock && discount)
                //Redirecting to Index of Products if updation is successful
                return RedirectToAction("Index");
            else
                //Displaying error message if updation is unsuccessful
                return Content("Product couldn't be updated");

        }

        /// <summary>
        /// Method to display the list of products in the database
        /// </summary>
        /// <returns>Returns the view of products in the database</returns>
        // URL:Products/Index
        public async Task<ActionResult> Index()
        {

            List<ProductViewModel> productsVM = new List<ProductViewModel>();


            ////Getting all the products from the database
            //products = await productBL.GetAllProductsBL();


            ////Convert data from DataContract to ViewModel
            //List<ProductViewModel> productsVM = products
            //    .Select
            //        (temp => new ProductViewModel()
            //        {
            //            ProductID = temp.ProductID,
            //            Name = temp.Name,
            //            Category = temp.Category,
            //            TechnicalSpecifications = temp.TechnicalSpecifications,
            //            Stock = temp.Stock,
            //            Colour = temp.Colour,
            //            Size = temp.Size,
            //            CostPrice = temp.CostPrice,
            //            SellingPrice = temp.SellingPrice,
            //            DiscountPercentage = temp.DiscountPercentage
            //        }
            //    ).ToList();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50075/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ProductsAPI");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<ProductViewModel>>();
                    readTask.Wait();

                    productsVM = readTask.Result;
                }
                //else //web api sent error response 
                //{
                //    //log response status here..

                //    students = Enumerable.Empty<StudentViewModel>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                //}
            }




            //Calling View and passing ViewModel object to view
            return View(productsVM);
        }
        /// <summary>
        /// Method to delete the selected product from database
        /// </summary>
        /// <param name="id">Id of the selected product</param>
        /// <returns>Returns index view of products if deletion is successful or displays error message</returns>
        public async Task<ActionResult> Delete(Guid id)
        {
            ProductBL productBL = new ProductBL();
            //Deleting the product from the database using the given ID
            bool isDeleted = await productBL.DeleteProductBL(id);

            if (isDeleted)
                //Redirecting to Index of Products if deletion is successful
                return RedirectToAction("Index");
            else
                //Displaying error message if deletion is unsuccessful
                return Content("Product couldn't be deleted");
        }
    }
}