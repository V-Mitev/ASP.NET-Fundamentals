using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Seed;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        private readonly TaskSeeder taskSeeder;

        public TaskEntityConfiguration()
        {
            taskSeeder = new TaskSeeder();
        }

        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(taskSeeder.GenereteTasks());
        }
    }
}
