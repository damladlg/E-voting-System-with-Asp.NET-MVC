using E_voting.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_voting.Controllers
{
    public class ResultController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();
        // GET: Result
        public ActionResult Index() {
            db.Configuration.LazyLoadingEnabled = false;
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var item in db.Result.ToList())
            {
                int id = item.CandidateId;
                KeyValuePair<string, int> temp = new KeyValuePair<string, int>(id.ToString(), 1);
                if (counts.ContainsKey(id.ToString()))
                {
                    int index = Array.IndexOf(counts.Keys.ToArray(), id.ToString());

                    counts[id.ToString()] = counts[id.ToString()] + 1;
                }
                else
                    counts.Add(id.ToString(), 1);
            }
            int tempmax = counts.Values.Max();
            string tempkey = "";
            foreach (var item in counts)
            {
                if (item.Value == tempmax)
                {
                    tempkey = item.Key;
                    break;
                }
            }

            ViewBag.Message = "WINNER'S ID: "+ tempkey + " VOTE NUMBER OF THE WINNING CANDIDATE: " + tempmax.ToString();
            return View(db.Result.ToList());
        }

        /*Count*/
//        Dictionary<string, int> counts = new Dictionary<string, int>();
//            foreach (var item in db.Result.ToList())
//            {
//                int id = item.CandidateId;
//        KeyValuePair<string, int> temp = new KeyValuePair<string, int>(id.ToString(), 1);
//                if (counts.ContainsKey(id.ToString()))
//                {
//                    int index = Array.IndexOf(counts.Keys.ToArray(), id.ToString());

//        counts[id.ToString()] = counts[id.ToString()] + 1;
//                }
//                else
//                    counts.Add(id.ToString(), 1);                
//            }
//        int tempmax = counts.Values.Max();

    }
}
