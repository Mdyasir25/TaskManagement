using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Domain.Entities
{
    public class Notification: Entity
    {
        [Required]
        public int UserId { get; private set; }
        [Required]
        public string Role { get; private set; }
        [Required]
        public int Title { get; private set; }
        [Required]
        public int Description { get; private set; }
        public DateTime DateCreated { get; private set; } = DateTime.Now;
        public Notification(int userId, string role, int title, int description)
        {
            UserId = userId;
            Role = role;
            Title = title;
            Description = description;
        }
    }
}
