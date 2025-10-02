using System.Collections.Generic;

namespace DotNETInternshipTasksApp.Task07_EntityFramework.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        public List<Pupil> Pupils { get; set; } = new();
    }
}
