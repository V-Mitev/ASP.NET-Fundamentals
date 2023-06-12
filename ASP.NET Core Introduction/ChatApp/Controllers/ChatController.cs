using ChatApp.Models.Chat;
using ChatApp.ViewModels.Chat;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public static ICollection<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            ChatViewModel chatModel = new ChatViewModel()
            {
                Messages = messages.Select(s => new MessageViewModel()
                {
                    Sender = s.Key,
                    MessageText = s.Value
                })
                .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessages = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>(newMessages.Sender, newMessages.MessageText));

            return RedirectToAction("Show");
        }
    }
}
