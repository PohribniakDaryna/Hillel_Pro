namespace Reflection
{
    public class TaskItem
    {
        [DisplayName("Task title")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DisplayName("Task deadline")]
        public DateTime Deadline { get; set; }
    }
}