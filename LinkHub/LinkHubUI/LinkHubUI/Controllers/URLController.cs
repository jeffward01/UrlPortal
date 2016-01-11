using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Controllers
{
    public class URLController : Controller
    {
        // GET: URL
        public ActionResult Index()
        {
            LinkHubDbEntities db = new LinkHubDbEntities();
            ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");
            return View();
        }
    }
}