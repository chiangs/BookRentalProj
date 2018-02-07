using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookRentalProj.Models;
using BookRentalProj.Extensions;
using BookRentalProj.ViewModels;

namespace BookRentalProj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search = null)
        {
            // call the extension to load the list of thumbnails
            // get the count and section it off by rows of 4
            // set model to a new List of view models
            // add each vm to model to return
            var thumbnails = new List<Thumbnail>().GetBookThumbnail(ApplicationDbContext.Create(), search);
            var count = thumbnails.Count() / 4;
            var model = new List<ThumbnailBoxViewModel>();

            for (int i = 0; i <= count; i++)
            {
                model.Add(new ThumbnailBoxViewModel
                {
                    Thumbnails = thumbnails.Skip(i * 4).Take(4)
                });
            }
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}