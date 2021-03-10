using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryMVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
    }
}
