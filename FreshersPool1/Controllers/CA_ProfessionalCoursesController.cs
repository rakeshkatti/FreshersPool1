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
    public class CA_ProfessionalCoursesController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_ProfessionalCourses/

        public ViewResult Index()
        {
            var ca_professionalcourses = db.CA_ProfessionalCourses.Include(c => c.CA_PersonalData);
            return View(ca_professionalcourses.ToList());
        }

        //
        // GET: /CA_ProfessionalCourses/Details/5

        public ViewResult Details(string id)
        {
            CA_ProfessionalCourses ca_professionalcourses = db.CA_ProfessionalCourses.Find(id);
            return View(ca_professionalcourses);
        }

        //
        // GET: /CA_ProfessionalCourses/Create

        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            return View();
        } 

        //
        // POST: /CA_ProfessionalCourses/Create

        [HttpPost]
        public ActionResult Create(CA_ProfessionalCourses ca_professionalcourses)
        {
            if (ModelState.IsValid)
            {
                db.CA_ProfessionalCourses.Add(ca_professionalcourses);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_professionalcourses.CandidateID);
            return View(ca_professionalcourses);
        }
        
        //
        // GET: /CA_ProfessionalCourses/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_ProfessionalCourses ca_professionalcourses = db.CA_ProfessionalCourses.Find(id);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_professionalcourses.CandidateID);
            return View(ca_professionalcourses);
        }

        //
        // POST: /CA_ProfessionalCourses/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_ProfessionalCourses ca_professionalcourses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_professionalcourses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_professionalcourses.CandidateID);
            return View(ca_professionalcourses);
        }

        //
        // GET: /CA_ProfessionalCourses/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_ProfessionalCourses ca_professionalcourses = db.CA_ProfessionalCourses.Find(id);
            return View(ca_professionalcourses);
        }

        //
        // POST: /CA_ProfessionalCourses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_ProfessionalCourses ca_professionalcourses = db.CA_ProfessionalCourses.Find(id);
            db.CA_ProfessionalCourses.Remove(ca_professionalcourses);
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