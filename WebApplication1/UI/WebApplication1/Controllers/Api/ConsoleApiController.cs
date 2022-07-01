using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Api
{
    [ApiController]
    [Route("api/console")]
    public class ConsoleApiController : ControllerBase
    {
        [HttpGet("clear")]
        public void Clear() => Console.Clear();

        [HttpGet("write({str})")]
        public void Write(string str) => Console.WriteLine(str);
    }
}
