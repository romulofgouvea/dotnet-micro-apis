using Microsoft.AspNetCore.Mvc;

namespace Api2.Application.Controllers
{
    [Produces("application/json")]
    [Route("showmethecode")]
    public class ShowCodeController : Controller
    {
        [HttpGet]
        public IActionResult ShowMeTheCode()
        {
            return Redirect("https://github.com/romulofgouvea/dotnet-micro-apis");
        }
    }
}
