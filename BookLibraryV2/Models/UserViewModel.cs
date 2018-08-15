using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookLibraryV2.Models
{
    public class UserViewModel
    {
        public UserAccount UserAccount { get; set; }
        public UserInformation UserInformation { get; set; }
        public List<UserAccount> UserList { get; set; }
        public List<UserRole> AllRoles { get; set; }
        public UserViewModel()
        {
            UserAccount = new UserAccount();
            UserList = new List<UserAccount>();
        }
    }
}