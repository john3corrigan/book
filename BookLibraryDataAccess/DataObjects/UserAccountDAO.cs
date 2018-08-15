using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryDataAccess.DataObjects
{
    public class UserAccountDAO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRoleDAO UserRole { get; set; }

        public UserAccountDAO()
        {
            UserRole = new UserRoleDAO();
        }
    }
}
