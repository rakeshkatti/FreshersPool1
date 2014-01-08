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
    public class CA_LanguagesController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_Languages/

        public ViewResult Index()
        {
            var ca_languages = db.CA_Languages.Include(c => c.MS_LanguageMaster).Include(c => c.CA_PersonalData);
            return View(ca_languages.ToList());
        }

        //
        // GET: /CA_Languages/Details/5

        public ViewResult Details(string id)
        {
            CA_Languages ca_languages = db.CA_Languages.Find(id);
            return View(ca_languages);
        }

        //
        // GET: /CA_Languages/Create

        public ActionResult Create()
        {
            ViewBag.LanguageID = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language");
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            return View();
        } 

        //
        // POST: /CA_Languages/Create

        [HttpPost]
        public ActionResult Create(CA_Languages ca_languages)
        {
            if (ModelState.IsValid)
            {
                db.CA_Languages.Add(ca_languages);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.LanguageID = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language", ca_languages.LanguageID);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_languages.CandidateID);
            return View(ca_languages);
        }
        
        //
        // GET: /CA_Languages/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_Languages ca_languages = db.CA_Languages.Find(id);
            ViewBag.LanguageID = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language", ca_languages.LanguageID);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_languages.CandidateID);
            return View(ca_languages);
        }

        //
        // POST: /CA_Languages/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_Languages ca_languages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_languages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageID = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language", ca_languages.LanguageID);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_languages.CandidateID);
            return View(ca_languages);
        }

        //
        // GET: /CA_Languages/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_Languages ca_languages = db.CA_Languages.Find(id);
            return View(ca_languages);
        }

        //
        // POST: /CA_Languages/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_Languages ca_languages = db.CA_Languages.Find(id);
            db.CA_Languages.Remove(ca_languages);
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