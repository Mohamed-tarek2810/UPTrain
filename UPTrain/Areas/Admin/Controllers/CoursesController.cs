using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UPTrain.IRepositories;
using UPTrain.Models;

namespace UPTrain.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly UserManager<User> _userManager;

        public CoursesController(ICourseRepository courseRepo, UserManager<User> userManager)
        {
            _courseRepo = courseRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepo.GetAllAsync(
                null,
                c => c.Lessons,
                c => c.Quizzes,
                c => c.Creator
            );

            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses course)
        {
            if (ModelState.IsValid)
            {
                course.CreatedBy = _userManager.GetUserId(User);

                await _courseRepo.AddAsync(course);
                var result = await _courseRepo.CommitAsync();

                if (result)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", "An error occurred while saving the course.");
            }

            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseRepo.GetOneAsync(c => c.CourseId == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Courses course)
        {
            if (id != course.CourseId)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _courseRepo.Update(course);
                var result = await _courseRepo.CommitAsync();

                if (result)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", "An error occurred while updating the course.");
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepo.GetOneAsync(c => c.CourseId == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _courseRepo.GetOneAsync(c => c.CourseId == id);
            if (course == null)
                return NotFound();

            await _courseRepo.Delete(course);
            var result = await _courseRepo.CommitAsync();

            if (result)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("", "An error occurred while deleting the course.");
            return View(course);
        }
    }
}
