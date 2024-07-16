using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Domain.Entities
{
    public class TeamMember: Entity
    {
        [Required]
        public int CountryId { get; private set; }
        [Required]
        public int TeamLeadId { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public string Role { get; private set; } = nameof(TeamMember);
        public TeamMember(int countryId, int teamLeadId, string email, string firstName, string lastName, string password)
        {
            CountryId = countryId;
            TeamLeadId = teamLeadId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        //navigational property for Country
        public Country Country { get; set; }

        //navigational property for TeamLead
        public TeamLead TeamLead { get; set; }

        //navigational property for TaskWork because there is a one-to-many relationship between TeamMember and TaskWork
        private readonly List<TaskWork> taskWorks = new();
        public IReadOnlyCollection<TaskWork> TaskWorks => taskWorks.AsReadOnly();
    }
}
