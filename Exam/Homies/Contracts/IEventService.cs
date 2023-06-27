using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        public Task<ICollection<AllEventViewModel>> GetAllEventsAsync();

        public Task GetNewEventAsync(AddEventViewModel model, string organaiserId);

        public Task<ICollection<TypeViewModel>> GetTypeViewModelAAsync();

        public Task<ICollection<AllEventViewModel>> EventParticipants(string userId);

        public Task JoinEventAsync(int eventId, string userId);

    }
}
