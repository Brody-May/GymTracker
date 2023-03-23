using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymTracker;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructors repo;

        public InstructorController(IInstructors repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var instructors = repo.GetAllInstructors();
            return View(instructors);
        }

        public IActionResult ViewInstructors(int id)
        {
            var instructors = repo.GetInstructor(id);
            return View(instructors);
        }

        public IActionResult UpdateInstructors(int id)
        {
            Instructors inst = repo.GetInstructor(id);
            if (inst == null)
            {
                return View("InstructorNotFound");
            }
            return View(inst);
        }

        public IActionResult UpdateInstructorsToDatabase(Instructors instructors)
        {
            repo.UpdateInstructors(instructors);

            return RedirectToAction("ViewInstructors", new { id = instructors.InstructorID });
        }

        public IActionResult InsertInstructor() 
        { 
            var inst = repo.GetInstructor(0);
            return View(inst);
        }

        public IActionResult InsertInstructorToDatabase(Instructors instructorToInsert)
        {
            repo.InsertInstructor(instructorToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteInstructor(Instructors instructors) 
        {
            repo.DeleteInstructor(instructors);
            return RedirectToAction("Index");
        }

    }
}
