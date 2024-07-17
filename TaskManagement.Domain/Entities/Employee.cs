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
    public class Employee: Entity
    {
        public enum ROLE
        {
            Admin,
            Manager,
            Subordinate
        }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string Firstname { get; private set; }
        [Required]
        public string Lastname { get; private set; }
        [Required]
        public string Password { get; private set; }
        [Required]
        public ROLE Role { get; private set; } = ROLE.Subordinate;
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public Employee(string email, string firstname, string lastname, string password, int? managerId = null)
        {
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
            ManagerId = managerId;
        }

        // ForeignKey for Manager
        public int? ManagerId { get; set; }

        // Navigation property for Manager
        [ForeignKey("ManagerId")]
        public Employee? Manager { get; set; }

        // Navigation property for Subordinates 
        private readonly List<Employee> subordinates = new();
        public IReadOnlyCollection<Employee> Subordinates => subordinates.AsReadOnly();


        //Navigational property for TaskWorks
        private readonly List<TaskWork> taskWorks = new();
        public IReadOnlyCollection<TaskWork> TaskWorks => taskWorks.AsReadOnly();

        //Navigational property for Notes
        private readonly List<Note> notes = new();
        public IReadOnlyCollection<Note> Notes => notes.AsReadOnly();

    }
}
