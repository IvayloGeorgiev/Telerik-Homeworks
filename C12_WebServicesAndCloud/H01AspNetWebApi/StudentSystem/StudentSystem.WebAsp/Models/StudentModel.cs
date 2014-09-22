namespace StudentSystem.WebAsp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;    
    using System.Linq.Expressions;

    using StudentSystem.Models; 

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    StudentIdentification = s.StudentIdentification,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Level = s.Level,
                    AssistantId = s.Assistant != null ? (int?)s.Assistant.StudentIdentification : null,
                    AdditionalInformation = new StudentInfo()
                    {
                        Address = s.AdditionalInformation.Address,
                        Email = s.AdditionalInformation.Email 
                    }
                };
            }
        }


        public int StudentIdentification { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Level { get; set; }

        public StudentInfo AdditionalInformation { get; set; }

        public int? AssistantId { get; set; }
    }
}