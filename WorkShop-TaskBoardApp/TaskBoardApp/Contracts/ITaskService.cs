using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Contracts
{
    public interface ITaskService
    {
        public Task<ICollection<TaskBoardModel>> LoadAllBoardsAsync();

        public Task AddAsync(string ownerId, TaskFormModel viewModel);

        public Task<TaskDetailsViewModel> DetailsAsync(string id);

        public Task EditTaskAsynch(string id, TaskFormModel model);

        public Task<TaskFormModel> FindTaskToEditByIdAsync(string id);

        public Task DeleteTaskById(string id);

        public Task<TaskViewModel> GetTaskByIdAsync(string id);
    }
}
