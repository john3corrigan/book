using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibraryV2.Models
{
    public class BookViewModel
    {
        public Book SingleBook { get; set; }
        public List<Book> BookList { get; set; }
        public string FilePath { get; set; }

        public BookViewModel()
        {
            SingleBook = new Book();
            BookList = new List<Book>();
        }
    }
}