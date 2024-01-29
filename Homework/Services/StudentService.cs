using FreeRedis;
using Homework.Enums;
using Homework.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text.Json.Serialization;

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
        private readonly string REDIS_KEY = "Student:";
        //private readonly List<Student> _students;

        private readonly RedisClient _redisClient;
        private readonly ILogger<StudentService> _logger;
        public StudentService(IConfiguration configuration, ILogger<StudentService> logger)
        {
            _redisClient = new RedisClient(configuration.GetConnectionString("Redis"));
            _logger = logger;
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();
            foreach (var key in _redisClient.Scan($"{REDIS_KEY}*", 100, null).FirstOrDefault())
            {
                _logger.LogInformation(key);
                students.Add(JsonConvert.DeserializeObject<Student>(_redisClient.Get(key)));
            }
            return students;
        }

        public Student? GetStudentByIdNumber(string idNumber)
        {
            var key = $"{REDIS_KEY}{idNumber}";

            if (_redisClient.Exists(key))
            {
                var jsonString = _redisClient.Get(key);
                _logger.LogInformation(jsonString);
                return JsonConvert.DeserializeObject<Student>(jsonString);
            }
            return null;
        }

        public Student AddStudent(Student newStudent)
        {
            if (GetStudentByIdNumber(newStudent.IdNumber) != null)
            {
                throw new Exception("學號已存在");
            }
            else if (newStudent != null)
            {
                _redisClient.Set($"{REDIS_KEY}{newStudent.IdNumber}", JsonConvert.SerializeObject(newStudent));
            }
            return newStudent;
        }

        public Student UpdateStudent(Student updatedStudent)
        {
            if (GetStudentByIdNumber(updatedStudent.IdNumber) is Student redisStudent)
            {
                redisStudent.IdNumber = updatedStudent.IdNumber;
                redisStudent.Name = updatedStudent.Name;
                redisStudent.ClassName = updatedStudent.ClassName;
                redisStudent.Sex = updatedStudent.Sex;
                _redisClient.Set($"{REDIS_KEY}{updatedStudent.IdNumber}", redisStudent);
            }
            else
            {
                throw new NullReferenceException("資料不存在");
            }
            return updatedStudent;
        }

        public Student DeleteStudent(string idNumber)
        {
            if (GetStudentByIdNumber(idNumber) is Student redisStudent)
            {
                _redisClient.Del($"{REDIS_KEY}{idNumber}");
            }
            else
            {
                throw new NullReferenceException("資料不存在");
            }
            return redisStudent;
        }
    }
}
