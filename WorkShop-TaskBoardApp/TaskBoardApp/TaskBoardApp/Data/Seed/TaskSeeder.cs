namespace TaskBoardApp.Data.Seed
{
    using Task = Models.Task;

    public class TaskSeeder 
    {
        public ICollection<Task> GenereteTasks() 
        {
            ICollection<Task> tasks = new HashSet<Task>();

            Task task;

            task = new Task()
            {
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371",
                BoardId = 1
            };
            tasks.Add(task);

            task = new Task()
            {
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-5),
                OwnerId = "bdc7d1a9-f7fc-43be-a5c4-75307e710e33",
                BoardId = 1
            };
            tasks.Add(task);

            task = new Task()
            {
                Title = "Dekstop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddMonths(-1),
                OwnerId = "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371",
                BoardId = 2
            };
            tasks.Add(task);

            task = new Task()
            {
                Title = "Create Tasks",
                Description = "Implement [Create Tasks] page for adding new tasks",
                CreatedOn = DateTime.Now.AddYears(-1),
                OwnerId = "5bce5f4e-3c8a-4a30-a3f5-ca0c242ca371",
                BoardId = 3
            };
            tasks.Add(task);

            return tasks;
        }
    }
}
