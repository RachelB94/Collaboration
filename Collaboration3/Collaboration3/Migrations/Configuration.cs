namespace Collaboration3.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Collaboration3.Models.ApplicationDbContext>
    {


        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Collaboration3.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //context.Roles.AddOrUpdate(r => r.Name,
            //    new IdentityRole { Name = "Administrator" },
            //    new IdentityRole { Name = "BOMI" },
            //    new IdentityRole { Name = "SDM" });
            //    }

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Administrator", "BOMI", "SDM" };
            IdentityResult roleResult;
            foreach(var roleName in roleNames)
            {
                if(!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("be504e76-3379-4f37-a65c-b5a521f22dd7", "Administrator");
        }


    }
}



        
   

