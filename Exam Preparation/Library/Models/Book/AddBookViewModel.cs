using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidations.Book;

namespace Library.Models.Book
{
    public class AddBookViewModel
    {
        public AddBookViewModel()
        {
            Categories = new HashSet<CategoryViewModel>();
        }

        [Required]
        [Display(Name = "Title")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set;} = null!;

        [Required]
        [Range(typeof(decimal), RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
