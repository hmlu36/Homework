using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    /// <summary>
    /// Homework 1
    /// </summary>
    [ApiController]
    [Route("api/HelloWorld")]
    public class Homework1Controller : ControllerBase
    {

        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }
    }
}
