using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Names = new string[] { "Avi", "Pav", "Raj", "Mav" };
            Console.WriteLine("Forming the Lambda query");
            IEnumerable<string> nameQ = from name in Names
                                        where name.Contains("a")
                                        select name;

            foreach (string name in nameQ)
            {
                Console.Write(name + " ");
            }

            Console.WriteLine("Anonymous Types");

            var employee = new { Id = 101, Name = "Avi", Title = "Software" };

            Console.WriteLine("The employee variable is type: " + employee.GetType().Name);

            Console.Read();
        }
    }
}
