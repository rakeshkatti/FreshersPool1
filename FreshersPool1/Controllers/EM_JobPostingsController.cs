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
    public class EM_JobPostingsController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();
        public RedirectResult Apply(int id)
        {
            EM_JobPostings_Shortlistings job = new EM_JobPostings_Shortlistings();
            int CandidateID = (int)Session["CandidateID"];
            job.JobID = (int)id;
            job.CandidateID = CandidateID;
            job.Result = "Result Awaiting";
            db.EM_JobPostings_Shortlistings.Add(job);
            db.SaveChanges();
            return Redirect("~/");
        }

        public ViewResult ViewApplied(int id)
        {
            var result = from e1 in db.EM_JobPostings_Shortlistings where e1.JobID == id
                         select e1;
            return View(result.ToList());
        }
  
        public ViewResult searchView(string qry)
        {

            var searchView = (from e1 in db.EM_JobPostings
                           where e1.Location == qry || e1.JobDescription == qry || e1.JobTitle == qry || e1.MS_RoleMaster.RoleDesc == qry
                           || e1.MS_DriveMaster.DriveType == qry || e1.MS_CityMaster.CityName == qry || e1.EM_EmployerData.Name == qry
                           select e1).ToList();

            return View(searchView.ToList());

        }

        //
        // GET: /EM_JobPostings/

        public ViewResult Index()
        {
            var result = from e1 in db.EM_JobPostings_Shortlistings
                         select e1;
            foreach (var item in result)
            {
                if (item.Result.ToString().Equals("Result Awaited"))
                {
                    Session["applied" + item.JobID] = "true";
                }

            }
            return View(db.EM_JobPostings.ToList());
        }

        // Jobs the Candidates have already applied
        
        public ViewResult AppliedJobs()
        {
            var result = from e1 in db.EM_JobPostings_Shortlistings
                         select e1;
            foreach (var item in result)
            {
                if (item.Result.ToString().Equals("Result Awaited"))
                {
                    Session["applied" + item.JobID] = "true";
                }

            }
            return View(db.EM_JobPostings.ToList());
        }

        // View Applied Candidates

        public ViewResult appliedCandidates()
        {
            return View(db.EM_JobPostings.ToList());
        }

        //
        // GET: /EM_JobPostings/Details/5

        public ViewResult Details(string id)
        {
            EM_JobPostings em_jobpostings = db.EM_JobPostings.Find(id);
            return View(em_jobpostings);
        }

        //
        // GET: /EM_JobPostings/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EM_JobPostings/Create

        [HttpPost]
        public ActionResult Create(EM_JobPostings em_jobpostings)
        {
            if (ModelState.IsValid)
            {
                db.EM_JobPostings.Add(em_jobpostings);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(em_jobpostings);
        }
        
        //
        // GET: /EM_JobPostings/Edit/5
 
        public ActionResult Edit(string id)
        {
            EM_JobPostings em_jobpostings = db.EM_JobPostings.Find(id);
            return View(em_jobpostings);
        }

        //
        // POST: /EM_JobPostings/Edit/5

        [HttpPost]
        public ActionResult Edit(EM_JobPostings em_jobpostings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(em_jobpostings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(em_jobpostings);
        }

        //
        // GET: /EM_JobPostings/Delete/5
 
        public ActionResult Delete(string id)
        {
            EM_JobPostings em_jobpostings = db.EM_JobPostings.Find(id);
            return View(em_jobpostings);
        }

        //
        // POST: /EM_JobPostings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            EM_JobPostings em_jobpostings = db.EM_JobPostings.Find(id);
            db.EM_JobPostings.Remove(em_jobpostings);
            db.SaveChanges();
            return RedirectToAction("~/Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}