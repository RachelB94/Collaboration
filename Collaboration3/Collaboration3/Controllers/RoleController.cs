using Collaboration3.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Collaboration3.Controllers
{
    public class RoleController : Controller
    {

    /*	
 	* This code is based on that of found at  http://www.dotnetfunda.com/articles/show/2898/working-with-roles-in-aspnet-identity-for-mvc 	
 	* On 5/5/2016 	
 	*/


   
        ApplicationDbContext context = new ApplicationDbContext();

       [Authorize(Roles ="Administrator")]
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }
        
        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        //Create A New Role 
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully! ";
                return RedirectToAction("Index");
            }
            catch { return View(); }
            }

        //Delete A Role

        public ActionResult Delete(string RoleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Role Name

        public ActionResult Edit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            return View(thisRole);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult ManageUserRoles()
        {
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select
                ( rr =>
            new SelectListItem
            {
                Value = rr.Name.ToString(),
                Text = rr.Name
            }).ToList();

            ViewBag.Roles = list;
            return View();
        }

        //Add a user to a role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var account = new AccountController();
            account.UserManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created successfully";

            var list = context.Roles.OrderBy(r => r.Name).ToList().Select
                (rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();

            ViewBag.Roles = list;

            return View("ManageUserRoles");
        }

        //Get Roles for a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if(!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where
                    (u => u.UserName.Equals
                    (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var account = new AccountController();

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                var list = context.Roles.OrderBy
                    (r => r.Name).ToList().Select(
                    rr => new SelectListItem
                    {
                        Value = rr.Name.ToString(),
                        Text = rr.Name
                    }).ToList();
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        //Delete a user from a role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            AccountController account = new AccountController();
            ApplicationUser user = context.Users.Where(
                u => u.UserName.Equals
                (UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                account.UserManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed";
            }
            else
            {
                ViewBag.ResultMessage = "This user does not belong to selected role";
            }

            var list = context.Roles.OrderBy
                (r => r.Name).ToList().Select(
                rr => new SelectListItem
                {
                    Value = rr.Name.ToString(),
                    Text = rr.Name
                }).ToList();
            ViewBag.Roles = list;
            return View("ManageUserRoles");
        }

       
        }

   
    }
