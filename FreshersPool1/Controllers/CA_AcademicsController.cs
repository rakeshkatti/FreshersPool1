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
    public class CA_AcademicsController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_Academics/

        public ViewResult Index()
        {
            var ca_academics = db.CA_Academics.Include(c => c.CA_PersonalData).Include(c => c.CO_College).Include(c => c.CO_College1).Include(c => c.MS_StreamMaster).Include(c => c.MS_StreamMaster1).Include(c => c.MS_StreamMaster2);
            return View(ca_academics.ToList());
        }

        //
        // GET: /CA_Academics/Details/5

        public ViewResult Details(int id)
        {
            CA_Academics ca_academics = db.CA_Academics.Find(id);
            return View(ca_academics);
        }

        //
        // GET: /CA_Academics/Create

        public ActionResult Create()
        {
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName");
            ViewBag.Tenth_School = new SelectList(db.CO_College, "CollegeID", "CollegeName");
            ViewBag.Inter_College = new SelectList(db.CO_College, "CollegeID", "CollegeName");
            ViewBag.Grad_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc");
            ViewBag.Inter_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc");
            ViewBag.PG_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc");
            return View();
        } 

        //
        // POST: /CA_Academics/Create

        [HttpPost]
        public ActionResult Create(CA_Academics ca_academics)
        {
            ca_academics.CandidateID = (int)Session["CandidateID"];
            if (ModelState.IsValid)
            {
                db.CA_Academics.Add(ca_academics);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_academics.CandidateID);
            ViewBag.Tenth_School = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Tenth_School);
            ViewBag.Inter_College = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Inter_College);
            ViewBag.Grad_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Grad_Stream);
            ViewBag.Inter_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Inter_Stream);
            ViewBag.PG_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.PG_Stream);
            return View(ca_academics);
        }
        
        //
        // GET: /CA_Academics/Edit/5
 
        public ActionResult Edit(int id)
        {
            CA_Academics ca_academics = db.CA_Academics.Find(id);
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_academics.CandidateID);
            ViewBag.Tenth_School = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Tenth_School);
            ViewBag.Inter_College = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Inter_College);
            ViewBag.Grad_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Grad_Stream);
            ViewBag.Inter_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Inter_Stream);
            ViewBag.PG_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.PG_Stream);
            return View(ca_academics);
        }

        //
        // POST: /CA_Academics/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_Academics ca_academics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_academics).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.CA_PersonalData, "CandidateID", "FirstName", ca_academics.CandidateID);
            ViewBag.Tenth_School = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Tenth_School);
            ViewBag.Inter_College = new SelectList(db.CO_College, "CollegeID", "CollegeName", ca_academics.Inter_College);
            ViewBag.Grad_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Grad_Stream);
            ViewBag.Inter_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.Inter_Stream);
            ViewBag.PG_Stream = new SelectList(db.MS_StreamMaster, "StreamID", "StreamDesc", ca_academics.PG_Stream);
            return View(ca_academics);
        }

        //
        // GET: /CA_Academics/Delete/5
 
        public ActionResult Delete(int id)
        {
            CA_Academics ca_academics = db.CA_Academics.Find(id);
            return View(ca_academics);
        }

        //
        // POST: /CA_Academics/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CA_Academics ca_academics = db.CA_Academics.Find(id);
            db.CA_Academics.Remove(ca_academics);
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