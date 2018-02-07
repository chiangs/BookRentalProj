using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookRentalProj.Models
{
    public class Thumbnail
    {
        // int id; strings title, desc, url, link
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}