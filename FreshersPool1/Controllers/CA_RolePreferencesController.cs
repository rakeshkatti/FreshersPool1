using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreshersPool1.Models;

namespace FreshersPool1.Controllers
{ 
    public class CA_RolePreferencesController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_RolePreferences/

        public ViewResult Index()
        {
            var ca_rolepreferences = db.CA_RolePreferences.Include(c => c.MS_RoleMaster);
            return View(ca_rolepreferences.ToList());
        }

        //
        // GET: /CA_RolePreferences/Details/5

        public ViewResult Details(string id)
        {
            CA_RolePreferences ca_rolepreferences = db.CA_RolePreferences.Find(id);
            return View(ca_rolepreferences);
        }

        //
        // GET: /CA_RolePreferences/Create

        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.MS_RoleMaster, "RoleID", "RoleDesc");
            return View();
        } 

        //
        // POST: /CA_RolePreferences/Create

        [HttpPost]
        public ActionResult Create(CA_RolePreferences ca_rolepreferences)
        {
            if (ModelState.IsValid)
            {
                db.CA_RolePreferences.Add(ca_rolepreferences);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.RoleID = new SelectList(db.MS_RoleMaster, "RoleID", "RoleDesc", ca_rolepreferences.RoleID);
            return View(ca_rolepreferences);
        }
        
        //
        // GET: /CA_RolePreferences/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_RolePreferences ca_rolepreferences = db.CA_RolePreferences.Find(id);
            ViewBag.RoleID = new SelectList(db.MS_RoleMaster, "RoleID", "RoleDesc", ca_rolepreferences.RoleID);
            return View(ca_rolepreferences);
        }

        //
        // POST: /CA_RolePreferences/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_RolePreferences ca_rolepreferences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_rolepreferences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.MS_RoleMaster, "RoleID", "RoleDesc", ca_rolepreferences.RoleID);
            return View(ca_rolepreferences);
        }

        //
        // GET: /CA_RolePreferences/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_RolePreferences ca_rolepreferences = db.CA_RolePreferences.Find(id);
            return View(ca_rolepreferences);
        }

        //
        // POST: /CA_RolePreferences/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_RolePreferences ca_rolepreferences = db.CA_RolePreferences.Find(id);
            db.CA_RolePreferences.Remove(ca_rolepreferences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}