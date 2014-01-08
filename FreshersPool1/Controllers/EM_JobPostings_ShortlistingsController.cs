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
    public class EM_JobPostings_ShortlistingsController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /EM_JobPostings_Shortlistings/

        public ViewResult Index()
        {
            var em_jobpostings_shortlistings = db.EM_JobPostings_Shortlistings.Include(e => e.CA_PersonalData).Include(e => e.EM_JobPostings).Include(e => e.MS_ResultMaster);
            return View(em_jobpostings_shortlistings.ToList());
        }

        //
        // GET: /EM_JobPostings_Shortlistings/Details/5

        public ViewResult Details(string id)
        {
            EM_JobPostings_Shortlistings em_jobpostings_shortlistings = db.EM_JobPostings_Shortlistings.Find(id);
            return View(em_jobpostings_shortlistings);
        }

        //
        // GET: /EM_JobPostings_Shortlistings/Create

        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            ViewBag.JobID = new SelectList(db.EM_JobPostings, "JobID", "EmployerID");
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result");
            return View();
        } 

        //
        // POST: /EM_JobPostings_Shortlistings/Create

        [HttpPost]
        public ActionResult Create(EM_JobPostings_Shortlistings em_jobpostings_shortlistings)
        {
            if (ModelState.IsValid)
            {
                db.EM_JobPostings_Shortlistings.Add(em_jobpostings_shortlistings);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", em_jobpostings_shortlistings.CandidateID);
            ViewBag.JobID = new SelectList(db.EM_JobPostings, "JobID", "EmployerID", em_jobpostings_shortlistings.JobID);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", em_jobpostings_shortlistings.Result);
            return View(em_jobpostings_shortlistings);
        }
        
        //
        // GET: /EM_JobPostings_Shortlistings/Edit/5
 
        public ActionResult Edit(string id)
        {
            EM_JobPostings_Shortlistings em_jobpostings_shortlistings = db.EM_JobPostings_Shortlistings.Find(id);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", em_jobpostings_shortlistings.CandidateID);
            ViewBag.JobID = new SelectList(db.EM_JobPostings, "JobID", "EmployerID", em_jobpostings_shortlistings.JobID);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", em_jobpostings_shortlistings.Result);
            return View(em_jobpostings_shortlistings);
        }

        //
        // POST: /EM_JobPostings_Shortlistings/Edit/5

        [HttpPost]
        public ActionResult Edit(EM_JobPostings_Shortlistings em_jobpostings_shortlistings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(em_jobpostings_shortlistings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", em_jobpostings_shortlistings.CandidateID);
            ViewBag.JobID = new SelectList(db.EM_JobPostings, "JobID", "EmployerID", em_jobpostings_shortlistings.JobID);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", em_jobpostings_shortlistings.Result);
            return View(em_jobpostings_shortlistings);
        }

        //
        // GET: /EM_JobPostings_Shortlistings/Delete/5
 
        public ActionResult Delete(string id)
        {
            EM_JobPostings_Shortlistings em_jobpostings_shortlistings = db.EM_JobPostings_Shortlistings.Find(id);
            return View(em_jobpostings_shortlistings);
        }

        //
        // POST: /EM_JobPostings_Shortlistings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            EM_JobPostings_Shortlistings em_jobpostings_shortlistings = db.EM_JobPostings_Shortlistings.Find(id);
            db.EM_JobPostings_Shortlistings.Remove(em_jobpostings_shortlistings);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public void ShortList(int id, int canID)
        {
            var result = from e1 in db.EM_JobPostings_Shortlistings
                         where e1.JobID == id && e1.CandidateID == canID
                         select e1;
            foreach (var i in result)
            {
                i.Result = "Selected";
            }
            db.SaveChanges();
        }
        public void Reject(int id, int canID)
        {
            var result = from e1 in db.EM_JobPostings_Shortlistings
                         where e1.JobID == id && e1.CandidateID == canID
                         select e1;
            foreach (var i in result)
            {
                i.Result = "Rejected";
            }
            db.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}