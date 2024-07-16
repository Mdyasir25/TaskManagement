using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Domain.Entities
{
    //Task entity is named TaskWork instead to avoid conflict with "Task" keyword
    public class TaskWork: Entity   
    {
        public enum STATUS
        {
            Pending,
            InProgress,
            Completed
        }
        public enum PRIORITY
        {
            Low,
            Medium,
            High
        }
        [Required]
        public int TeamLeadId { get; private set; }  //Assigned By
        [Required]
        public int TeamMemberId { get; set; }     //Assigned To
        [Required]
        public string Title { get; private set; }
        public string? TaskDescription { get; private set; }
        [Required]
        public PRIORITY Priority { get; private set; }  
        public bool IsActive { get; private set; } = true;
        [Required]
        public STATUS Status { get; private set; } = STATUS.Pending;
        [Required]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [Required]
        public DateTime DueDate { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public bool TATBreached { get; private set; } = false;

        public TaskWork(int teamLeadId, int teamMemberId, string title, PRIORITY priority, DateTime dueDate, string? taskDescription = null, DateTime? completedAt = null)
        {
            TeamLeadId = teamLeadId;
            TeamMemberId = teamMemberId;
            Title = title;
            Priority = priority;
            DueDate = dueDate;
            TaskDescription = taskDescription;
            CompletedAt = completedAt;
        }

        public TeamLead TeamLead { get; private set; }
        public TeamMember TeamMember { get; private set; }

        //navigational property for Notes because there is a one-to-many relationship between TaskWork and Notes
        private readonly List<Note> notes = new();
        public IReadOnlyCollection<Note> Notes => notes.AsReadOnly();
    }
}
