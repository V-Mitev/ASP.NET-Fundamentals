using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoardApp.Contracts;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel taskFormModel = new TaskFormModel()
            {
                Boards = await taskService.LoadAllBoardsAsync()
            };

            return View(taskFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Boards = await taskService.LoadAllBoardsAsync();
                return View(model);
            }

            if (!model.Boards.Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                model.Boards = await taskService.LoadAllBoardsAsync();
                return View(model);
            }

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.AddAsync(currentUserId, model);

            return RedirectToAction("All", "Board");
        }
    }
}
