using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibraryV2.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public UserAccount()
        {
            UserRole = new UserRole();
        }
    }
}