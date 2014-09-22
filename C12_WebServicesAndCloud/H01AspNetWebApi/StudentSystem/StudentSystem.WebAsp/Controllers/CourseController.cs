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

    public class CourseController : ApiController
    {
        private IStudentSystemData data;

        public CourseController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data
                .Courses
                .All()
                .Select(CourseModel.FromCourse);

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult GetById(Guid id)
        {
            var course = this.data
                .Courses
                .All()
                .Where(c => c.Id == id)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return BadRequest("Such course does not exist!");
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course()
            {
                Name = course.Name,
                Description = course.Description
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;
            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult UpdateDescription(Guid id, string description)
        {
            var course = this.data
                .Courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return BadRequest("Such course does not exist!");
            }

            course.Description = description;
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCourse(Guid id)
        {
            var course = this.data
                .Courses
                .All()
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return BadRequest("Such course does not exist!");
            }

            this.data.Courses.Delete(course);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
