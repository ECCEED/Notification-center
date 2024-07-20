using Microsoft.AspNetCore.Mvc;
using NotificationCenterTemplateAPI.Models;
using NotificationCenterTemplateAPI.Services;

namespace NotificationCenterTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly TemplateService _templateService;

        public TemplateController(TemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Template>> GetTemplates() => Ok(_templateService.GetTemplates());

        [HttpGet("{id}")]
        public ActionResult<Template> GetTemplate(int id)
        {
            var template = _templateService.GetTemplate(id);
            if (template == null)
                return NotFound();
            return Ok(template);
        }

        [HttpPost]
        public ActionResult AddTemplate([FromBody] Template template)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Field = e.Key,
                        Message = string.Join(", ", e.Value.Errors.Select(err => err.ErrorMessage))
                    })
                    .ToList();

                return BadRequest(new { Errors = errors });
            }
            _templateService.AddTemplate(template);



            return CreatedAtAction(nameof(GetTemplate), new { id = template.Id }, template);


        }

        [HttpPut("{id}")]
        public ActionResult UpdateTemplate(int id, Template template)
        {
            if (id != template.Id)
                return BadRequest();

            var existingTemplate = _templateService.GetTemplate(id);
            if (existingTemplate == null)
                return NotFound();

            _templateService.UpdateTemplate(template);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTemplate(int id)
        {
            var existingTemplate = _templateService.GetTemplate(id);
            if (existingTemplate == null)
                return NotFound();

            _templateService.DeleteTemplate(id);
            return NoContent();
        }
    }
}

