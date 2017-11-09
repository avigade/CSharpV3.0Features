using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollectionInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Object Initializers");
            Console.WriteLine("An object initializer consists of a sequence of member initializers, enclosed by { and } tokens and separated by commas.");

            //Example

            //We have a Point class and we need to initialize it and assign the values to its props

            // We can assign the values while Initializing the object

            var _p = new Point()
            {
                X = 10,
                Y = 20
            };

            // Which is again same as 

            Point __p = new Point();
            __p.X = 10;
            __p.Y = 20;

            // Lets assign the values of point when we initialize the class Rectangle

            var _r = new Rectangle()
            {
                P1 = new Point() { X = 10, Y = 20 },
                P2 = new Point() { X = 30, Y = 40 }
            };

            // Which can also be written as 

            _r = new Rectangle();

            Point _p1 = new Point();
            _p1.X = 10;
            _p1.Y = 20;

            _r.P1 = _p1;

            Point _p2 = new Point();
            _p2.X = 10;
            _p2.Y = 20;

            _r.P2 = _p2;



            Console.WriteLine("collection Initializers");
            Console.WriteLine("An Collection Initilizer is same as Object initializer. only difference is we add the values in collections");
            var contacts = new List<Contact> {
                           new Contact {
                              Name = "Avi",
                              PhoneNumbers = { "955256825", "25625152" }
                           },
                           new Contact {
                              Name = "Pav",
                              PhoneNumbers = { "552452632", "1235444545" }
                           }
                        }; // end of Contanct initializer
        }


    }

    public class Rectangle
    {
        Point p1, p2;
        public Point P1 { get { return p1; } set { p1 = value; } }
        public Point P2 { get { return p2; } set { p2 = value; } }
    }

    public class Point
    {
        int x, y;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { x = value; } }
    }

    public class Contact
    {
        string name;
        List<string> phoneNumbers = new List<string>();
        public string Name { get { return name; } set { name = value; } }
        public List<string> PhoneNumbers { get { return phoneNumbers; } }
    }
}
