using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Objects
{
    public class BookTable
    {
        public int @BookID { get; set; }
        public string @BookNumber { get; set; }
        public string @BookName { get; set; }
        public string @Author { get; set; }
        public int @Quantity { get; set; }
    }
}
