using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookLibraryV2.Models;
using BookLibraryDataAccess;
using BookBusinessLayer;
using System.IO;

namespace BookLibraryV2.Controllers
{
    public class UserController : Controller
    {
        static UserDataAccess _UserDataAccess = new UserDataAccess();
        static Mapper _Mapper = new Mapper();
        static PasswordLogic _PasswordLogic = new PasswordLogic();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel _viewModel)
        {
            _viewModel.UserAccount.Password = _PasswordLogic.HashPassword(_viewModel.UserAccount.Password);
            _viewModel.UserAccount.UserRole.RoleID = 1;
            _UserDataAccess.CreateUser(_Mapper.Map(_viewModel.UserAccount));
            return View("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel _viewModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount _validateUser = new UserAccount();
                _validateUser = _Mapper.Map(_UserDataAccess.GetAccountByUserName(_viewModel.UserAccount.Username));
                bool isValid = _PasswordLogic.ValidatePasswords(_viewModel.UserAccount.Password, _validateUser.Password);
                if (isValid)
                {
                    Session["UserID"] = _validateUser.UserID;
                    Session["UserName"] = _validateUser.Username;
                    Session["UserRole"] = _validateUser.UserRole.RoleID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or Password were incorrect.");
                    return View();
                }
            }
            else {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewUploadPicture()
        {
            return View("UploadPicture");
        }

        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase _uploadedFile)
        {
            string pathToSaveTo = Path.Combine(Server.MapPath("/Images/"), _uploadedFile.FileName);
            _uploadedFile.SaveAs(pathToSaveTo);
            _UserDataAccess.UploadUserPicture((int)Session["UserID"], pathToSaveTo + _uploadedFile.FileName);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreateUserInformation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUserInformation(UserViewModel _viewModel)
        {
            _viewModel.UserInformation.fk_UserID = (int)Session["UserID"];
            _UserDataAccess.CreateUserInformation(_Mapper.Map(_viewModel.UserInformation));
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ViewUsers()
        {
            ActionResult result;
            //if ((long)Session["roleid"] == 1)
            //{
                UserViewModel _viewModel = new UserViewModel();
                _viewModel.UserList = _Mapper.Map(_UserDataAccess.GetAllUsers());
                result = View(_viewModel);
            //}
            //else {
            //    result = RedirectToAction("Login", "User");
            //}
            return result;

        }

        [HttpGet]
        public ActionResult UpdateUser(int UserID)
        {
            UserViewModel _userViewModel = new UserViewModel();
            _userViewModel.UserAccount = _Mapper.Map(_UserDataAccess.GetUserByID(UserID));
            return View(_userViewModel);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserViewModel _userViewModel)
        {
            _UserDataAccess.UpdateUser(_Mapper.Map(_userViewModel.UserAccount));
            return RedirectToAction("ViewUsers");
        }

        public ActionResult DeleteUser(int UserID)
        {
            _UserDataAccess.DeleteUser(UserID);
            return RedirectToAction("ViewUsers");
        }
    }
}