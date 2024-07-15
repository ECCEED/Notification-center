using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{




    [ApiController]
    [Route("[controller]")]
    public class TemplateController : Controller
    {




        // POST: TemplateController/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create([FromBody] TemplateCreateModel request)
        {
            Console.WriteLine("hi the data is " + request.input);
            return Ok(new { message = "done" });

        }



    } 
}
