using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult ListContact(int page = 1, int rows = 10)
        {
            using (var cn = new ConnectionDB())
            {
                var result = cn.Productos(new Producto { User = "admin" });
                // return View(result.ToList());

                int totalrecords = result.Count();

                var jsonData = new
                {
                    total = 10,
                    page,
                    records = totalrecords,
                    rows = result.Select(a => new { a.Id, a.Description, Estado = a.Status == 1 ? "Activo" : "Inactivo", a.CategoryCode })
                };

                return Json(jsonData, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddProducto(Producto req)
        {
            try
            {
                using (var con = new ConnectionDB())
                {
                    req.User = "admin";
                    var result = con.ProductoCrear(req);

                    return Json(new { result = true, response = result });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, response = ex.Message.ToString() });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditProducto(Producto req)
        {
            try
            {
                using (var con = new ConnectionDB())
                {
                    req.User = "admin";
                    var result = con.ProductoUpdate(req);

                    return Json(new { result = true, response = result });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, response = ex.Message.ToString() });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteProducto(Producto req)
        {
            try
            {
                using (var con = new ConnectionDB())
                {
                    req.User = "admin";
                    var result = con.ProductoDeactivate(req);

                    return Json(new { result = true, response = result });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = false, response = ex.Message.ToString() });
            }
        }
    }
}