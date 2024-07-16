using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Template
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string logo { get; set; }
        public string importance { get; set; }
        public List<string> descriptionVariablesList  {  get; set; }
    }


}
