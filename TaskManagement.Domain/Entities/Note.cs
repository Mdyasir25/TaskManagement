using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int CreatorId { get; private set; }
        [Required]
        public bool CreatedByTeamLead { get; private set; }
        [Required]
        public string Content { get; private set; }
        [Required]
        public DateTime CreatedAt { get; private set; }
        public string? Document {  get; private set; }
        public bool IsActive { get; private set; } = true;

        public Note(int taskWorkId, int creatorId, bool createdByTeamLead, string content, DateTime createdAt, string? document = null)
        {
            TaskWorkId = taskWorkId;
            CreatorId = creatorId;
            CreatedByTeamLead = createdByTeamLead;
            Content = content;
            CreatedAt = createdAt;
            Document = document;
        }

        //navigational property for TeamLead
        public TeamLead TeamLead { get; private set; }

        //navigational property for TeamMember
        public TeamLead TeamMember { get; private set; }
    }
}
