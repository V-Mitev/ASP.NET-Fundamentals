using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Contracts;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext dbContext;

        public TaskService(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(string ownerId, TaskFormModel viewModel)
        {
            Data.Models.Task task = new Data.Models.Task()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                BoardId = viewModel.BoardId,
                CreatedOn = DateTime.UtcNow,
                OwnerId = ownerId
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<TaskBoardModel>> LoadAllBoardsAsync()
        {
            ICollection<TaskBoardModel> boardsToLoad = await dbContext.Boards
                .Select(b => new TaskBoardModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

            return boardsToLoad;
        }

        public async Task<TaskDetailsViewModel> DetailsAsync(string id)
        {
            TaskDetailsViewModel viewModel = await dbContext.Tasks
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.Owner.UserName,
                    CreatedOn = t.CreatedOn.ToString("f"),
                    Board = t.Board.Name
                })
                .FirstAsync(t => t.Id == id);

            return viewModel;
        }

        public async Task<TaskFormModel> FindTaskToEditByIdAsync(string id)
        {
            var task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);

            TaskFormModel taskToEdit = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId
            };

            return taskToEdit;
        }

        public async Task EditTaskAsynch(string id, TaskFormModel model)
        {
            var taskToEdit = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);

            taskToEdit.Title = model.Title;
            taskToEdit.Description = model.Description;
            taskToEdit.BoardId = model.BoardId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskById(string id)
        {
            var taskToDelete = await dbContext.Tasks
                .FirstOrDefaultAsync(t => t.Id.ToString() == id);
            
            dbContext.Remove(taskToDelete);

            await dbContext.SaveChangesAsync();
        }

        public async Task<TaskViewModel> GetTaskByIdAsync(string id)
        {
            var task = await dbContext.Tasks.FirstAsync(t => t.Id.ToString() == id);

            TaskViewModel taskToDelete = new TaskViewModel()
            {
                Title = task.Title,
                Description = task.Description,
                Id = task.Id.ToString()
            };

            return taskToDelete;
        }
    }
}
