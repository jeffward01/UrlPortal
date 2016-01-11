using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
   // [Authorize(Roles = "A")]
    public class CategoryController : BaseAdminController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category model)
        {
            if (!ModelState.IsValid)
                return View("Index");

            try
            {
                objBs.categoryBs.Insert(model);
                TempData["Msg"] = "Created Successfully";
            }
            catch (Exception exception)
            {
                TempData["Msg"] = "Create Failed : " + exception.Message;
            }

            return RedirectToAction("Index");
        }
    }
}