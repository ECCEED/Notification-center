using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace NotificationCenterTemplateAPI.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        [NotMapped]
        public List<string> DescriptionVariablesList
        {
            get => JsonSerializer.Deserialize<List<string>>(DescriptionVariables) ?? new List<string>();
            set => DescriptionVariables = JsonSerializer.Serialize(value);
        }
        public string DescriptionVariables { get; set; }
    }
}
