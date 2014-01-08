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

    public class HomeController : Controller
    {
        private Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult Authenticate(string username, string password)
        {
            Team2_FRESHERSPOOLEntities ctx = new Team2_FRESHERSPOOLEntities();

            var result = from e1 in ctx.CA_PersonalData
                       where e1.Login == username && e1.Password == password
                       select e1;

            string fresher = null;
            int candidateId = 0;
            foreach (var s in result)
            {
                fresher = s.FirstName;
                candidateId = s.CandidateID;
            }

            if (fresher != null)
            {
                Session["IsLoggedIn"] = true;
                Session["UserName"] = fresher;
                Session["CandidateID"] = candidateId;
                Session["isFresher"] = true;
                return Redirect("~/Freshers/Index");
            }

            return Redirect("~/");

        }

        [HttpPost]
        public RedirectResult AuthenticateRecruiter(string username, string password)
        {
            Team2_FRESHERSPOOLEntities ctx = new Team2_FRESHERSPOOLEntities();

            var result = from e1 in ctx.EM_EmployerData
                       where e1.Login == username && e1.Password == password
                       select e1;

            string recruiter = null;
            int employerID = 0;
            foreach (var s in result)
            {
                employerID = s.EmployerID;
                recruiter = s.Name;
                
            }

            if (recruiter != null)
            {
                Session["IsLoggedIn"] = true;
                Session["UserName"] = recruiter;
                Session["employerID"] = employerID;
                Session["isRecruiter"] = true;
                return Redirect("~/Recruiters/Index");
            }

            return Redirect("~/Recruiters/Error");

        }
        [HttpPost]
        public ActionResult RegisterCandidate(CA_PersonalData ca_personaldata)
        {
            Team2_FRESHERSPOOLEntities db = new Team2_FRESHERSPOOLEntities();
            if (ModelState.IsValid)
            {
                db.CA_PersonalData.Add(ca_personaldata);
                db.SaveChanges();
            }

            return View(ca_personaldata);
        }

        [HttpPost]
        public RedirectResult SignOut()
        {
            Session.Clear();
            return Redirect("~/");
        }

    }
        
}
