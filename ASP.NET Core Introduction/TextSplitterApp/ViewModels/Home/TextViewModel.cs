using System.ComponentModel.DataAnnotations;
using TextSplitterApp.Common;

namespace TextSplitterApp.ViewModels.Home
{
    public class TextViewModel
    {
        [Required]
        [StringLength(ValidationConstants.TextMaximumLength,
            MinimumLength = ValidationConstants.TextMinimumLength,
            ErrorMessage = 
            "The field Text must be a string with a minimum length of 2 and maximum length of 30.")]
        public string Text { get; set; } = null!;

        public string SplitText { get; set; } = null!;
    }
}
