using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookRentalProj.Models;

namespace BookRentalProj.ViewModels
{
    public class BookViewModel
    // This is the collection of models requires for the Book View [Genre, Book]
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
    }
}