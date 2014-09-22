namespace StudentSystem.WebAsp.Models
{
    using System;
    using System.Linq.Expressions;

    using StudentSystem.Models;    

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    Id = h.Id,
                    FileUrl = h.FileUrl,
                    TimeSent = h.TimeSent,
                    StudentIdentification = h.StudentIdentification,
                    CourseId = h.CourseId
                };
            }
        }


        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }
        
        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }
    }
}