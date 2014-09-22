namespace StudentSystem.WebAsp.Models
{    
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Models;    

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
            get
            {
                return c => new CourseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }
}