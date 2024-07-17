namespace TaskManagement.WebAPI.DTO
{
    public record NoteCreationDTO
    {
        public required int EmployeeId { get; set; }
        public required string Content { get; set; }
        public required DateTime DueDate { get; set; }
        public string? Document { get; set; }
    }
}
