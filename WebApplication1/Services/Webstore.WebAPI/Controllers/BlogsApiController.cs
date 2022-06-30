using DataLayer;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;

namespace Webstore.WebAPI.Controllers
{
    [ApiController]
    [Route(WebAPIAddresses.V1.Blogs)]
    public class BlogsApiController : ControllerBase
    {
        private readonly IBlogData _BlogsData;
        private readonly ILogger<BlogsApiController> _Logger;

        public BlogsApiController(IBlogData BlogsData, ILogger<BlogsApiController> Logger)
        {
            _BlogsData = BlogsData;
            _Logger = Logger;
        }

        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var result = _BlogsData.GetCount();
            return Ok(result);
        }

        [HttpGet("[[{Skip:int}:{Take:int}]]")]
        [HttpGet("{Skip:int}:{Take:int}")]
        public IActionResult Get(int Skip, int Take)
        {
            if (Skip < 0 || Take < 0)
                return BadRequest();

            if (Take == 0 || Skip > _BlogsData.GetCount())
                return NoContent();

            var result = _BlogsData.Get(Skip, Take);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if (_BlogsData.GetCount() == 0)
                return NoContent();

            var result = _BlogsData.GetBlogs();
            return Ok(result);
        }
    }
}
