using NotificationCenterTemplateAPI.Data;
using NotificationCenterTemplateAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotificationCenterTemplateAPI.Services
{
    public class TemplateService
    {
        private readonly ApplicationDbContext _context;

        public TemplateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Template> GetTemplates() => _context.Templates.ToList();

        public Template GetTemplate(int id) => _context.Templates.Find(id);

        public void AddTemplate(Template template)
        {
            _context.Templates.Add(template);
            _context.SaveChanges();
        }

        public void UpdateTemplate(Template template)
        {
            var existingTemplate = _context.Templates.Find(template.Id);
            if (existingTemplate != null)
            {
                existingTemplate.Name = template.Name;
                existingTemplate.Subject = template.Subject;
                existingTemplate.Description = template.Description;
                existingTemplate.Logo = template.Logo;
                existingTemplate.DescriptionVariables = template.DescriptionVariables;

                _context.Templates.Update(existingTemplate);
                _context.SaveChanges();
            }
        }

        public void DeleteTemplate(int id)
        {
            var template = _context.Templates.Find(id);
            if (template != null)
            {
                _context.Templates.Remove(template);
                _context.SaveChanges();
            }
        }
    }
}
