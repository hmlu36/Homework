using Homework.Enums;
using Homework.Models;

namespace Homework.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student GetStudentByIdNumber(string idNumber);
        Student AddStudent(Student student);
        Student UpdateStudent(Student updatedStudent);
        Student DeleteStudent(string idNumber);
    }

    public class StudentService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentService()
        {
            _students = new List<Student>()
            {
                new Student { IdNumber = "A001", ClassName = "A", Name = "John", Sex = Sex.Male },
                new Student { IdNumber = "A002", ClassName = "A", Name = "Allen", Sex = Sex.Male },
                new Student { IdNumber = "A003", ClassName = "B", Name = "Alice", Sex = Sex.Female }
            };
        }

        public StudentService(List<Student> students)
        {
            _students = students;
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student? GetStudentByIdNumber(string idNumber)
        {
            return _students.FirstOrDefault(s => s.IdNumber == idNumber);
        }

        public Student AddStudent(Student newStudent)
        {
            if (_students.Any(e => e.IdNumber == newStudent.IdNumber))
            {
                throw new Exception("學號已存在");
            }
            else if (newStudent != null)
            {
                _students.Add(newStudent);
            }
            return newStudent;
        }

        public Student UpdateStudent(Student updatedStudent)
        {
            if (_students.FirstOrDefault(e => e.IdNumber == updatedStudent.IdNumber) is Student memoryStudent)
            {
                memoryStudent.IdNumber = updatedStudent.IdNumber;
                memoryStudent.Name = updatedStudent.Name;
                memoryStudent.ClassName = updatedStudent.ClassName;
                memoryStudent.Sex = updatedStudent.Sex;
            }
            else
            {
                throw new NullReferenceException("資料不存在");
            }
            return updatedStudent;
        }

        public Student DeleteStudent(string idNumber)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.IdNumber == idNumber);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
            else
            {
                throw new NullReferenceException("資料不存在");
            }
            return studentToRemove;
        }
    }
}
