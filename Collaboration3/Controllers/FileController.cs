using Collaboration.Models;
using System;
using System.Collections.Generic;
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

        public FileResult Download(string id)
        {

            var currentId = Convert.ToInt32(id);
            var filesCol = obj.GetFiles();
            string CurrentFileName = (from Files in filesCol
                                      where Files.Id == currentId
                                      select Files.FilePath).LastOrDefault();


            string contentType = string.Empty;

            if(CurrentFileName.Contains(".txt"))
            {
                contentType = "application/txt";
            }
            else
                if(CurrentFileName.Contains(".doc"))
            {
                contentType = "application/doc";
            }
            return File(CurrentFileName,contentType,CurrentFileName);
        }
    }
}