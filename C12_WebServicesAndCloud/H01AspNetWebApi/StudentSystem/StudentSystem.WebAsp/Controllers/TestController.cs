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

    public class TestController : ApiController
    {
         private IStudentSystemData data;

        public TestController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var tests = this.data
                .Tests
                .All()
                .Select(TestModel.FromTest);

            return Ok(tests);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var test = this.data
                .Tests
                .All()
                .Where(t => t.Id == id)
                .Select(TestModel.FromTest)
                .FirstOrDefault();

            if (test == null)
            {
                return BadRequest("Such test does not exist!");
            }

            return Ok(test);
        }

        [HttpPost]
        public IHttpActionResult Create(TestModel test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTest = new Test()
            {
                CourseId = test.CourseId,                
            };

            this.data.Tests.Add(newTest);
            this.data.SaveChanges();

            test.Id = newTest.Id;
            return Ok(test);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCourse(int id)
        {
            var test = this.data
                .Tests
                .All()
                .FirstOrDefault(t => t.Id == id);

            if (test == null)
            {
                return BadRequest("Such test does not exist!");
            }

            this.data.Tests.Delete(test);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
