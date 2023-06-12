using ChatApp.Models.Chat;

namespace ChatApp.ViewModels.Chat
{
    public class ChatViewModel
    {
        public ChatViewModel()
        {
            Messages = new List<MessageViewModel>();
        }

        public MessageViewModel CurrentMessage { get; set; } = null!;

        public ICollection<MessageViewModel> Messages { get; set; }
    }
}
