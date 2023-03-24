using GymTracker.Models;
using System;
namespace GymTracker
{
    public class Instructors
    {
        public Instructors() 
        { 
        }

        public int InstructorID { get; set; }
        public int UserID { get; set; }
        public string InstructorName { get; set; }
        public string Email { get; set; }
        public string Contact { get ; set; }
        public string Address { get; set; }
        public IEnumerable<Focus> Focus { get; set; }
    }
}
