using Homework.Enums;
using Homework.Models;
using Homework.Services;
using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    /// <summary>
    /// Homework 2
    /// </summary>
    [ApiController]
    [Route("api/Restful")]
    public class Homework2Controller : ControllerBase
    {
        private readonly IStudentService _studentService;

        public Homework2Controller(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// 所有學生資料
        /// </summary>
        /// <response code="200">所有學生資訊(學號、班級、姓名、性別)</response>
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Student>> GetAll()
        {
            return _studentService.GetAllStudents();
        }

        /// <summary>
        /// 傳入學號，取得學生資訊
        /// </summary>
        /// <param name="idNumber">學號</param>
        /// <returns>指定索引的字符串</returns>
        /// <response code="200">學生資訊(學號、班級、姓名、性別)</response>
        [HttpGet("{idNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student?> Get(string idNumber)
        {
            return _studentService.GetStudentByIdNumber(idNumber);
        }

        /// <summary>
        /// 新增學生資訊
        /// </summary>
        /// <param name="newStudent">學生資訊</param>
        /// <returns>新增學生資訊</returns>
        /// <response code="200">學生資訊(學號、班級、姓名、性別)</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student> Post(Student newStudent)
        {
            return _studentService.AddStudent(newStudent);
        }

        /// <summary>
        /// 更新學生資訊
        /// </summary>
        /// <param name="updatedStudent">學生資訊</param>
        /// <returns>更新後學生資訊</returns>
        /// <response code="200">學生資訊(學號、班級、姓名、性別)</response>
        [HttpPut("{newStudent}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student> Put(Student updatedStudent)
        {
            return _studentService.UpdateStudent(updatedStudent);
        }

        /// <summary>
        /// 刪除學生資訊
        /// </summary>
        /// <param name="idNumber">學號</param>
        /// <returns>刪除之學生資訊</returns>
        /// <response code="200">刪除學生資訊(學號、班級、姓名、性別)</response>
        [HttpDelete("{idNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Student> Delete(string idNumber)
        {
            return _studentService.DeleteStudent(idNumber);
        }
    }
}
