using Collaboration3.Models;
using Collaboration.Models;
using System;
using System.Collections.Generic;
using System.IO;

using System.Web;
using System.Web.Hosting;
using System.Security.AccessControl;
using System.Web.Mvc;

namespace Collaboration.Models
{

    public class DownloadFile
    {

        //Find Files and Download

        public List<FileModel> GetFiles()
        {
            List<FileModel> file1 = new List<FileModel>();
            DirectoryInfo dir = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/Files"));

            int i = 0;
            foreach (var item in dir.GetFiles())
            {
                file1.Add(new FileModel()
                {
                    Id = i++,
                    FileName = item.Name,
                    FilePath = dir.FullName + @"\" + item.Name

                });
                i = i + 1;


            }
            return file1;
        }




    }
}


