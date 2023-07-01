using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        public Task<ICollection<AllEventViewModel>> GetAllEventsAsync();

        public Task GetNewEventAsync(AddEventViewModel model, string organaiserId);

        public Task<ICollection<TypeViewModel>> GetTypeViewModelAAsync();

        public Task<ICollection<AllEventViewModel>> GetJoinedEventsAsync(string userId);

        public Task JoinEventAsync(int eventId, string userId);

        public Task LeaveEventAsync(int eventId, string userId);

        public Task EditEventAsync(AddEventViewModel model);

        public Task<AddEventViewModel> FindEventAsync(int eventId);
    }
}
