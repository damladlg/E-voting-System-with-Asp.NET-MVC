using E_voting.Models;
using E_voting.Models.DataContext;
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
            var sorgu = db.Voter.ToList();
            return View(sorgu);
        }
    }
}