using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data.Seed
{
    public class BoardSeeder
    {
        public ICollection<Board> GenereteBoards()
        {
            ICollection<Board> result = new HashSet<Board>();

            Board board;

            board = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            result.Add(board);

            board = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            result.Add(board);

            board = new Board()
            {
                Id = 3,
                Name = "Done"
            };
            result.Add(board);

            return result;
        }
    }
}
