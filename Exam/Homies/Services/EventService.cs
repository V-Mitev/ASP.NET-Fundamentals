using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext data;

        public EventService(HomiesDbContext data)
        {
            this.data = data;
        }

        public async Task<ICollection<AllEventViewModel>> GetAllEventsAsync()
        {
            var allEvents = await data.Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();

            return allEvents;
        }

        public async Task GetNewEventAsync(AddEventViewModel model, string organaiserId)
        {
            Event @event = new Event()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = 
                DateTime.ParseExact(model.Start, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                End = 
                DateTime.ParseExact(model.End, "yyyy-MM-dd H:mm", CultureInfo.InvariantCulture),
                TypeId = model.TypeId,
                OrganiserId = organaiserId
            };

            await data.Events.AddAsync(@event);

            await data.SaveChangesAsync();
        }

        public async Task<ICollection<TypeViewModel>> GetTypeViewModelAAsync()
        {
            var types = await data.Types
                .Select(e => new TypeViewModel()
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync();

            return types;
        }
    }
}
