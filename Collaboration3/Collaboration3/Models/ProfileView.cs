using Collaboration3.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Collaboration3.Models
{
    public class ProfileView
    {

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
