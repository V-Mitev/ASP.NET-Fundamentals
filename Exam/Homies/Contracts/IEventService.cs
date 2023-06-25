using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        public Task<ICollection<AllEventViewModel>> GetAllEventsAsync();

        public Task GetNewEventAsync(AddEventViewModel model, string organaiserId);

        public Task<ICollection<TypeViewModel>> GetTypeViewModelAAsync();
    }
}
