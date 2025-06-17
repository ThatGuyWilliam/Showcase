using System.ComponentModel.DataAnnotations.Schema;

namespace Showcase.Models
{
    public class Showcase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHidden { get; set; }
    }
}
