using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly TaskBoardAppDbContext dbContext;

        public HomeController(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;    
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = await dbContext.Boards.Select(b => b.Name).Distinct().ToListAsync();

            var tasksCount = new List<HomeBoardModel>();

            foreach (var boardName in taskBoards)
            {
                var tasksInBoard = dbContext.Tasks.Where(t => t.Board.Name == boardName).Count();

                tasksCount.Add(new HomeBoardModel
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                userTasksCount = dbContext.Tasks.Where(t => t.OwnerId == currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = dbContext.Tasks.Count(),
                BoardsWithTasksCount = tasksCount,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}