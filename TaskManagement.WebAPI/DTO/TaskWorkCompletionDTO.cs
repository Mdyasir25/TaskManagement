namespace TaskManagement.WebAPI.DTO
{
    public record TaskWorkCompletionDTO
    {
        public required DateTime CompletionDate { get; set; }
    }
}
