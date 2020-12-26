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
    }
  
}