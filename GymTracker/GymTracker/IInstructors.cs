using GymTracker.Models;
using System;
using System.Collections.Generic;



namespace GymTracker
{
    public interface IInstructors
    {
        public IEnumerable<Instructors> GetAllInstructors();
        public Instructors GetInstructor(int id);
        public void UpdateInstructors(Instructors instructors);
        public void InsertInstructor(Instructors instructorToInsert);
        public IEnumerable<Focus> GetFocus();
        public Instructors AssignFocus();
        public void DeleteInstructor(Instructors instructors);
    }
}
