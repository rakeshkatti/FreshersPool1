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
    public class CA_PlacementHistoryController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();

        //
        // GET: /CA_PlacementHistory/

        public ViewResult Index()
        {
            var ca_placementhistory = db.CA_PlacementHistory.Include(c => c.MS_DriveMaster).Include(c => c.MS_ResultMaster);
            return View(ca_placementhistory.ToList());
        }

        //
        // GET: /CA_PlacementHistory/Details/5

        public ViewResult Details(string id)
        {
            CA_PlacementHistory ca_placementhistory = db.CA_PlacementHistory.Find(id);
            return View(ca_placementhistory);
        }

        //
        // GET: /CA_PlacementHistory/Create

        public ActionResult Create()
        {
            ViewBag.DriveType = new SelectList(db.MS_DriveMaster, "DriveType", "DriveType");
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result");
            return View();
        } 

        //
        // POST: /CA_PlacementHistory/Create

        [HttpPost]
        public ActionResult Create(CA_PlacementHistory ca_placementhistory)
        {
            if (ModelState.IsValid)
            {
                db.CA_PlacementHistory.Add(ca_placementhistory);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DriveType = new SelectList(db.MS_DriveMaster, "DriveType", "DriveType", ca_placementhistory.DriveType);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", ca_placementhistory.Result);
            return View(ca_placementhistory);
        }
        
        //
        // GET: /CA_PlacementHistory/Edit/5
 
        public ActionResult Edit(string id)
        {
            CA_PlacementHistory ca_placementhistory = db.CA_PlacementHistory.Find(id);
            ViewBag.DriveType = new SelectList(db.MS_DriveMaster, "DriveType", "DriveType", ca_placementhistory.DriveType);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", ca_placementhistory.Result);
            return View(ca_placementhistory);
        }

        //
        // POST: /CA_PlacementHistory/Edit/5

        [HttpPost]
        public ActionResult Edit(CA_PlacementHistory ca_placementhistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ca_placementhistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriveType = new SelectList(db.MS_DriveMaster, "DriveType", "DriveType", ca_placementhistory.DriveType);
            ViewBag.Result = new SelectList(db.MS_ResultMaster, "Result", "Result", ca_placementhistory.Result);
            return View(ca_placementhistory);
        }

        //
        // GET: /CA_PlacementHistory/Delete/5
 
        public ActionResult Delete(string id)
        {
            CA_PlacementHistory ca_placementhistory = db.CA_PlacementHistory.Find(id);
            return View(ca_placementhistory);
        }

        //
        // POST: /CA_PlacementHistory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            CA_PlacementHistory ca_placementhistory = db.CA_PlacementHistory.Find(id);
            db.CA_PlacementHistory.Remove(ca_placementhistory);
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