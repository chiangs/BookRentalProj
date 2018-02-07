using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookRentalProj.Models;

namespace BookRentalProj.ViewModels
{
    public class ThumbnailBoxViewModel
    {
        public IEnumerable<Thumbnail> Thumbnails { get; set; }
    }
}