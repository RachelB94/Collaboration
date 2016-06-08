using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Collaboration3.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Collaboration3.Controllers
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
    

        /*	
 	* This code is based on that of found at  http://www.c-sharpcorner.com/UploadFile/sourabh_mishra1/sending-an-e-mail-using-Asp-Net-mvc/
 	* On 30/5/2016 	
 	*/
        //Contact Form
        [HttpPost]
        public ViewResult Contact(EmailFormModel objModel)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(objModel.To));
                mail.From = new MailAddress(objModel.From);
                mail.Subject = objModel.Subject;
                string Body = objModel.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Setting up email authentication
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("rachelbyrne1994@gmail.com", "rach=lizbestcuzz"); // Enter senders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
               

                return View("Contact", objModel);
            }
            else
            {
                return View();
            }
        }
    }
}
