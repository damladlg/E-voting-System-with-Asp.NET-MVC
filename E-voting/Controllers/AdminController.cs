using E_voting.Models;
using E_voting.Models.DataContext;
using E_voting.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class AdminController : Controller
    {
        EvotingDBContext db = new EvotingDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.VoterCount = db.Voter.Count();
            ViewBag.ResultCount = db.Result.Count();
            ViewBag.PositionCount = db.Position.Count();
            ViewBag.CandidateCount = db.Candidate.Count();
            //ViewBag.VoterCount=db.Voter.Where(x=>x.VoterId).cou
            var sorgu = db.Voter.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if ((login.Email == admin.Email) && (login.Password == admin.Password))
            {
                Session["adminid"] = login.AdminId;
                Session["email"] = login.Email;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Wrong password or name";
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["email"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}