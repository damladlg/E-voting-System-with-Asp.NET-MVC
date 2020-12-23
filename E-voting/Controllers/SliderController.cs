using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using E_voting.Models.DataContext;
using E_voting.Models.Model;

namespace E_voting.Controllers
{
    public class SliderController : Controller
    {
        private EvotingDBContext db = new EvotingDBContext();

        // GET: Slider
        public ActionResult Index()
        {
            return View(db.Slider.ToList());
        }

        // GET: Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Title,Explanation,PhotoURL")] Slider slider,HttpPostedFileBase PhotoURL)
        {
            if (ModelState.IsValid)
            {
                if (PhotoURL != null)
                {
                    WebImage img = new WebImage(PhotoURL.InputStream);
                    FileInfo imginfo = new FileInfo(PhotoURL.FileName);

                    string sliderimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1024, 360);      //slider a eklenecek resmin boyutuna göre
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    slider.PhotoURL = "/Uploads/Slider/" + sliderimgname;
                }
                db.Slider.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SliderId,Title,Explanation,PhotoURL")] Slider slider, HttpPostedFileBase PhotoURL,int id)
        {
            if (ModelState.IsValid)
            {
                var s = db.Slider.Where(x => x.SliderId == id).SingleOrDefault();
                if (PhotoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.PhotoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.PhotoURL));
                    }
                    WebImage img = new WebImage(PhotoURL.InputStream);
                    FileInfo imginfo = new FileInfo(PhotoURL.FileName);

                    string sliderimgname = PhotoURL.FileName + imginfo.Extension;
                    img.Resize(1024, 360);
                    img.Save("~/Uploads/Slider/" + sliderimgname);

                    s.PhotoURL = "/Uploads/Slider/" + sliderimgname;
                }

                s.Title = slider.Title;
                s.Explanation = slider.Explanation;                
                //s.PhotoURL = slider.PhotoURL;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Slider.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Slider.Find(id);

            if (System.IO.File.Exists(Server.MapPath(slider.PhotoURL)))
            {
                System.IO.File.Delete(Server.MapPath(slider.PhotoURL));
            }

            db.Slider.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
