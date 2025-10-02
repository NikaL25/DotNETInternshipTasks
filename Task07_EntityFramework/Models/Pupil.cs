using System.Collections.Generic;

namespace DotNETInternshipTasksApp.Task07_EntityFramework.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        public List<Teacher> Teachers { get; set; } = new();
    }
}
