using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidations.Type;

namespace Homies.Data.Models
{
    public class Type
    {
        public Type()
        {
            Events = new List<Event>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TypeNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; }
    }
}
