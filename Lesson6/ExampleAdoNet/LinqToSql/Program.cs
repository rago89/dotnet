using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentsDataLink studentsDataLink = new StudentsDataLink();
            var students = studentsDataLink.RetrieveAll();
            foreach (var student in students)
            {
                Console.WriteLine(student.name);
            }

            Console.ReadLine();
        }
    }
}
