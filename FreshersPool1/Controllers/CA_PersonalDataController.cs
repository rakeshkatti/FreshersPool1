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
    public class CA_PersonalDataController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_PersonalData/

        public ViewResult Index()
        {
            return View(db.CA_PersonalData.ToList());
        }

        //
        // GET: /CA_PersonalData/Details/5

        public ViewResult Details(int id)
        {
            CA_PersonalData ca_personaldata = db.CA_PersonalData.Find(id);
            return View(ca_personaldata);
        }

        //
        // GET: /CA_PersonalData/Create

        public ActionResult Create()
        {
            ViewBag.MotherTongue = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language");
            return View();
        } 

        //
         //POST: /CA_PersonalData/Create

        [HttpPost]
        public ActionResult Create(CA_PersonalData ca_personaldata)
        {
            ca_personaldata.CandidateID = (int)Session["CandidateID"];
            if (ModelState.IsValid)
            {   
                db.CA_PersonalData.Add(ca_personaldata);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            ViewBag.MotherTongue = new SelectList(db.MS_LanguageMaster, "LanguageID", "Language", ca_personaldata.MotherTongue);

            return View(ca_personaldata);
        }
        
        
        // GET: /CA_PersonalData/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_PersonalData ca_personaldata = db.CA_PersonalData.Find(id);
            return View(ca_personaldata);
        }

        //
        // POST: /CA_PersonalData/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_PersonalData ca_personaldata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_personaldata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ca_personaldata);
        }

        //
        // GET: /CA_PersonalData/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_PersonalData ca_personaldata = db.CA_PersonalData.Find(id);
            return View(ca_personaldata);
        }

        //
        // POST: /CA_PersonalData/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_PersonalData ca_personaldata = db.CA_PersonalData.Find(id);
            db.CA_PersonalData.Remove(ca_personaldata);
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