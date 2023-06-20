using System.ComponentModel.DataAnnotations;
using static ForumApp.Common.EntityValidations.Post;

namespace ForumApp.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PostTitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PostContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
