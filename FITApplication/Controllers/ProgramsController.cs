using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FITApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FITApplication.Controllers
{
    [Authorize(Roles = RoleName.All)]
    public class ProgramsController : Controller
    {
        private ProgramsContext db = new ProgramsContext();
        private ApplicationDbContext _contex { get; set; }
        private UserManager<ApplicationUser> _userManager;

        public ProgramsController(){
            this._contex = new ApplicationDbContext();
            this._userManager = new UserManager<ApplicationUser> (new UserStore<ApplicationUser>(this._contex));
        }

        // GET: Programs
        public ActionResult Index()
        {
            return View(db.programs.ToList());
        }

        // GET: Programs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userManager.FindById(User.Identity.GetUserId());
            int index = int.Parse(user.PhoneNumber);
            Program program = db.programs.Find(id);
            ProgramClient model = new ProgramClient();
            model.ClientID = index;
            ViewBag.Rent = program.clients.FirstOrDefault(z => z.ClientID == model.ClientID);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        public ActionResult InsertNewClient(int id)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            ProgramClient model = new ProgramClient();
            model.ProgramID = id;
            model.program = db.programs.Find(id);
            model.ClientID = int.Parse(user.PhoneNumber);
            var client = db.clients.FirstOrDefault(z => z.ClientID == model.ClientID);
            var program = db.programs.FirstOrDefault(z => z.ProgramID == model.ProgramID);
            program.clients.Add(client);
            db.SaveChanges();
            return View("Index", db.programs.ToList());
        }

        public ActionResult PlayProgram(int id)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            int index = int.Parse(user.PhoneNumber);
            Program program = db.programs.Find(id);
            ProgramClient model = new ProgramClient();
            model.ClientID = index;
            var a = program.clients.FirstOrDefault(z => z.ClientID == model.ClientID);
            if (a != null)
            {
                return View(program);
            }
            else
            {
                return RedirectToAction("Details", new { id = program.ProgramID });
            }
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        public ActionResult ViewRentals(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        public ActionResult MyRentPrograms()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            int index = int.Parse(user.PhoneNumber);
            return View();
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = RoleName.AdminTrainer)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramID,Name,ImgUrl,Price,Description")] Program program)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindById(User.Identity.GetUserId());
                int userID = int.Parse(user.PhoneNumber);
                var client = db.clients.Find(userID);
                program.Creator = client.Name;
                db.programs.Add(program);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(program);
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        // GET: Programs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.AdminTrainer)]
        public ActionResult Edit([Bind(Include = "ProgramID,Name,ImgUrl,Price,Description,Creator")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Programs", new { id = program.ProgramID });
            }
            return View(program);
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = db.programs.Find(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        [Authorize(Roles = RoleName.AdminTrainer)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program program = db.programs.Find(id);
            db.programs.Remove(program);
            db.SaveChanges();
            return RedirectToAction("Index");
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
