
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
   // [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var categories = objBs.categoryBs.GetAll();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;

            }

            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            categories = categories.Skip((page - 1) * 10).Take(10);

            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objBs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
            }
            catch (Exception exception)
            {
                TempData["Msg"] = "Delete Failed : " + exception.Message;
            }
            return RedirectToAction("Index");
        }
    }
}