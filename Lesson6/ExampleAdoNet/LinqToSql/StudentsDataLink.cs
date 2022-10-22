using System.Collections.Generic;
using System;
using System.Linq;

namespace LinqToSql
{
    public class StudentsDataLink
    {
        StudentDataContext _studentsDataContext;

        public StudentsDataLink()
        {
            _studentsDataContext = new StudentDataContext();
        }
        
        public Student Retrieve(string studentName)
        {
            if (!Exists(studentName))
                throw new ArgumentException("The student name entered does not exists.", nameof(studentName));

            Student databaseObject = _studentsDataContext.Students.Single(student => student.name == studentName);
            return databaseObject;
        }
 
        /// <summary>
        /// Retrieves all the devices.
        /// </summary>
        /// 
        /// <returns>An IEnumerable containing all the devices in the database.</returns>
        public IEnumerable<Student> RetrieveAll()
        {
            IEnumerable<Student> students = _studentsDataContext.Students;
 
            return students;
        }

        public void Add(Student studentToAdd)
        {
            if (Exists(studentToAdd.name))
                throw new ArgumentException("The student entered already exists.", nameof(studentToAdd));
 
            _studentsDataContext.Students.InsertOnSubmit(studentToAdd);
            _studentsDataContext.SubmitChanges();
        }
 
        public void Update(Student studentToUpdate)
        {
            if (!Exists(studentToUpdate.name))
                throw new ArgumentException("The student entered does not exists.", nameof(studentToUpdate));
 
            Student databaseObject = _studentsDataContext.Students.Single(student => studentToUpdate.name == student.name);
 
            databaseObject.name = studentToUpdate.name;
            databaseObject.age = studentToUpdate.age;
 
            _studentsDataContext.SubmitChanges();
        }
 
        public bool Exists(string studentName)
        {
            if (_studentsDataContext.Students.Any(device => device.name == studentName))
                return true;
            return false;
        }
    }
}
