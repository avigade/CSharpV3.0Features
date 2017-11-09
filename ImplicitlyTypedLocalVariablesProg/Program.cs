using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVariablesProg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implicitly Typed Local Variables are which inferr/conclude that the value assigned to it is of some type.
            // Not all types can be assigned as explicit types

            //Example:- 'Var'

            //These are the Implicit type variables whom do not assign the explicit types.
            //These can be well understood when used as Explicit types.

            var i = 5; // We know that var here explicitly is 'int'
            var s = "Hello"; // var here explicitly is 'String'
            var d = 1.0; // var here explicitly double
            var numbers = new int[] { 1, 2, 3 }; // var here explicitly is int[]
            var orders = new Dictionary<int, string>(); // var here explicitly Dictionary<int,string>

            //Lets Get their Types in the output

            Console.WriteLine("var i: " + i.GetType());
            Console.WriteLine("var s: " + s.GetType());
            Console.WriteLine("var d: " + d.GetType());
            Console.WriteLine("var numbers: " + numbers.GetType());
            
            Console.WriteLine("var orders: " + orders.GetType());

            Console.ReadKey();
        }
    }
}
