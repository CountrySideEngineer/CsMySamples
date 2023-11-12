namespace WebAPI_001.Models
{
    public class ToDoItemDTO
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public bool IsComplete { get; set; }
    }
}
