using Collaboration3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace Collaboration.Models
{

    public class FileModel
    {

        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        

       
    }
}