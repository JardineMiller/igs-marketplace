using Microsoft.AspNetCore.Mvc;

namespace marketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase {}
}
