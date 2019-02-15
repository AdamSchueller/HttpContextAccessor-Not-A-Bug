using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpContextAccessorBugDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IHttpContextAccessor _context;

        public TestController(IHttpContextAccessor context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"HttpContext is null: {_context.HttpContext == null}";
        }
    }
}
