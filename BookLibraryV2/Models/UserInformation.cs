using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibraryV2.Models
{
    public class UserInformation
    {
        public int fk_UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoPath { get; set; }
    }
}