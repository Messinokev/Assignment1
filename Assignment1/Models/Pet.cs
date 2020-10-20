using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
public class Pet {
    public int Id { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
        [Range(0, 60, ErrorMessage = "Age should be between {1} and {2}")]
        public int Age { get; set; }
}
}