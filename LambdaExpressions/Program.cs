using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // in C# 2.0 Anonymous methods were introduced.
            // Lambda expressions provide a more concise, functional syntax for writing anonymous methods.

            List<Employee> lsEmp = new List<Employee>()
            {
                new Employee { ID = 1, Name = "Avi" },
                new Employee { ID = 2, Name = "Pav" },
                new Employee { ID = 3, Name = "Raj" }
            };
            Console.WriteLine("Employees List\r\n");
            lsEmp.ForEach(x => Console.WriteLine("Employee ID : "+ x.ID + " Name: " + x.Name));

            Console.WriteLine("\r\n\r\nUsing Anonymous method to get the Employee where ID = 2 .......");
            Employee emp1 = lsEmp.Find(
                delegate (Employee emp)
                {
                    return emp.ID == 02;
                });

            Console.WriteLine(emp1 != null ? "Emp Found: " + emp1.Name : "Emp not found");

            Console.WriteLine("\r\nUsing Lambda Expression to get the Employee where Id = 3 .....");
            emp1 = lsEmp.Find(x => x.ID == 3);

            Console.WriteLine(emp1 != null ? "Emp Found: " + emp1.Name : "Emp not found");



            Console.WriteLine("\r\nUsing Anonymous method to get the Employees where Id < 2.......");
            List<Employee> emp2 = lsEmp.FindAll(
                delegate (Employee emp)
                {
                    if (emp.ID < 2)
                        return true;
                    else
                        return false;
                }
                );
            emp2.ForEach(x => Console.WriteLine("Employee Found, Name: " + x.Name));

            Console.WriteLine("\r\nUsing Lambda Expression to get the Employees where Id < 3.......");
            emp2 = lsEmp.FindAll(x => x.ID < 3);

            emp2.ForEach(x => Console.WriteLine("Employee Found, Name: " + x.Name));

            Console.Read();
        }
    }

    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
