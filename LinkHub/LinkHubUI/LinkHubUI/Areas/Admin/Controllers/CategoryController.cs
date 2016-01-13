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

        private CategoryBs objBs;
        public CategoryController()
        {
            objBs = new CategoryBs();
        }

        //GET: /Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    objBs.Insert(model);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception exception)
            {
                TempData["Msg"] = "Create Failed : " + exception.Message;
                return RedirectToAction("Index");

            }
        }
    }
}