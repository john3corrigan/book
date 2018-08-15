using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibraryDataAccess.DataObjects;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using UtilityLogger;

namespace BookLibraryDataAccess
{
    public class UserDataAccess
    {
        static string _ConnectionString = ConfigurationManager.ConnectionStrings["BookLibraryDB"].ConnectionString;
        static ErrorLogger _Logger = new ErrorLogger();

        public void CreateUser(UserAccountDAO _userToAdd)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_InsertUserAccount", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@UserName", _userToAdd.Username);
                        _command.Parameters.AddWithValue("@Password", _userToAdd.Password);
                        _command.Parameters.AddWithValue("@RoleID", _userToAdd.UserRole.RoleID);
                        _connection.Open();
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }
        }

        public void CreateUserInformation(UserInformationDAO _userInformationToAdd)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_InsertUserInformation", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@UserID", _userInformationToAdd.fk_UserID);
                        _command.Parameters.AddWithValue("@FirstName", _userInformationToAdd.FirstName);
                        _command.Parameters.AddWithValue("@LastName", _userInformationToAdd.LastName);

                        _connection.Open();
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }
        }

        public void UploadUserPicture(int userID, string filePath)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateUserPhotoPath", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@UserID", userID);
                        _command.Parameters.AddWithValue("@PhotoPath", filePath);

                        _connection.Open();
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }
        }

        public List<UserAccountDAO> GetAllUsers()
        {
            List<UserAccountDAO> _listAllUsers = new List<UserAccountDAO>();
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_GetAllUserAccounts", _connection))
                    {
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                UserAccountDAO _dUser = new UserAccountDAO();
                                _dUser.UserID = _reader.GetInt32(0);
                                _dUser.Username = _reader.GetString(1);
                                _dUser.UserRole.RoleID = _reader.GetInt32(2);


                                _listAllUsers.Add(_dUser);
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }

            return _listAllUsers;
        }

        public void UpdateUser(UserAccountDAO _userToUpdate)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateUser", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@UserID", _userToUpdate.UserID);
                        _command.Parameters.AddWithValue("@UserName", _userToUpdate.Username);
                        _command.Parameters.AddWithValue("@Password", _userToUpdate.Password);

                        _connection.Open();
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }
        }

        public void DeleteUser(int UserID)
        {
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_RemoveUser", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;

                        _command.Parameters.AddWithValue("@UserID", UserID);

                        _connection.Open();
                        _command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }
        }

        public UserAccountDAO GetUserByID(int UserID)
        {
            UserAccountDAO _userToReturn = new UserAccountDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_GetUserByID", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@UserID", UserID);
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _userToReturn.UserID = _reader.GetInt32(0);
                                _userToReturn.Username = _reader.GetString(1);
                                _userToReturn.Password = _reader.GetString(2);
                                _userToReturn.UserRole.RoleID = _reader.GetInt32(3);
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }

            return _userToReturn;
        }

        public UserAccountDAO GetAccountByUserName(string UserName)
        {
            UserAccountDAO _userToReturn = new UserAccountDAO();
            try
            {
                using (SqlConnection _connection = new SqlConnection(_ConnectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_GetAccountByUserName", _connection))
                    {
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@UserName", UserName);
                        _connection.Open();
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _userToReturn.UserID = _reader.GetInt32(0);
                                _userToReturn.Username = _reader.GetString(1);
                                _userToReturn.Password = _reader.GetString(2);
                                _userToReturn.UserRole.RoleID = _reader.GetInt32(3);
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }
            finally
            {

            }

            return _userToReturn;
        }
    }
}
