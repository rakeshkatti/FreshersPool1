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
    public class CA_SkillsController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_Skills/

        public ViewResult Index()
        {
            var ca_skills = db.CA_Skills.Include(c => c.CA_PersonalData).Include(c => c.MS_SkillLevelMaster).Include(c => c.MS_SkillMaster);
            return View(ca_skills.ToList());
        }

        //
        // GET: /CA_Skills/Details/5

        public ViewResult Details(string id)
        {
            CA_Skills ca_skills = db.CA_Skills.Find(id);
            return View(ca_skills);
        }

        //
        // GET: /CA_Skills/Create

        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            ViewBag.SkillLevelID = new SelectList(db.MS_SkillLevelMaster, "SkillLevelID", "SkillDesc");
            ViewBag.SkillID = new SelectList(db.MS_SkillMaster, "SkillID", "SkillDesc");
            return View();
        } 

        //
        // POST: /CA_Skills/Create

        [HttpPost]
        public ActionResult Create(CA_Skills ca_skills)
        {
            if (ModelState.IsValid)
            {
                db.CA_Skills.Add(ca_skills);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_skills.CandidateID);
            ViewBag.SkillLevelID = new SelectList(db.MS_SkillLevelMaster, "SkillLevelID", "SkillDesc", ca_skills.SkillLevelID);
            ViewBag.SkillID = new SelectList(db.MS_SkillMaster, "SkillID", "SkillDesc", ca_skills.SkillID);
            return View(ca_skills);
        }
        
        //
        // GET: /CA_Skills/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_Skills ca_skills = db.CA_Skills.Find(id);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_skills.CandidateID);
            ViewBag.SkillLevelID = new SelectList(db.MS_SkillLevelMaster, "SkillLevelID", "SkillDesc", ca_skills.SkillLevelID);
            ViewBag.SkillID = new SelectList(db.MS_SkillMaster, "SkillID", "SkillDesc", ca_skills.SkillID);
            return View(ca_skills);
        }

        //
        // POST: /CA_Skills/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_Skills ca_skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_skills.CandidateID);
            ViewBag.SkillLevelID = new SelectList(db.MS_SkillLevelMaster, "SkillLevelID", "SkillDesc", ca_skills.SkillLevelID);
            ViewBag.SkillID = new SelectList(db.MS_SkillMaster, "SkillID", "SkillDesc", ca_skills.SkillID);
            return View(ca_skills);
        }

        //
        // GET: /CA_Skills/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_Skills ca_skills = db.CA_Skills.Find(id);
            return View(ca_skills);
        }

        //
        // POST: /CA_Skills/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_Skills ca_skills = db.CA_Skills.Find(id);
            db.CA_Skills.Remove(ca_skills);
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