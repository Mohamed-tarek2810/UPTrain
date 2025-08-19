using Microsoft.AspNetCore.Mvc;
using UPTrain.IRepositories;
using UPTrain.Models;

namespace UPTrain.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

  
        public async Task<IActionResult> Courses()
        {
            var courses = await _courseRepository.GetAllAsync();
            return View(courses);
        }

      
        public async Task<IActionResult> CoursesDetails(int id)
        {
            var course = await _courseRepository.GetAsync(c => c.CourseId == id);
            if (course == null)
                return NotFound();

            return View(course);
        }

       
        //public IActionResult Create()
        //{
        //    return View();
        //}

    
        //[HttpPost]
       
        //public async Task<IActionResult> Create(Courses course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _courseRepository.AddAsync(course);
        //        var result = await _courseRepository.CommitAsync();

        //        if (result)
        //            return RedirectToAction(nameof(Index));
        //        else
        //            ModelState.AddModelError("", "An error occurred while saving the course.");
        //    }
        //    return View(course);
        //}

      
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var course = await _courseRepository.GetAsync(c => c.CourseId == id);
        //    if (course == null)
        //        return NotFound();

        //    return View(course);
        //}

       
        //[HttpPost]
       
        //public async Task<IActionResult> Edit(int id, Courses course)
        //{
        //    if (id != course.CourseId)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //       await _courseRepository.Update(course);
        //        var result = await _courseRepository.CommitAsync();

        //        if (result)
        //            return RedirectToAction(nameof(Index));
        //        else
        //            ModelState.AddModelError("", "An error occurred while updating the course.");
        //    }
        //    return View(course);
        //}

        
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var course = await _courseRepository.GetAsync(c => c.CourseId == id);
        //    if (course == null)
        //        return NotFound();

        //    return View(course);
        //}

        
        //[HttpPost, ActionName("Delete")]
        
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var course = await _courseRepository.GetAsync(c => c.CourseId == id);
        //    if (course == null)
        //        return NotFound();

        //  await _courseRepository.Delete(course);
        //    var result = await _courseRepository.CommitAsync();

        //    if (result)
        //        return RedirectToAction(nameof(Index));
        //    else
        //        ModelState.AddModelError("", "An error occurred while deleting the course.");

        //    return View(course);
        //}
    }
}
