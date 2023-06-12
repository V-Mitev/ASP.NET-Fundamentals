using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models.Chat
{
    public class MessageViewModel
    {
        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Sender { get; set; } = null!;

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string MessageText { get; set; } = null!;
    }
}
