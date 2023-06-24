using TaskBoardApp.Models.Board;

namespace TaskBoardApp.Contracts
{
    public interface IBoardService
    {
        public Task<ICollection<BoardViewModel>> AllAsync();
    }
}
