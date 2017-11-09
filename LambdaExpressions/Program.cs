using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressions
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Program
    {
        public delegate bool IsStartsWith(Employee stud, string val);
        public static void Main(string[] args)
        {
            // in C# 2.0 Anonymous methods were introduced.
            // Lambda expressions provide a more concise, functional syntax for writing anonymous methods.

            List<Employee> lsEmp = new List<Employee>()
            {
                new Employee { ID = 1, Name = "Avi", Age = 26 },
                new Employee { ID = 2, Name = "Pav", Age = 25 },
                new Employee { ID = 3, Name = "Raj", Age = 30 },
                new Employee { ID = 4, Name = "Mah", Age = 27 }
            };
            Console.WriteLine("Employees List\r\n");
            lsEmp.ForEach(x => Console.WriteLine("Employee ID : " + x.ID + " Name: " + x.Name));

            UsingAnonymousMethodAndLamda(lsEmp);


            // Delegate Lamda Anonymous Expression
            UsingDelegateLamdaAndAnonymous(lsEmp);


            //Function Delegates with Anonymous Expression
            UsingFunctionDelegateAndAnonymous(lsEmp);


            //Action Delegates with Anonymous Expression
            UsingActionDelegateAndAnonymous(lsEmp);

            OverLoadResolution();

            Console.Read();
        }

        private static void UsingActionDelegateAndAnonymous(List<Employee> lsEmp)
        {
            Console.WriteLine("\r\n//Action Delegates with Anonymous Expression-----------------");
            Console.WriteLine("Declaring Local variable 'PrintEmployeeDetails' of Action type.");
            Console.WriteLine("Use the Action delegate type when you don't need to return any value from lambda expression. \r\n");
            Action<Employee> PrintEmployeeDetails = (e => Console.WriteLine("Emp Name: '" + e.Name + "' Age: " + e.Age));

            Console.WriteLine("Printing Empoyee details: \r\n");
            PrintEmployeeDetails(lsEmp.Find(delegate (Employee emp)
            {
                return emp.ID == 1;
            }));
        }

        private static void UsingFunctionDelegateAndAnonymous(List<Employee> lsEmp)
        {
            Console.WriteLine("\r\n//Function Delegates with Anonymous Expressions---------------");
            Console.WriteLine("Declaring Local variable 'isEmpTeenager' of function type.");
            Func<Employee, bool> isEmpTeenager = s => s.Age > 12 && s.Age < 20;

            Console.WriteLine(" a teenage? " + isEmpTeenager(lsEmp.Find(delegate (Employee emp) { Console.Write(" Is Emp: '" + emp.Name + "'"); return emp.ID == 1; })));
        }

        private static void UsingDelegateLamdaAndAnonymous(List<Employee> lsEmp)
        {
            Console.WriteLine("\r\n//Delegate Lambda Anonymous Expression--------------");
            IsStartsWith isStartsWith = (s, val) =>
            {
                Console.WriteLine("IsStartsWith is a Delegate with Lambda expression with multiple statements in the body");
                Console.WriteLine("Emp Name: '" + s.Name + "', Starts With: '" + val + "'");
                return s.Name.Substring(0, val.Length) == val;
            };


            Console.WriteLine("isStartsWith: " + isStartsWith(lsEmp.Find(delegate (Employee emp) { return emp.ID < 2; }), "Av"));
        }

        private static void UsingAnonymousMethodAndLamda(List<Employee> lsEmp)
        {
            Console.WriteLine("\r\n\r\n//Using Anonymous method to get the Employee where ID = 2 .......");
            Employee emp1 = lsEmp.Find(
                delegate (Employee emp)
                {
                    return emp.ID == 02;
                });

            Console.WriteLine(emp1 != null ? "Emp Found: " + emp1.Name : "Emp not found");

            Console.WriteLine("\r\n//Using Lambda Expression to get the Employee where Id = 3 .....");
            emp1 = lsEmp.Find(x => x.ID == 3);

            Console.WriteLine(emp1 != null ? "Emp Found: " + emp1.Name : "Emp not found");



            Console.WriteLine("\r\n//Using Anonymous method to get the Employees where Id < 2.......");
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

            Console.WriteLine("\r\n//Using Lambda Expression to get the Employees where Id < 3.......");
            emp2 = lsEmp.FindAll(x => x.ID < 3);

            emp2.ForEach(x => Console.WriteLine("Employee Found, Name: " + x.Name));
        }

        private static void OverLoadResolution()
        {
            ItemList<Orders> orders = Orders.GetMoreOrders();
            int totalUnits = orders.Sum(d => d.OrderCount);
            double orderTotal = orders.Sum(d => d.UnitPrice * d.OrderCount);
        }
    }

    public class ItemList<T> : List<T>
    {
        public int Sum(Func<T, int> selector)
        {
            int sum = 0;
            foreach (T item in this)
            {
                sum += selector(item);
            }
            return sum;
        }

        public double Sum(Func<T, double> selector)
        {
            double sum = 0;
            foreach (T item in this)
            {
                sum += selector(item);
            }
            return sum;
        }
    }

    public class Orders
    {
        public string OrderID { get; set; }
        public int OrderCount { get; set; }
        public double UnitPrice { get; set; }

        internal static ItemList<Orders> GetMoreOrders()
        {
            return new ItemList<Orders>() {
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 156.25, OrderCount = 50 },
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 500.99, OrderCount = 20 },
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 756.58, OrderCount = 10 },
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 800, OrderCount = 8 },
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 355.69, OrderCount = 40 },
                new Orders() { OrderID = Guid.NewGuid().ToString(), UnitPrice = 400, OrderCount = 30 },
            };
        }
    }

}
