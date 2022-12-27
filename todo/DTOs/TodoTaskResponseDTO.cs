namespace Todo.DTOs
{
    public class TodoTaskResponseDTO
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
