using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookRentalProj.Models;


// This is an extension, so class and funcs need to be STATIC
// Enable the index view model of thumbnail to call this method to and display thumbnails
namespace BookRentalProj.Extensions
{
    public static class ThumbnailExtension
    {
        public static IEnumerable<Thumbnail> GetBookThumbnail(this List<Thumbnail> thumbnails, ApplicationDbContext db=null, string search = null)
        {
            try
            {
            // retrieve the db as obj
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }

                // assign list thumb from each book in db.books, then select new Thumbnail which has props then converted to list
                thumbnails = (from b in db.Books
                    select new Thumbnail
                    {
                        BookId = b.Id,
                        Title = b.Title,
                        Description = b.Description,
                        ImageUrl = b.ImageUrl,
                        Link = "/Book/Details/" + b.Id
                    }
                ).ToList();

                if (search != null)
                    return thumbnails.Where(s => s.Title.ToLower().Contains(search.ToLower()) || s.Description.ToLower().Contains(search.ToLower())).OrderBy(s => s.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            // return the list
            return thumbnails.OrderBy(b => b.Title);
        }
    }
}