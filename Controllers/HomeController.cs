using Code_First_Approch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Code_First_Approch.Controllers
{
    public class HomeController : Controller
    {
        public StudentDBContext StudentDB { get; }

        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        //{
        // _logger = logger;
        //}
        public HomeController(StudentDBContext StudentDB)
        {
            this.StudentDB = StudentDB;
        }


        public async Task< IActionResult> Index()
        {
            var stdData= await  StudentDB.Students.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create(Student std)
        {

            if(ModelState.IsValid)
            {
              await StudentDB.Students.AddAsync(std);
             await StudentDB.SaveChangesAsync();
                TempData["insert success"] = "Inserted......";
                return RedirectToAction("Index","Home");
            }
            return View(std);

        }
        public async Task<IActionResult> Details(int ? id)
        {

            if(id==null || StudentDB.Students == null)
            {
                return NotFound();
            }
            var stdData = await StudentDB.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || StudentDB.Students == null)
            {
                return NotFound();
            }


            var stdData = await StudentDB.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id != std.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                StudentDB.Students.Update(std);
                await StudentDB.SaveChangesAsync();
                TempData["edit_success"] = "Edited......";

                return RedirectToAction("Index", "Home");
            }
            return View(std);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || StudentDB.Students == null)
            {
                return NotFound();
            }

            var stdData=await StudentDB.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if (stdData==null)
            {
                return NotFound();
            }
            return View(stdData);
        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await StudentDB.Students.FindAsync(id);
            if (stdData!=null)
            {
                StudentDB.Students.Remove(stdData);


            }
            await StudentDB.SaveChangesAsync();
            TempData["delete_success"] = "Deleted......";

            return RedirectToAction("Index","Home");


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
