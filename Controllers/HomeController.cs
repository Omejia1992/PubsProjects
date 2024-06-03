using PubsProjects.Classes;
using PubsProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PubsProjects.Controllers
{
    public class HomeController : Controller
    {

        private pubsEntities db = new pubsEntities();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Starting Action to show the Web Page
        /// </summary>
        /// <returns> View Start</returns>
        public ActionResult Start()
        {
            /* The following Code block creates a Currency Object 
               and the List of items to show in the Comboboxes */

            Currency currency = new Currency();
            ViewBag.Countries = new SelectList(db.Countries, "Id", "Name");
            ViewBag.Currency = new SelectList(currency.GetCurrencies(), "Name", "Symbol" );

            return View();
        }

        /// <summary>
        /// Post Action of Start View
        /// </summary>
        /// <param name="request"></param>
        /// <returns> View Start</returns>
        [HttpPost]
        public ActionResult Start(PubsProjects.Models.Request request) {

            /* The following Code block creates a Currency Object 
               and the List of items to show in the Comboboxes */

            Currency currency = new Currency();
            ViewBag.Countries = new SelectList(db.Countries, "Id", "Name");
            ViewBag.Currency = new SelectList(currency.GetCurrencies(), "Name", "Symbol");

            /// The fitering Criteria is stored in Session["Request"]
            Session["Request"] = request;

            return View();
        }

        /// <summary>
        /// Action to Load the Partial View that 
        /// shows the Country Info result
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadCountry() {

            /* The following Code block evaluates if there is a filtering Criteria 
              to apply, or not. If there is, the data is filtered and displayed in the 
              CountryDetail Partial View */

            CountryInfo countryInfo = new CountryInfo();

            if (Session["Request"] != null)
            {
               Request request = (Request)Session["Request"];
               Country ct = db.Countries.Where(c => c.Id == request.CountryId).FirstOrDefault();
               Land country = new Land(ct.Id, ct.Name);  

                Currency currency = new Currency();
                currency = currency.GetCurrencies().Where(c => c.Name.Equals(request.CurName)).Single();

                view_CountryOrdersInfo test = db.view_CountryOrdersInfo.Where(c => c.Id == request.CountryId).First();
                countryInfo = new CountryInfo(country, currency, test);

            }
            return View("CountryDetail", countryInfo);
        }

    }
}