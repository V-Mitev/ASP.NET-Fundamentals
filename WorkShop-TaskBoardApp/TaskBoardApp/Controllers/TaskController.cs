using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            
            if (!taskService.LoadAllBoardsAsync().Result.Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), "Selected board does not exist!");
                model.Boards = await taskService.LoadAllBoardsAsync();
                return View(model);
            }

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await taskService.AddAsync(currentUserId, model);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            TaskDetailsViewModel model = await taskService.DetailsAsync(id);

            if (model == null)
            {
                ModelState.AddModelError(nameof(model.Owner), "This task doesn't exists");

                return RedirectToAction("All", "Board");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await taskService.FindTaskToEditByIdAsync(id);

            model.Boards = await taskService.LoadAllBoardsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, TaskFormModel model)
        {
            await taskService.EditTaskAsynch(id, model);

            if (!ModelState.IsValid)
            {
                return RedirectToAction("All", "Board");
            }
            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await taskService.GetTaskByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, TaskFormModel model)
        {
            try
            {
                await taskService.DeleteTaskById(id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while deleting your post!");
                return View(model);
            }

            return RedirectToAction("All", "Board");
        }        
    }
}
