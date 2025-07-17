using System.Diagnostics;
using CrudUsingADONet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingADONet.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentsDAL dal;


        public HomeController()
        {
            dal = new StudentsDAL();
        }

        public IActionResult Index()
        {
            List<Students> studs = dal.getAllStudents();
            return View(studs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Students stu)
        {
            try
            {
                dal.AddStudents(stu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int Id)
        {
             Students Stu = dal.getStudentById(Id);
            return View(Stu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Students stu)
        {
            try
            {
                dal.UpdateStudent(stu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            Students stu = dal.getStudentById(Id);
            return View(stu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Students stu)
        {
            try
            {
                dal.DeleteStudent(stu.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
