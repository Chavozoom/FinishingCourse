using FinishingCourse.Entities;
using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace FinishingCourse
{
    class Program
    {

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
        }
            static void Main(string[] args)
            {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Enter salary: ");
            double userSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();

            List<Employee> employees = new List<Employee>();
            
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');

                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);

                        employees.Add(new(name, email, salary));
                    }
                }
                var r1 =
                    from e in employees
                    where e.Salary > userSalary
                    orderby e.Email
                    select e.Email;

                Print($"Email of people whose salary is more than {userSalary}: ", r1);
                Console.WriteLine();

                var sum = employees.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);

                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            }
        
    }
}