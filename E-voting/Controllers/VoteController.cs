using E_voting.Models;
using E_voting.Models.DataContext;
using E_voting.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class VoteController : Controller
    {
        EvotingDBContext db = new EvotingDBContext();
        // GET: Vote
        public ActionResult Index()
        {
            // ViewBag.Candidate = db.Candidate.ToList().OrderByDescending(x => x.CandidateId);
            return View();
        }
        public ActionResult VoteNow()
        {
            return View(db.Candidate.ToList().OrderByDescending(x => x.CandidateId));
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Voter voter)
        {
            var login = db.Voter.Where(x => x.Email == voter.Email).SingleOrDefault();
            if(login.Email==voter.Email && login.Password== Crypto.Hash(voter.Password, "MD5"))
            {
                Session["voterid"] = login.VoterId;
                Session["eposta"] = login.Email;
                return RedirectToAction("Index", "Vote");
            }
            ViewBag.Uyari = "Wrong password or email.";
            return View(voter);

        }
        public JsonResult ToVote( int candidate, int voter)
        {
            //if (candidate)
            //{
            //    return Json(true, JsonRequestBehavior.AllowGet);
            //}
            db.Result.Add(new Result {CandidateId = candidate, VoterId = voter });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
  
}