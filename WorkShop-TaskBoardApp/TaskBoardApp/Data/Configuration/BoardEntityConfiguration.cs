using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Models;
using TaskBoardApp.Data.Seed;

namespace TaskBoardApp.Data.Configuration
{
    public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        private readonly BoardSeeder boardSeeder;

        public BoardEntityConfiguration()
        {
            boardSeeder = new BoardSeeder();    
        }

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(boardSeeder.GenereteBoards());
        }
    }
}
