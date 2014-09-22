namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Data.Entity;
    using System.Transactions;

    using EntityFramework.BulkInsert.Extensions;

    using StudentSystem.Data;
    using StudentSystem.Models;

    public class StudentSystemConsoleClient
    {
        public static void Main(string[] args)
        {
            var timer = new Stopwatch();
            var db = new StudentSystemDbContext();
            db.Database.Initialize(true);

            using (db)
            {
                db.Configuration.AutoDetectChangesEnabled = false;                
                for (int i = 0; i < 10; i++)
                {
                    using (var tran = new TransactionScope())
                    {

                        Console.WriteLine("looping");
                        var generated = GenerateStudents();
                        timer.Start();
                        db.BulkInsert<Student>(generated);
                        timer.Stop();
                        db.SaveChanges();
                        tran.Complete();
                    }
                }                
            }
            Console.WriteLine(timer.Elapsed);
        }


        private static IEnumerable<Student> GenerateStudents()
        {
            List<Student> result = new List<Student>(1000000);
            for (int i = 0; i < 1000000; i++)
            {
                result.Add(new Student()
                {
                    FirstName = "Pesho " + i,
                    LastName = "Peshov " + i,
                    Number = "00000" + i
                });
            }
            return result;
        }
    }
}
