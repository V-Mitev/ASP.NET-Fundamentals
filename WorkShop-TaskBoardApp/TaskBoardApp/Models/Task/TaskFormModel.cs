using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidations.Task;

namespace TaskBoardApp.Models.Task
{
    public class TaskFormModel
    {
        public TaskFormModel()
        {
            Boards = new List<TaskBoardModel>();    
        }

        [Required]
        [StringLength(TitleMaxLength,
            MinimumLength = TitleMinLength,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage ="Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [DisplayName("Board")]
        public int BoardId { get; set; }

        public ICollection<TaskBoardModel> Boards { get; set; }
    }
}
