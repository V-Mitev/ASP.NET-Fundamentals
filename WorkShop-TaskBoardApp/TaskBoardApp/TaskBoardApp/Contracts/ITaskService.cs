using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Contracts
{
    public interface ITaskService
    {
        public Task<ICollection<TaskBoardModel>> LoadAllBoardsAsync();

        Task AddAsync(string ownerId, TaskFormModel viewModel);
    }
}
