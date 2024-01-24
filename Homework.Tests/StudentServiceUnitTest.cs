using Homework.Enums;
using Homework.Models;
using Homework.Services;
using Xunit.Microsoft.DependencyInjection;

namespace Homework.Tests;

public class StudentServiceFixture : TestBedFixture
{
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        services.AddSingleton<IStudentService, StudentService>();
    }

    protected override ValueTask DisposeAsyncCore() => new();

    protected override IEnumerable<TestAppSettings> GetTestAppSettings()
    {
        yield return new() { Filename = "appsettings.json", IsOptional = false };
    }
}

[TestCaseOrderer("Xunit.Microsoft.DependencyInjection.TestsOrder.TestPriorityOrderer", "Xunit.Microsoft.DependencyInjection")]
public class StudentServiceUnitTest : TestBed<StudentServiceFixture>
{
    private readonly IStudentService _studentService;
    public StudentServiceUnitTest(ITestOutputHelper testOutputHelper, StudentServiceFixture fixture)
        : base(testOutputHelper, fixture) => _studentService = fixture.GetService<IStudentService>(testOutputHelper);
    
    [Fact, TestOrder(0)]
    public void GetAllTest()
    {
        var students = _studentService.GetAllStudents();
        Assert.Equal(3, students.Count);
    }

    [Fact, TestOrder(1)]
    public void GetByIdTest()
    {
        var idNumber = "A001";
        var student = _studentService.GetStudentByIdNumber(idNumber);
        Assert.Equal("John", student.Name);
    }

    [Fact, TestOrder(2)]
    public void AddStudentTest()
    {
        var student = new Student() { IdNumber = "C001", Name = "Joshua", ClassName = "C", Sex = Sex.Male };
        _studentService.AddStudent(student);
        var students = _studentService.GetAllStudents();
        Assert.Equal(4, students.Count);
    }

    [Fact, TestOrder(3)]
    public void UpdateStudentTest()
    {
        var student = new Student() { IdNumber = "A001", Name = "John", ClassName = "C", Sex = Sex.Male };
        _studentService.UpdateStudent(student);
        student = _studentService.GetStudentByIdNumber(student.IdNumber);
        Assert.Equal("C", student.ClassName);
    }

    [Fact, TestOrder(4)]
    public void DeleteTest()
    {
        var idNumber = "C001";
        _studentService.DeleteStudent(idNumber);
        var students = _studentService.GetAllStudents();
        Assert.Equal(3, students.Count);
    }


    [Fact, TestOrder(5)]
    public void DeleteExceptinTest()
    {
        var idNumber = "Z001";
        var ex = Assert.Throws<NullReferenceException>(() => _studentService.DeleteStudent(idNumber));
        Console.WriteLine(ex.Message);  
        Assert.Equal("資料不存在", ex.Message);
    }
}