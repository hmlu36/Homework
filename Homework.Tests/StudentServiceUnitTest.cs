using Homework.Enums;
using Homework.Models;
using Homework.Services;
using Xunit.Extensions.Ordering;

//Optional
[assembly: CollectionBehavior(DisableTestParallelization = true)]
//Optional
[assembly: TestCaseOrderer("Xunit.Extensions.Ordering.TestCaseOrderer", "Xunit.Extensions.Ordering")]
//Optional
[assembly: TestCollectionOrderer("Xunit.Extensions.Ordering.CollectionOrderer", "Xunit.Extensions.Ordering")]

namespace Homework.Tests;

/// <summary>
/// XUnit Dependency Injection
/// </summary>
/// ref: https://copyprogramming.com/howto/dependency-injection-in-xunit-project
public class StudentServiceFixture
{
    public IStudentService studentService;

    public StudentServiceFixture()
    {
        studentService = new StudentService();
    }
}

public class StudentServiceUnitTest: IClassFixture<StudentServiceFixture>
{
    private readonly IStudentService _studentService;
    
    public StudentServiceUnitTest(StudentServiceFixture studentServiceFixture)
    {
        _studentService = studentServiceFixture.studentService;
    }
    
    [Fact, Order(0)]
    public void GetAllTest()
    {
        var students = _studentService.GetAllStudents();
        Assert.Equal(3, students.Count);
    }

    [Fact, Order(1)]
    public void GetByIdTest()
    {
        var idNumber = "A001";
        var student = _studentService.GetStudentByIdNumber(idNumber);
        Assert.Equal("John", student.Name);
    }

    [Fact, Order(2)]
    public void AddStudentTest()
    {
        var student = new Student() { IdNumber = "C001", Name = "Joshua", ClassName = "C", Sex = Sex.Male };
        _studentService.AddStudent(student);
        var students = _studentService.GetAllStudents();
        Assert.Equal(4, students.Count);
    }

    [Fact, Order(3)]
    public void UpdateStudentTest()
    {
        var student = new Student() { IdNumber = "A001", Name = "John", ClassName = "C", Sex = Sex.Male };
        _studentService.UpdateStudent(student);
        student = _studentService.GetStudentByIdNumber(student.IdNumber);
        Assert.Equal("C", student.ClassName);
    }

    [Fact, Order(4)]
    public void DeleteTest()
    {
        var idNumber = "A001";
        _studentService.DeleteStudent(idNumber);
        var students = _studentService.GetAllStudents();
        Assert.Equal(3, students.Count);
    }


    [Fact, Order(5)]
    public void DeleteExceptionTest()
    {
        var idNumber = "Z001";
        var ex = Assert.Throws<NullReferenceException>(() => _studentService.DeleteStudent(idNumber));
        Assert.Equal("資料不存在", ex.Message);
    }
}