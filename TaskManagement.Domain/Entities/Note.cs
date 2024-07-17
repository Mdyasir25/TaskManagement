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
    public class Note: Entity
    {
        [Required]
        public int TaskWorkId { get; private set; }
        [Required]
        public int EmployeeId { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public DateTime CreatedAt { get; private set; }
        public string? Document {  get; private set; }
        public bool IsActive { get; private set; } = true;

        public Note(int taskWorkId, int employeeId, string content, DateTime createdAt, string? document = null)
        {
            TaskWorkId = taskWorkId;
            EmployeeId = employeeId;
            Content = content;
            CreatedAt = createdAt;
            Document = document;
        }

        //Navigational property for Employee
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; private set; }

        //Navigational property for TaskWork
        [ForeignKey(nameof(TaskWorkId))]
        public TaskWork TaskWork { get; private set; }


    }
}
