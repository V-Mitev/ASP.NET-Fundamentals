using System.ComponentModel.DataAnnotations;

namespace ForumApp.ViewModels.Post
{
    public class PostViewModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;
    }
}
