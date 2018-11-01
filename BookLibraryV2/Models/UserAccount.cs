using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryV2.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression("[A-Z]*")]
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public UserAccount()
        {
            UserRole = new UserRole();
        }
    }
}