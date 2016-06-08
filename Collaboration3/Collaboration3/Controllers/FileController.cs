using Collaboration.Models;
using Collaboration3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collaboration.Controllers
{

    public class FileController : Controller
    {
        // GET: File

     
       
        DownloadFile obj;
        public FileController()
        {
            obj = new DownloadFile();
        }


        public ActionResult Index()
        {

            var fileCollection = obj.GetFiles();
            return View(fileCollection);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //Check File Path
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        //Download File
        [Authorize(Roles = "Administrator,BOMI")]
        public FileResult Download(string id)
        {
            //Check if File Exists
            var currentId = Convert.ToInt32(id);
            var filesCol = obj.GetFiles();
            string CurrentFileName = (from Files in filesCol
                                      where Files.Id == currentId
                                      select Files.FilePath).LastOrDefault();


            string contentType = string.Empty;

         
            //Check file Type
            if (CurrentFileName.Contains(".txt"))
            {

                contentType = "application/txt";

            }



            if (CurrentFileName.Contains(".doc"))
            {
                contentType = "application/doc";
            }

            if (CurrentFileName.Contains(".jpg"))
            {
                contentType = "application/jpg";
            }

            if (CurrentFileName.Contains(".jpg"))
            {
                contentType = "application/jpg";
            }

            if (CurrentFileName.Contains(".xls"))
            {
                contentType = "application/xls";
            }


            if (CurrentFileName.Contains(".pdf"))
            {
                contentType = "application/pdf";
            }


            return File(CurrentFileName, contentType, CurrentFileName);
        }
   

    }

 }





























