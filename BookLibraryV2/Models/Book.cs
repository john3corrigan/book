using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibraryV2.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookNumber { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
    }
}