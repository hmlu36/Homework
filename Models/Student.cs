using Homework.Enums;
using System.ComponentModel.DataAnnotations;

namespace Homework.Models
{
    public class Student
    {
        /// <summary>
        /// 學號
        /// </summary>
        public required string IdNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// 班級
        /// </summary>
        public string? ClassName { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public Sex Sex { get; set; }
    }
}
