using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
