using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhoneStore.Models;
using System.Net;
using System.Threading.Tasks;
namespace PhoneStore.Controllers
{
    public class RoleAdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: RoleAdmin
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(
               new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return View(roleManager.Roles);
        }

        // GET: RoleAdmin/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var role = await roleManager.FindByIdAsync(id);
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var users = new List<ApplicationUser>();
            foreach (var user in userManager.Users.ToList())
            {
                if (await userManager.IsInRoleAsync(user.Id, role.Name))
                    users.Add(user);
            }
            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }
        // GET: RoleAdmin/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: RoleAdmin/Create
        [HttpPost]
        public async Task<ActionResult>  Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                var r = new IdentityRole(role.Name);
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
                var rResult = await roleManager.CreateAsync(r);
                if(!rResult.Succeeded)
                {
                    ModelState.AddModelError("", rResult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: RoleAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            var r = await roleManager.FindByIdAsync(id);
            if (r == null)
                return HttpNotFound();
            RoleViewModel rModel = new RoleViewModel
            {
                IdRole = r.Id,
                Name = r.Name
            };
            return View(rModel);
        }

        // POST: RoleAdmin/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
                var r = await roleManager.FindByIdAsync(role.IdRole) ;
                if (r!=null)
                {
                    r.Name = role.Name;
                    await roleManager.UpdateAsync(r);
                }
                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: RoleAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleManager = new RoleManager<IdentityRole>(
                   new RoleStore<IdentityRole>(context));
            var r = await roleManager.FindByIdAsync(id);
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        // POST: RoleAdmin/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(string id,string tmp="")
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var roleManager = new RoleManager<IdentityRole>(
                       new RoleStore<IdentityRole>(context));
                var r = await roleManager.FindByIdAsync(id);
                if (r == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result = await roleManager.DeleteAsync(r);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
