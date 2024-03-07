using System.ComponentModel.DataAnnotations;

namespace algorithm.Models.Base
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
