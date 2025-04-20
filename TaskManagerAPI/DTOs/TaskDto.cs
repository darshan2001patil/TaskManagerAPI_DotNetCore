namespace TaskManager.Api.DTOs
{
    public class TaskDto
    {
        public Int64 Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedTo { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
    }
}