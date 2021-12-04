using ClassManagement.Models;
using ClassManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClassManagement.Controllers
{
    public class CourseController : Controller
    {

        private ClassManagementContext _context;

        public CourseController()
        {
            _context = new ClassManagementContext();
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public ActionResult Create()
        {
            return View(new Course { Id = 0});
        }

        [HttpPost]
        public ActionResult Create(Course course) 
        {
            if (!ModelState.IsValid)
                return View("Create", course);

            if (course.Id == 0)
                _context.Courses.Add(course);                           // Add
            else
                _context.Entry(course).State = EntityState.Modified;    // Update

            _context.SaveChanges();
            TempData["Message"] = "Saved Succesfully !";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var existingCourse = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (existingCourse == null)
                return HttpNotFound();

            _context.Courses.Remove(existingCourse);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var existingCourse = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (existingCourse == null)
                return HttpNotFound();

            return View("Create", existingCourse);

        }

        public ActionResult Search(string search)
        {
            var filteredCourses = _context.Courses.Where(c => c.Name.Contains(search)).ToList();
            return View("index", filteredCourses);
        }


        // CourseRegistartions Actions :

        // To Apply for a course
        public ActionResult ApplyForCourse(int? id)
        {
            // If user not logged in then redirect to login page.
            if (Session["userId"] == null)
                return RedirectToAction("Login", "User");

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var userId = Convert.ToInt32(Session["userId"]);
            var courseId = (int)id;
            var statusId = 1;                   // Default status is pending

            var courseRegistration = new CourseRegistration()
            { 
                UserId = userId,
                CourseId = courseId,
                StatusId = statusId
            };

            _context.CourseRegistrations.Add(courseRegistration);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
        // To view subscription
        public ActionResult Subscription()
        {

            var viewModel = _context.CourseRegistrations
                                    .Include(c => c.Course)
                                    .Include(c => c.User)
                                    .Include(c => c.Status)
                                    .ToList();

            return View(viewModel);
        }

        // To edit subscription
        public ActionResult EditSubscription(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var existingSubscription = _context.CourseRegistrations
                                                    .Include(c => c.User)
                                                    .Include(c => c.Course)
                                                    .Include(c => c.Status)
                                                    .SingleOrDefault(c => c.Id == id);

            if (existingSubscription == null)
                return HttpNotFound();

            var viewModel = new SubscriptionViewModel()
            {
                CourseRegistration = existingSubscription,
                Status = _context.Statuses.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditSubscription(SubscriptionViewModel item)
        {

            var existingItem = _context.CourseRegistrations
                                       .Include(c => c.Course)
                                       .Include(c => c.User)
                                       .Include(c => c.Status)
                                       .SingleOrDefault(c => c.Id == item.CourseRegistration.Id);
            
            //from c in _context.CourseRegistrations
            //where c.Id == item.Id
            //select c;


            existingItem.StatusId = item.CourseRegistration.StatusId;

            //_context.Entry(item).State = EntityState.Modified;

            //try
            //{
                _context.SaveChanges();
            //}
            //catch (Exception e)
           // {
            //    Console.WriteLine(e);
            //}


            return RedirectToAction("Subscription");
        }

        // To Cancel subscription
        public ActionResult Cancel(CourseRegistration item)
        {
           // Perform edit operation...and set statusid as 1 (Cancelled)     
           // Fetch userId and courseId to cancel subscription

            return RedirectToAction("Subscription");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            
            base.Dispose(disposing);
        }

    }
}