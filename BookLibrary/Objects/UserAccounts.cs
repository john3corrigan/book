using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Objects
{
    public class UserAccounts
    {
        public string @Username { get; set; }
        public string @Password { get; set; }
        public int @UserID { get; set; }
        public string @FirstName { get; set; }
        public string @LastName { get; set; }
        public string @Address { get; set; }
        public string @City { get; set; }
        public int @ZipCode { get; set; }
        public string @Email { get; set; }
    }
}
