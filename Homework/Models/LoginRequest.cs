﻿namespace Homework.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string? Password { get; set; } = null;

    }
}
