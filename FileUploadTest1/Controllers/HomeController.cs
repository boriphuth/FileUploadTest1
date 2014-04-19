using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadTest1.Models;

namespace FileUploadTest1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Picture picture)
        {
            foreach (var file in picture.Files)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                    file.SaveAs(path);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
