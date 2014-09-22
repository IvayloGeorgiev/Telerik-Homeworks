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

    public class HomeworkController : ApiController
    {

        private IStudentSystemData data;

        public HomeworkController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data
                .Homeworks
                .All()
                .Select(HomeworkModel.FromHomework);

            return Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var homework = this.data
                .Homeworks
                .All()
                .Where(h => h.Id == id)
                .Select(HomeworkModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return BadRequest("Such homework does not exist!");
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkModel homework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input types.");
            }

            var newHomework = new Homework()
            {
                FileUrl = homework.FileUrl,
                TimeSent = homework.TimeSent,
                CourseId = homework.CourseId,
                StudentIdentification = homework.StudentIdentification,                               
            };

            this.data.Homeworks.Add(newHomework);
            this.data.SaveChanges();

            homework.Id = newHomework.Id;
            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult UpdateHomework(int id, HomeworkModel homework)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHomework = this.data
                .Homeworks
                .All()
                .FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return BadRequest("Such homework does not exist!");
            }

            existingHomework.FileUrl = homework.FileUrl;
            this.data.SaveChanges();

            homework.Id = existingHomework.Id;
            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult DeleteHomework(int id)
        {
            var homework = this.data
                .Homeworks
                .All()
                .FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return BadRequest("Such homework does not exist!");
            }

            this.data.Homeworks.Delete(homework);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
