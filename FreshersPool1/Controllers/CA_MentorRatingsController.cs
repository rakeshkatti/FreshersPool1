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
    public class CA_MentorRatingsController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_MentorRatings/

        public ViewResult Index()
        {
            var ca_mentorratings = db.CA_MentorRatings.Include(c => c.CA_PersonalData);
            return View(ca_mentorratings.ToList());
        }

        //
        // GET: /CA_MentorRatings/Details/5

        public ViewResult Details(string id)
        {
            CA_MentorRatings ca_mentorratings = db.CA_MentorRatings.Find(id);
            return View(ca_mentorratings);
        }

        //
        // GET: /CA_MentorRatings/Create

        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            return View();
        } 

        //
        // POST: /CA_MentorRatings/Create

        [HttpPost]
        public ActionResult Create(CA_MentorRatings ca_mentorratings)
        {
            if (ModelState.IsValid)
            {
                db.CA_MentorRatings.Add(ca_mentorratings);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_mentorratings.CandidateID);
            return View(ca_mentorratings);
        }
        
        //
        // GET: /CA_MentorRatings/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_MentorRatings ca_mentorratings = db.CA_MentorRatings.Find(id);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_mentorratings.CandidateID);
            return View(ca_mentorratings);
        }

        //
        // POST: /CA_MentorRatings/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_MentorRatings ca_mentorratings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_mentorratings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_mentorratings.CandidateID);
            return View(ca_mentorratings);
        }

        //
        // GET: /CA_MentorRatings/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_MentorRatings ca_mentorratings = db.CA_MentorRatings.Find(id);
            return View(ca_mentorratings);
        }

        //
        // POST: /CA_MentorRatings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_MentorRatings ca_mentorratings = db.CA_MentorRatings.Find(id);
            db.CA_MentorRatings.Remove(ca_mentorratings);
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