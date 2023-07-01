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

            var events = await eventService.GetJoinedEventsAsync(userId);

            return View(events);
        }

        public async Task<IActionResult> Join(int id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await eventService.JoinEventAsync(id, userId);

                return RedirectToAction("Joined", "Event");
            }
            catch
            {
                return RedirectToAction("All", "Event");
            }
        }

        public async Task<IActionResult> Leave(int id)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await eventService.LeaveEventAsync(id, userId);

                return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var @event = await eventService.FindEventAsync(id);

            @event.Types = await eventService.GetTypeViewModelAAsync();

            return View(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetTypeViewModelAAsync();

                ModelState.AddModelError("", "Invalid data!");

                return View(model);
            }

            try
            {
                await this.eventService.EditEventAsync(model);

                return RedirectToAction("All", "Event");
            }
            catch (InvalidDataException e)
            {
                model.Types = await eventService.GetTypeViewModelAAsync();

                ModelState.AddModelError("", e.Message);

                return View(model);
            }
        }
    }
}
