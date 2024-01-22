using Microsoft.AspNetCore.Mvc;

namespace homework1.Controllers
{
    /// <summary>
    /// 作業1
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : Controller
    {

        [HttpGet]
        public string Index()
        {
            return "Hello World!";
        }
    }
}
