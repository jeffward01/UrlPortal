using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : Controller
    {

        private UrlBs objBs;

        public BrowseURLsController()
        {
            objBs = new UrlBs();
        }


        // GET: Common/BrowseURL
        public ActionResult Index()
        {
            //Only Grab Approved URL's and make links clickable
            var urls = objBs.GetAll().Where(url => url.IsApproved == "A").ToList();
            return View(urls);
        }
    }
}