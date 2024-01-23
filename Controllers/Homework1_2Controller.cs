using Homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
    /// <summary>
    /// Homework 1-2
    /// </summary>
    [ApiController]
    [Route("api/Login")]
    public class Homework1_2Controller : ControllerBase
    {
        private readonly ILogger<Homework1_2Controller> _logger;

        public Homework1_2Controller(ILogger<Homework1_2Controller> logger)
        {
            _logger = logger;
        }

        [HttpPost("LoginMember")]
        public IActionResult LoginMember([FromBody] LoginRequest loginRequest)
        {
            // 假設有一個簡單的驗證邏輯，實際應用需檢查使用者帳號密碼是否有效
            if (loginRequest.UserName == "1234" && loginRequest.Password == "1234")
            {
                // 登入成功
                _logger.LogInformation($"User '{loginRequest.UserName}' logged in at {DateTime.Now}");
                return Ok(new { Message = "登入成功" });
            }

            // 登入失敗
            _logger.LogWarning($"Failed login attempt for user '{loginRequest.UserName}' at {DateTime.Now}");
            return Unauthorized(new { Message = "登入失敗" });
        }
    }
}
