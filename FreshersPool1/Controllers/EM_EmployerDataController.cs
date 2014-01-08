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
    public class EM_EmployerDataController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /EM_EmployerData/

        public ViewResult Index()
        {
            return View(db.EM_EmployerData.ToList());
        }

        //
        // GET: /EM_EmployerData/Details/5

        public ViewResult Details(int id)
        {
            EM_EmployerData em_employerdata = db.EM_EmployerData.Find(id);
            return View(em_employerdata);
        }

        //
        // GET: /EM_EmployerData/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EM_EmployerData/Create

        [HttpPost]
        public ActionResult Create(EM_EmployerData em_employerdata)
        {
            em_employerdata.EmployerID = (int)Session["employerID"];
            if (ModelState.IsValid)
            {
                db.EM_EmployerData.Add(em_employerdata);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(em_employerdata);
        }
        
        //
        // GET: /EM_EmployerData/Edit/5
 
        public ActionResult Edit(int id)
        {
            EM_EmployerData em_employerdata = db.EM_EmployerData.Find(id);
            return View(em_employerdata);
        }

        //
        // POST: /EM_EmployerData/Edit/5

        [HttpPost]
        public ActionResult Edit(EM_EmployerData em_employerdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(em_employerdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(em_employerdata);
        }

        //
        // GET: /EM_EmployerData/Delete/5
 
        public ActionResult Delete(int id)
        {
            EM_EmployerData em_employerdata = db.EM_EmployerData.Find(id);
            return View(em_employerdata);
        }

        //
        // POST: /EM_EmployerData/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EM_EmployerData em_employerdata = db.EM_EmployerData.Find(id);
            db.EM_EmployerData.Remove(em_employerdata);
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