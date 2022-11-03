using MVCnewProject.Data;
using MVCnewProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCnewProject.Controllers
{
    public class StudentCtlController : Controller
    {
        private readonly ApplicationDbContext context;
        public StudentCtlController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: StudentCtl
        public ViewResult Index()
        {
            var studentList = context.Students.ToList();
            return View(studentList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewStudent(Student student)
        {
            if (student == null) return HttpNotFound();
            if (!ModelState.IsValid) return View("Create");

           // Duplicate Email
           var duplicateEmail = context.Students.FirstOrDefault(x => x.Email == student.Email);
            if (duplicateEmail != null)
            {
                ModelState.AddModelError("Email", "This email is already exist!");
                return View("Create");
            }

            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            var studentInDb = context.Students.Find(id);
            if(studentInDb == null) return HttpNotFound();
            return View(studentInDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (student == null) return HttpNotFound();
            if(!ModelState.IsValid) return View(student);
            var studentInDb = context.Students.Find(student.Id);
            if (studentInDb == null) return HttpNotFound();

           //duplicate email
           var duplicateEmail = context.Students.FirstOrDefault(s => s.Email== student.Email);
           var emails = context.Students.Find(student.Id);
            if(duplicateEmail != null)
            {
                if(!(duplicateEmail.Email == emails.Email && duplicateEmail.Id == emails.Id))
                {
                    ModelState.AddModelError("Email", "Email is already exist!");
                    return View();
                }
            }

            studentInDb.Name = student.Name;
            studentInDb.Address = student.Address;
            studentInDb.Age = student.Age;
            studentInDb.Email = student.Email;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var studentIn = context.Students.Find(id);
            if( studentIn == null) return HttpNotFound();
            return View(studentIn);
        }
        public ActionResult Delete(int id)
        {
            var studentIn = context.Students.Find(id);
            if(studentIn == null) return HttpNotFound();
            context.Students.Remove(studentIn);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}