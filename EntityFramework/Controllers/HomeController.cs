using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext studentDB;

        public HomeController(StudentDbContext studentDB)
        {
            this.studentDB = studentDB;
        }

        public async Task<IActionResult> Index()
        {
            var students = await studentDB.Students.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDB.Students.AddAsync(std);
                await studentDB.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(std);
        }
        public async Task<IActionResult> Details(int? id)
        {
            var students = await studentDB.Students.FirstOrDefaultAsync(x=>x.Id == id);
            return View(students);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var students = await studentDB.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(students);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var students = await studentDB.Students.FindAsync(id);
            studentDB.Students.Remove(students);
            await studentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
         }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
