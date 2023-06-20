using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.EntityValidations.Post;

namespace ForumApp.ViewModels.Post
{
    public class PostFormViewModel
    {
        [Required]
        [StringLength(PostTitleMaxLength, MinimumLength = PostTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
