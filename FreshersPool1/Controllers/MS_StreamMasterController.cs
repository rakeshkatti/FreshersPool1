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
    public class MS_StreamMasterController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /MS_StreamMaster/

        public ViewResult Index()
        {
            return View(db.MS_StreamMaster.ToList());
        }

        //
        // GET: /MS_StreamMaster/Details/5

        public ViewResult Details(string id)
        {
            MS_StreamMaster ms_streammaster = db.MS_StreamMaster.Find(id);
            return View(ms_streammaster);
        }

        //
        // GET: /MS_StreamMaster/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /MS_StreamMaster/Create

        [HttpPost]
        public ActionResult Create(MS_StreamMaster ms_streammaster)
        {
            if (ModelState.IsValid)
            {
                db.MS_StreamMaster.Add(ms_streammaster);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(ms_streammaster);
        }
        
        //
        // GET: /MS_StreamMaster/Edit/5
 
        public ActionResult Edit(string id)
        {
            MS_StreamMaster ms_streammaster = db.MS_StreamMaster.Find(id);
            return View(ms_streammaster);
        }

        //
        // POST: /MS_StreamMaster/Edit/5

        [HttpPost]
        public ActionResult Edit(MS_StreamMaster ms_streammaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ms_streammaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ms_streammaster);
        }

        //
        // GET: /MS_StreamMaster/Delete/5
 
        public ActionResult Delete(string id)
        {
            MS_StreamMaster ms_streammaster = db.MS_StreamMaster.Find(id);
            return View(ms_streammaster);
        }

        //
        // POST: /MS_StreamMaster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            MS_StreamMaster ms_streammaster = db.MS_StreamMaster.Find(id);
            db.MS_StreamMaster.Remove(ms_streammaster);
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