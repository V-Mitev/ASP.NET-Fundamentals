using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;    
        }

        public async Task<IActionResult> All()
        {
            var events = await eventService.GetAllEventsAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = new AddEventViewModel();

            model.Types = await eventService.GetTypeViewModelAAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetTypeViewModelAAsync();

                return View(model);
            }

            var organaiserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await eventService.GetNewEventAsync(model, organaiserId);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var events = await eventService.EventParticipants(userId);

            return View(events);
        }

        public async Task<IActionResult> Join(string id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await eventService.JoinEventAsync(int.Parse(id), userId);

                return RedirectToAction("Joined", "Event");
            }
            catch
            {
                return RedirectToAction("All", "Event");
            }
        }
    }
}
