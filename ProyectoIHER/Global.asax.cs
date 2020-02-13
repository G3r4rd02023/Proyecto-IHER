using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoIHER.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProyectoIHER
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //migracion automatica
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<
                Models.ProyectoIHERContext, Migrations.Configuration>());
            //establece conexion con la BD
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperUser(db);
            AddPermisionToSuperUser(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermisionToSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("glanza007@gmail.com");

            if (!userManager.IsInRole(user.Id, "View"))
            {
                userManager.AddToRole(user.Id, "View");
            }

            if (!userManager.IsInRole(user.Id, "Edit"))
            {
                userManager.AddToRole(user.Id, "Edit");
            }

            if (!userManager.IsInRole(user.Id, "Create"))
            {
                userManager.AddToRole(user.Id, "Create");
            }

            if (!userManager.IsInRole(user.Id, "Delete"))
            {
                userManager.AddToRole(user.Id, "Delete");
            }
        }

        //crear super usuario automaticamente
        private void CreateSuperUser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("glanza007@gmail.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "glanza007@gmail.com",
                    Email = "glanza007@gmail.com"
                };
                userManager.Create(user, "Gerardo.0708");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            //permite manipular los roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }

            if (!roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }

            if (!roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }

            if (!roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }
        }

    }
}
