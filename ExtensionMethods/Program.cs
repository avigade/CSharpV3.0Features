using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        // Extension methods are available in a namespace if declared in a static class 
        // Or imported through using-namespace-directives
        static void Main(string[] args)
        {
            // Understanding ------------
            // In the Below code we know that Extenstions class is part of the namespace 'ExtensionMethod' so thats the reason its publicly available.
            string s = "123";
            int value = s.ToInt32();  // Same as Extensions.ToInt32(s)

            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] a = digits.Slice(4, 3);      // Same as Extensions.Slice(digits, 4, 3)

            X.Test(new A(), new B(), new C());

            Console.ReadLine();
        }
    }

    public static class E
    {
        public static void F(this object obj, int i)
        {
            Console.WriteLine("\r\nClass Called from: " + obj + " Invoking the 1st Extension Method E.F() and Value passed: " + i);
        }
        public static void F(this object obj, string s)
        {
            Console.WriteLine("\r\nClass Called from: " + obj + " Invoking the 2nd Extension Method E.F()  and Value passed: " + s);
        }
    }
    public class A { }
    public class B
    {
        public void F(int i)
        {
            Console.WriteLine("\r\nClass Called by B itself as this method 'F' has taken precedence over the 1st E.F() with value: " + i);
        }
    }
    public class C
    {
        public void F(object obj)
        {
            Console.WriteLine("\r\nClass Called by C itself as this method 'F' has taken precedence over the 2nd E.F() methods with Type: " + obj.GetType() + " Value: "+ obj);
        }
    }
    public class X
    {
        // Same goes with Class E- It has Extension methods "F" and "F" with diff parameters
        public static void Test(A a, B b, C c)
        {
            a.F(1);            // E.F(object, int)
            a.F("hello");      // E.F(object, string)
            b.F(1);            // B.F(int)
            b.F("hello");      // E.F(object, string)
            c.F(1);            // C.F(object)
            c.F("hello");      // C.F(object)
        }
    }
}
