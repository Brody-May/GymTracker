using Dapper;
using GymTracker.Models;
using System;
using System.Data;
namespace GymTracker
{
    public class InstructorRepository : IInstructors
    {
        private readonly IDbConnection _conn;
        public InstructorRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Instructors> GetAllInstructors()
        {
            return _conn.Query<Instructors>("SELECT * FROM INSTRUCTORS;");
        }

        public Instructors GetInstructor(int id)
        {
            return _conn.QuerySingleOrDefault<Instructors>("SELECT * FROM INSTRUCTORS WHERE INSTRUCTORID = @id", new { id = id });
        }

        public void UpdateInstructors(Instructors instructors)
        {
            _conn.Execute("UPDATE instructors SET Instructor Name = @instructorname, Contact = @contact WHERE InstructorID = @id",
             new { name = instructors.InstructorName, price = instructors.Contact, id = instructors.InstructorID });
        }

        public void InsertInstructor(Instructors instructorToInsert)
        {
            _conn.Execute("INSERT INTO instructors (NAME, CONTACT, FOCUSID) VALUES (@name, @contact, @focusID);",
                new { name = instructorToInsert.InstructorName, contact = instructorToInsert.Contact, focusID = instructorToInsert.Focus });
        }

        public IEnumerable<Focus> GetFocus()
        {
            return _conn.Query<Focus>("SELECT * FROM focus;");
        }

        public Instructors AssignFocus()
        {
            var focusList = GetFocus();
            var instructors = new Instructors();
            instructors.Focus = focusList;
            return instructors;
        }

        public void DeleteInstructor(Instructors instructors)
        {
            _conn.Execute("DELETE FROM InstructorID WHERE InstructorID = @id;", new { id = instructors.InstructorID });
            _conn.Execute("DELETE FROM Contact WHERE InstructorID = @id;", new { id = instructors.InstructorID });
            _conn.Execute("DELETE FROM Instructors WHERE InstructorID = @id;", new { id = instructors.InstructorID });
        }
    }
}
