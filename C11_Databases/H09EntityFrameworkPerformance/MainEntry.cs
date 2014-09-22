/* Task 1 - Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.
 * 
 * Task 2 - Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.
 * 
 * Check project folder for pics of Sql performance.
 */

namespace H09EntityFrameworkPerformance
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    using H09EntityFrameworkPerformance.Model;

    class MainEntry
    {
        static void Main(string[] args)
        {
            //TestSelectEmployees();
            //SelectEmployeesWithoutInclude();
            //SelectEmployeesWithInclude();
            //TestToListInsanity();
            //EmployeesInSofiaWithToList();
            EmployeesInSofiaWithoutToList();
        }

        private static void TestSelectEmployees()
        {
            //Test without include.
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine(SelectEmployeesWithoutInclude());
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            timer.Reset();

            //Test with include.
            timer.Start();
            Console.WriteLine(SelectEmployeesWithInclude());
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }

        private static void TestToListInsanity()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            EmployeesInSofiaWithToList();
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            timer.Reset();

            timer.Start();
            EmployeesInSofiaWithoutToList();
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }

        private static string SelectEmployeesWithoutInclude()
        {
            StringBuilder result = new StringBuilder();
            using (var ctx = new TelerikAcademyEntities())
            {
                foreach (var employee in ctx.Employees)
                {
                    result.AppendLine(string.Format("{0} {1} - {2} - {3}", 
                        employee.FirstName,
                        employee.LastName,
                        employee.Department.Name,
                        employee.Address.Town.Name));
                }
            }

            return result.ToString();
        }

        private static string SelectEmployeesWithInclude()
        {
            StringBuilder result = new StringBuilder();
            using (var ctx = new TelerikAcademyEntities())
            {
                foreach (var employee in ctx.Employees.Include("Department").Include("Address.Town"))
                {
                    result.AppendLine(string.Format("{0} {1} - {2} - {3}",
                        employee.FirstName,
                        employee.LastName,
                        employee.Department.Name,
                        employee.Address.Town.Name));
                }
            }

            return result.ToString();
        }

        private static void EmployeesInSofiaWithToList()
        {            
            using (var ctx = new TelerikAcademyEntities())
            {
                var employeesInSofia = ctx.Employees.ToList()
                    .Select(x => x.Address).ToList()
                    .Select(x => x.Town).ToList()
                    .Where(x => x.Name == "Sofia");
                employeesInSofia.Count();
            }            
        }

        private static void EmployeesInSofiaWithoutToList()
        {            
            using (var ctx = new TelerikAcademyEntities())
            {
                var employeesInSofia = ctx.Employees.Select(x => x.Address).Select(x => x.Town).Where(x => x.Name == "Sofia");
                employeesInSofia.Count();
            }
        }
    }
}
