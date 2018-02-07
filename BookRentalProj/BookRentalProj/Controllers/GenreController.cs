using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BookRentalProj.Models;

namespace BookRentalProj.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext db;

        // Create a new Database context to map class
        public GenreController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Genre
        // return all of the objects in Genres as a list to the view
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        // mvc4action snippet
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            //If required attributes of model are valid
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Details
        public ActionResult Details(int? id)
        {
            //Check if id is null, then return a Response, otherwise search the db and return the Genre obj if found
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        // GET: Edit
        public ActionResult Edit(int? id)
        {
            //Check if id is null, then return a Response, otherwise search the db and return the Genre obj if found
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }

            return View(genre);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            // if ModelState is valid then save the modified state to the current state of the entry, then return the index view
            if (ModelState.IsValid)
            {

                // If many columns, this is an expensive call, instead find the object from the db and assign each property you want to update
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // use id passed to find Genre object in db, remove it, save changes, and redirect to index action
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // de-allocate resource
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}