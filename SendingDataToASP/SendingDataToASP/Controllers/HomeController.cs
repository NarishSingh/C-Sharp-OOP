using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendingDataToASP.Models;

namespace SendingDataToASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /*QUERY STRING ACTIONS*/
        /// <summary>
        /// Sends data via a query string using the Request Obj
        /// </summary>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult QueryString1()
        {
            var model = new ProductSearch
            {
                Category = Request.QueryString["category"],
                Subcategory = Request.QueryString["subcategory"]
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Sends data via a query string using method params
        /// </summary>
        /// <param name="category">Query string from GET request</param>
        /// <param name="subcategory">Query string from GET request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult QueryString2(string category, string subcategory)
        {
            var model = new ProductSearch
            {
                Category = category,
                Subcategory = subcategory
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Sends data via a query string using model obj
        /// </summary>
        /// <param name="model">ProductSearch model with data scraped by model binder from GET request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult QueryString3(ProductSearch model)
        {
            return View("SearchResult", model);
        }

        /*PATH ACTIONS*/
        /// <summary>
        /// Passes data via the path using custom RouteData obj
        /// </summary>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult Path1()
        {
            var model = new ProductSearch
            {
                Category = RouteData.Values["category"].ToString(),
                Subcategory = RouteData.Values["subcategory"].ToString()
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Passes data via the path by binding route data to model obj with method params
        /// </summary>
        /// <param name="category">Route data string from request</param>
        /// <param name="subcategory">Route data string from request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult Path2(string category, string subcategory)
        {
            var model = new ProductSearch
            {
                Category = category,
                Subcategory = subcategory
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Passes data via the path by binding route data to model obj
        /// </summary>
        /// <param name="model">ProductSearch model with data scraped by model binder from GET request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpGet]
        public ActionResult Path3(ProductSearch model)
        {
            return View("SearchResult", model);
        }

        /*REQUEST BODY - FORM*/
        /// <summary>
        /// Passes data from form via Request obj's Form NameValue collection field
        /// </summary>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpPost]
        public ActionResult Form1()
        {
            var model = new ProductSearch
            {
                Category = Request.Form["category"],
                Subcategory = Request.Form["subcategory"]
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Passes data from form via method params pulled from request body
        /// </summary>
        /// <param name="category">string from form request</param>
        /// <param name="subcategory">string from form request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpPost]
        public ActionResult Form2(string category, string subcategory)
        {
            var model = new ProductSearch
            {
                Category = category,
                Subcategory = subcategory
            };

            return View("SearchResult", model);
        }

        /// <summary>
        /// Passes data from from via modeling binding
        /// </summary>
        /// <param name="model">ProductSearch model with data scraped by model binder from GET request</param>
        /// <returns>Search Result view with the ProductSearch model data</returns>
        [HttpPost]
        public ActionResult Form3(ProductSearch model)
        {
            return View("SearchResult", model);
        }
    }
}