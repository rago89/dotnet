using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson3.Generics
{
    // Documentation: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters

    public class EmployeeLogic
    {
        public void DoSomethingWithEmployeeList()
        {
            var personList = new GenericList<Person>();
            personList.AddHead(new Employee("Francis", 1, DateTime.Now.AddMonths(-3)));
            personList.AddHead(new Employee("Johnny", 2, DateTime.Now.AddMonths(-9)));

            personList.AddHead(new Person("Barry", 12));

            personList.AddHead(new Customer("Starbucks", 455, "BE12345678"));


            var employeeList = new GenericList<Employee>();
            employeeList.AddHead(new Employee("Francis", 1, DateTime.Now.AddMonths(-3)));
            employeeList.AddHead(new Employee("Johnny", 2, DateTime.Now.AddMonths(-9)));

            //employeeList.AddHead(new Person("Barry", 12));

            //employeeList.AddHead(new Customer("Starbucks", 455, "BE12345678"));
        }
    }

    public class Person
    {
        public Person(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public int Id { get; private set; }
    }

    public class Employee : Person
    {
        public Employee(string name, int id, DateTime employmentStartDate) : base(name, id)
        {
            EmploymentStartDate = employmentStartDate;
        }

        public DateTime EmploymentStartDate { get; private set; }
    }

    public class Customer : Person
    {
        public Customer(string name, int id, string bankNumber) : base(name, id)
        {
            BankNumber = bankNumber;
        }

        public string BankNumber { get; private set; }
    }

    public class GenericList<T> where T : Person
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node? Next { get; set; }
            public T Data { get; set; }
        }

        private Node? head;

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T? FindFirstOccurrence(string s)
        {
            Node? current = head;
            T? t = null;

            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }
}
