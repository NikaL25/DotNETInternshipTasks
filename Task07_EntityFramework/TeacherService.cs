using System;
using System.Collections.Generic;
using System.Linq;
using DotNETInternshipTasksApp.Task07_EntityFramework.Models;

namespace DotNETInternshipTasksApp.Task07_EntityFramework
{
    public class TeacherService
    {
        private readonly AppDbContext _context;

        public TeacherService(AppDbContext context)
        {
            _context = context;
        }

        public List<Teacher> GetAllTeachersByStudent(string studentName)
        {
            return _context.Teachers
                .Where(t => t.Pupils.Any(p => p.FirstName == studentName))
                .ToList();
        }

        public void SeedData()
        {
            if (_context.Teachers.Any()) return; 
            var giorgi = new Pupil
            {
                FirstName = "გიორგი",
                LastName = "ნადირაშვილი",
                Gender = "Male",
                Class = "10A"
            };

            var teacher1 = new Teacher
            {
                FirstName = "Vano",
                LastName = "Mchedlishvili",
                Gender = "Male",
                Subject = "Math",
                Pupils = new List<Pupil> { giorgi }
            };

            var teacher2 = new Teacher
            {
                FirstName = "Otar",
                LastName = "Ivanishvili",
                Gender = "Male",
                Subject = "History",
                Pupils = new List<Pupil> { giorgi }
            };

            _context.Teachers.AddRange(teacher1, teacher2);
            _context.SaveChanges();
        }
    }
}
