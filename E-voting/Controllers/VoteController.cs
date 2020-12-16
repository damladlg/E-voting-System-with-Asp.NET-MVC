using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult Index()
        {
            return View();
        }
    }
}