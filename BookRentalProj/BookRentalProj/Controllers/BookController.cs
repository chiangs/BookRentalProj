using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookRentalProj.Models;
using BookRentalProj.ViewModels;

// Created using add Controller as MVC 5 with Entity Framework
namespace BookRentalProj.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        public ActionResult Index()
        {
            //Include eagerly loads genres of the books
            var books = db.Books.Include(b => b.Genre);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            // add the model from the BookViewModel to avoid using ViewBag
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };

            // return the model now, instead of just the book
            return View(model);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            //ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            //get the genre and then create the new BookViewModel
            var genre = db.Genres.ToList();
            var model = new BookViewModel
            {
                Genres = genre
            };
            return View(model);
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ISBN,Title,Author,Description,ImageUrl,Availability,Price,DateAdded,GenreId,PublicationDate,Pages,ProductDimensions")] Book book)
        //do not use this magic string method because it will break if you change the string and forget to update here
        public ActionResult Create(BookViewModel bookVM)
        {
            //manually assigning the bookVM properties to create into a book obj
            var book = new Book
            {
                Author = bookVM.Book.Author,
                Availability = bookVM.Book.Availability,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                GenreId = bookVM.Book.GenreId,
                ISBN = bookVM.Book.ISBN,
                Genre = bookVM.Book.Genre,
                ImageUrl = bookVM.Book.ImageUrl,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                ProductDimensions = bookVM.Book.ProductDimensions,
                PublicationDate = bookVM.Book.PublicationDate,
                Title = bookVM.Book.Title
            };

            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", book.GenreId);
            //instead of using ViewBag, use ViewModel by creating a folder. VM is a collection of models that is strictly associated with a specific view
            //get the list of genres from the VM and return the vm instead of the book
            bookVM.Genres = db.Genres.ToList();
            return View(bookVM);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            }; return View(model);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookVM)
        {
            var book = new Book
            {
                // need Id this time because it needs to know which one is being edited unlike create()
                Id = bookVM.Book.Id,
                Author = bookVM.Book.Author,
                Availability = bookVM.Book.Availability,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                GenreId = bookVM.Book.GenreId,
                ISBN = bookVM.Book.ISBN,
                Genre = bookVM.Book.Genre,
                ImageUrl = bookVM.Book.ImageUrl,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                ProductDimensions = bookVM.Book.ProductDimensions,
                PublicationDate = bookVM.Book.PublicationDate,
                Title = bookVM.Book.Title
            };

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            bookVM.Genres = db.Genres.ToList();

            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };
            return View(model);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
