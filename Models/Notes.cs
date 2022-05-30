using System.ComponentModel.DataAnnotations;

namespace NoteSandbax.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string body { get; set; }

    }
}
