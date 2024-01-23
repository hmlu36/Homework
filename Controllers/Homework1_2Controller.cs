using Homework.Enums;
using Homework.Models;
using Homework.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
    /// <summary>
    /// Homework 1-2
    /// </summary>
    [ApiController]
    [Route("api")]
    public class Homework1_2Controller : ControllerBase
    {
        private readonly ILogger<Homework1_2Controller> _logger;


        private readonly IPetService _petService;

        public Homework1_2Controller(ILogger<Homework1_2Controller> logger, IPetService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        [HttpPost("Login/LoginMember")]
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

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="petEnum">寵物類型</param>
        /// <returns></returns>
        [HttpGet("Pet/Query")]
        public IAnimal Query(PetEnum? petEnum)
        {
            if (PetEnum.Dog == petEnum)
            {
                return new Dog();
            }
            else if (PetEnum.Cat == petEnum)
            {
                return new Cat();
            }
            throw new Exception("寵物類型不存在");
        }

        /// <summary>
        /// 價格
        /// </summary>
        /// <param name="petEnum">寵物類型</param>
        /// <returns></returns>
        [HttpGet("Pet/GetPrice")]
        public Decimal GetPrice(PetEnum? petEnum)
        {
            if (PetEnum.Dog == petEnum)
            {
                return _petService.GetPrice(new Dog());
            }
            else if (PetEnum.Cat == petEnum)
            {
                return _petService.GetPrice(new Cat());
            }

            return 0;
        }

        /// <summary>
        /// 寵物店
        /// </summary>
        /// <returns></returns>
        [HttpGet("Pet/StorePets")]
        public Store StorePets()
        {
            var store = new Store();

            IAnimal cat = new Cat() { Name = "波斯貓", Price = 10000 };
            store.Animals.Add(cat);

            IAnimal dog = new Dog() { Name = "杜賓犬", Price = 8000 };
            store.Animals.Add(dog);

            dog = new Dog() { Name = "牧羊犬", Price = 5000 };
            store.Animals.Add(dog);

            return store;
        }
    }
}
