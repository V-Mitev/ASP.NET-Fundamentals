using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidations.Event;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        public AddEventViewModel()
        {
            Types = new HashSet<TypeViewModel>();    
        }

        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; }
    }
}
