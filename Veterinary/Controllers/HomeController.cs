using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veterinary.Models;
using Veterinary.Helpers;

namespace Veterinary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Patient> Pent = new List<Patient>();

            Pent = new DBCRUD().List();

            return View(Pent);
        }
        


        [HttpPost]
        public ActionResult Create(Patient pent)
        {
            int Result = 0;
            Result = new DBCRUD().Create(pent);
            return RedirectToAction("Action", "controller");
        }

        public ActionResult Search()
        {
            DBCRUD dbsearch = new DBCRUD();
            if (Request.HttpMethod == "POST")
            {
                if (!string.IsNullOrWhiteSpace(Request["SearchText"]))
                {
                    string text = Request["SearchText"];
                    dbsearch.Search(text);
                }
            }
            return RedirectToAction("Action", "controller");
        }

        [HttpPost]
        public ActionResult Update(int ID, Patient Pent)
        {
            int Result = 0;
            Result = new DBCRUD().Update(ID, Pent);
            return RedirectToAction("Action", "controller");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            int Result = 0;
            DBCRUD dbdelete = new DBCRUD();
            Result = dbdelete.Delete(ID);

            return RedirectToAction("Action", "controller");
        }
    }
}