namespace TaskBoardApp.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            BoardsWithTasksCount = new List<HomeBoardModel>();
        }

        public int AllTasksCount { get; set; }

        public ICollection<HomeBoardModel> BoardsWithTasksCount { get; set; }

        public int UserTasksCount { get; set; }
    }
}
