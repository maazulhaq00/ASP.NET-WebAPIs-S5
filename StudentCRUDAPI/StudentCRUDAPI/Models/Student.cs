using System.ComponentModel.DataAnnotations;

namespace StudentCRUDAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
        public string StudentContact { get; set; }
        public string StudentCourse { get; set; }
    }
}
