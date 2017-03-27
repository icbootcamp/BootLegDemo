using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootLegDemo.Models;

namespace BootLegDemo.Controllers
{
    public class HomeController : Controller
    {
        BootLegEntities db = new BootLegEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetModelList()
        {          
            var list = db.People.ToList().Select(x => new SupplierListModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                CompanyName = x.Supplier.CompanyName
            }).ToList();
            return View(list);
        }

        public ActionResult EditView(int id)
        {
            var currentPerson = db.People.Find(id);
            var sType = db.SupplierTypes.ToList();
            SupplierEntryModel model = new SupplierEntryModel
            { Id = currentPerson.Id,
                CompanyName = currentPerson.Supplier.CompanyName,
                FirstName = currentPerson.FirstName,
                SupplierType = sType.
                Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).
                ToList()
            };

            return View(model);
        }

        public ActionResult SaveEdit(SupplierEntryModel model)
        {
            return Json(new { success = true });
        }
    }
}