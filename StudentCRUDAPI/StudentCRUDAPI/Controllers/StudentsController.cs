using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCRUDAPI.Models;

namespace StudentCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApiDbContext db;
        public StudentsController(ApiDbContext context)
        {
            this.db = context;
            
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent([FromBody]Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();

            return Ok(student);
        }

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            List<Student> students = db.Students.ToList();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(students);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<List<Student>> GetStudents(int id)
        {
            Student student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }

        [HttpDelete("{id}")] // DELETE /api/students/{id}
        public ActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);

            if(student == null)
            {
                return NotFound();
            }
            else
            {
                db.Students.Remove(student);
                db.SaveChanges();

                return Ok();
            }

        }
    }
}
