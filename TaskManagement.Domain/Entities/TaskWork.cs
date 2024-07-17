using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[Required]
        //public int AssignedById { get; private set; }
        [Required]
        public int EmployeeId { get; set; }    
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

        public TaskWork(int employeeId, string title, PRIORITY priority, DateTime dueDate, string? taskDescription = null, DateTime? completedAt = null)
        {
            //AssignedById = assignedBy;
            EmployeeId = employeeId;
            Title = title;
            Priority = priority;
            DueDate = dueDate;
            TaskDescription = taskDescription;
            CompletedAt = completedAt;
        }

        //[ForeignKey(nameof(AssignedById))]
        //public Employee AssignedBy { get; private set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; private set; }

        //Navigational property for Notes
        private readonly List<Note> notes = new();
        public IReadOnlyCollection<Note> Notes => notes.AsReadOnly();
    }
}
