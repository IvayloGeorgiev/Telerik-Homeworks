namespace StudentSystem.WebAsp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.WebAsp.Models;

    public class StudentController : ApiController
    {
        private IStudentSystemData data;

        public StudentController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data
                .Students
                .All()
                .Select(StudentModel.FromStudent);

            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var student = this.data
                .Students
                .All()
                .Where(s => s.StudentIdentification == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Such student does not exist!");
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input types.");
            }

            var newStudent = new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Level = student.Level,
                AdditionalInformation = new StudentInfo() {Address = student.AdditionalInformation.Address, Email = student.AdditionalInformation.Email},                                
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.StudentIdentification = newStudent.StudentIdentification;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (student == null)
            {
                return BadRequest("Such student does not exist!");
            }

            existingStudent.Level = student.Level;
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            
            this.data.SaveChanges();

            student.StudentIdentification = existingStudent.StudentIdentification;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult AddCourse(int id, Guid courseId)
        {
            var existingStudent = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (existingStudent == null)
            {
                return BadRequest("Such student does not exist!");
            }

            var existingCourse = this.data
                .Courses
                .All()
                .FirstOrDefault(c => c.Id == courseId);

            if (existingCourse == null)
            {
                return BadRequest("Such course does not exist!");
            }

            existingStudent.Courses.Add(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateAssistant(int id, int assistantId)
        {           
            var student = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (student == null)
            {
                return BadRequest("Such student does not exist!");
            }

            var assistant = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == assistantId);

            if (student == null)
            {
                return BadRequest("Such assistant does not exist!");
            }

            student.Assistant = assistant;
            this.data.SaveChanges();                       

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var student = this.data
                .Students
                .All()
                .FirstOrDefault(s => s.StudentIdentification == id);

            if (student == null)
            {
                return BadRequest("Such student does not exist!");
            }

            this.data.Students.Delete(student);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
