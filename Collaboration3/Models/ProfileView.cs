using Collaboration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collaboration.Models
{
    public class ProfileView
    {

        [Display(Name = "Image")]


        public String ImagePath
        {
            get
            {
                return ImagePath;
            }

        }

        [Required]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]
        [Display(Name = "Job Role")]
        public string JobRole { get; set; }

        [Required]
        [Display(Name = "Team")]
        public string TeamName { get; set; }
       
       








        }
    }
