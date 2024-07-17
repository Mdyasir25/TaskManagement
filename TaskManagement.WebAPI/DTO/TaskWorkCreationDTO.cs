using static TaskManagement.Domain.Entities.TaskWork;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebAPI.DTO
{
    public record TaskWorkCreationDTO
    {
        public required string Title { get; set; }
        public string? TaskDescription { get; set; }
        public required PRIORITY Priority { get; set; }
        public required DateTime DueDate { get; set; }
    }
}
