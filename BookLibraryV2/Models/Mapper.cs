using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookLibraryDataAccess.DataObjects;

namespace BookLibraryV2.Models
{
    public class Mapper
    {
        public UserAccountDAO Map(UserAccount _userToMap)
        {
            UserAccountDAO _userToReturn = new UserAccountDAO();

            _userToReturn.UserID = _userToMap.UserID;
            _userToReturn.Username = _userToMap.Username;
            _userToReturn.Password = _userToMap.Password;

            _userToReturn.UserRole.RoleID = _userToMap.UserRole.RoleID;
            _userToReturn.UserRole.RoleDescription = _userToMap.UserRole.RoleDescription;
            return _userToReturn;
        }

        public UserInformationDAO Map(UserInformation _infoToMap)
        {
            UserInformationDAO _infoToReturn = new UserInformationDAO();
            _infoToReturn.fk_UserID = _infoToMap.fk_UserID;
            _infoToReturn.FirstName = _infoToMap.FirstName;
            _infoToReturn.LastName = _infoToMap.LastName;
            _infoToReturn.PhotoPath = _infoToMap.PhotoPath;
            return _infoToReturn;
        }

        public UserAccount Map(UserAccountDAO _userToMap)
        {
            UserAccount _userToReturn = new UserAccount();

            _userToReturn.UserID = _userToMap.UserID;
            _userToReturn.Username = _userToMap.Username;
            _userToReturn.Password = _userToMap.Password;
            _userToReturn.UserRole.RoleID = _userToMap.UserRole.RoleID;
            _userToReturn.UserRole.RoleDescription = _userToMap.UserRole.RoleDescription;
            return _userToReturn;
        }

        public List<UserAccount> Map(List<UserAccountDAO> _userListToMap)
        {
            List<UserAccount> _userListToReturn = new List<UserAccount>();

            foreach (UserAccountDAO _userToMap in _userListToMap)
            {
                UserAccount _userToReturn = new UserAccount();

                _userToReturn.UserID = _userToMap.UserID;
                _userToReturn.Username = _userToMap.Username;
                _userToReturn.Password = _userToMap.Password;

                _userToReturn.UserRole.RoleID = _userToMap.UserRole.RoleID;
                _userToReturn.UserRole.RoleDescription = _userToMap.UserRole.RoleDescription;
                _userListToReturn.Add(_userToReturn);
            }

            return _userListToReturn;
        }
    }
}