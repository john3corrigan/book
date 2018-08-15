using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookBusinessLayer
{
    public class PasswordLogic
    {
        public string HashPassword(string _passwordToHash)
        {
            StringBuilder _passwordReturn = new StringBuilder();

            MD5 hash = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(_passwordToHash);
            byte[] hashedBytes = hash.ComputeHash(inputBytes);
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                _passwordReturn.Append(hashedBytes[i].ToString("X2"));
            }

            return _passwordReturn.ToString();
        }

        public bool ValidatePasswords(string _tempPassword, string _dbPassword)
        {
            bool isValid = false;

            _tempPassword = HashPassword(_tempPassword);

            if (_tempPassword == _dbPassword)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
