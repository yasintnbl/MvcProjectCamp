using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {

        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        Context c = new Context();

        // GET: Gallery
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImage(ImageFile p)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string _fileName = Path.GetExtension(Request.Files[0].FileName);
                string url = "~/Images/" + fileName + _fileName;
                Request.Files[0].SaveAs(Server.MapPath(url));
                p.ImagePath= "/Images/" + fileName + _fileName;
                
            }
            ifm.ImageFileAdd(p);
            return RedirectToAction("Index");
        }
    }
}