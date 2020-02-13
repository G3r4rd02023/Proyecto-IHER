using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoIHER.Models;
using ProyectoIHER.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProyectoIHER.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User

        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<UserView>();
            foreach (var user in users)
            {
                var userView = new UserView
                {
                    Email = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };
                usersView.Add(userView);
            }
            return View(usersView);
        }

        public ActionResult Roles(string userID)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var roles = roleManager.Roles.ToList();
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleId = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View(userView);
        }

        //Get
        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            if (user == null)
            {
                return HttpNotFound();
            }

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id
            };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "[Select a role...]" });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name");

            return View(userView);
        }

        //POST
        [HttpPost]
        public ActionResult AddRole(string userID, FormCollection form)
        {
            var roleID = Request["RoleID"];
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);
            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id
            };
            if (string.IsNullOrEmpty(roleID))
            {
                ViewBag.Error = "You must select a role";
                var list = roleManager.Roles.ToList();
                list.Add(new IdentityRole { Id = "", Name = "[Select a role...]" });
                list = list.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(list, "Id", "Name");
                return View(userView);
            }

            var roles = roleManager.Roles.ToList();
            var role = roles.ToList().Find(r => r.Id == roleID);
            if (!userManager.IsInRole(userID, role.Name))
            {
                userManager.AddToRole(userID, role.Name);
            }

            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleId = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);
        }

        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.Users.ToList().Find(u => u.Id == userID);
            var role = roleManager.Roles.ToList().Find(r => r.Id == roleID);
          
            if (userManager.IsInRole(userID, role.Name))
            {
                userManager.RemoveFromRole(userID, role.Name);
            }
            
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView
                {
                    Name = role.Name,
                    RoleId = role.Id
                };
                rolesView.Add(roleView);
            };

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}