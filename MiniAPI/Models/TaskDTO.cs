using MiniAPI.Models;

public class TaskDTO {

    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    //public DateTime DueDate { get; set; }
    public string? DueDate { get; set; }

    public TaskDTO() { }

    public TaskDTO(TaskModel task) {
        Id = task.Id;
        Title = task.Title;
        Description = task.Description;
        DueDate = task.DueDate;
    }
}