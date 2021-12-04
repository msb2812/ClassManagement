using ClassManagement.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassManagement.ViewModels;
using System.Net;

namespace ClassManagement.Controllers
{
    public class UserController : Controller
    {

        private ClassManagementContext _contex;

        public UserController()
        {
            _contex = new ClassManagementContext();
        }

        public ActionResult Index()
        {
            var users = _contex.Users.Include(u => u.Role).ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            // here need to create viewModel...bcoz we have to bind here dropdownlist 

            var user = new User();
            var role = _contex.Roles.ToList();

            var userFormViewModel = new UserFormViewModel()
            {
                User = user,
                Role = role
            };

            return View(userFormViewModel);
        }

        [HttpPost]      // Create/Register
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View("Create", user);

            if (user.Id == 0)
                _contex.Users.Add(user);
            else
                _contex.Entry(user).State = EntityState.Modified;

            _contex.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var existingUser = _contex.Users.SingleOrDefault(u => u.Id == id);

            if (existingUser == null)
                return HttpNotFound();

            _contex.Users.Remove(existingUser);
            _contex.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var existingUser = _contex.Users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
                return HttpNotFound();

            var role = _contex.Roles.ToList();

            var userFormViewModel = new UserFormViewModel()
            {
                User = existingUser,
                Role = role
            };

            return View("Create", userFormViewModel);
        } 


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel user) 
        {
            if (!ModelState.IsValid)
                return View("Login", user);

            var loggedUser = _contex.Users.Include(u => u.Role).Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                             // Here Include is used to fetch role object which is relative object of user.

            if (loggedUser == null)
            {
                ModelState.AddModelError("UserName", "UserName or Password is incorrect !");
                return View("Login", user);
            }
            else
            {
                var role = loggedUser.Role.Title;
                Session[role] = role;                   // Admin or User
                Session["userId"] = loggedUser.Id;
                return RedirectToAction("Index", "Home");
            }


        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _contex.Dispose();

            base.Dispose(disposing);
        }

    }
}