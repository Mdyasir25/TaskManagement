using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Domain.Entities
{
    public class Admin: Entity
    {
        public int CountryId { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string Firstname { get; private set; }
        [Required]
        public string Lastname { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; private set; }
        public bool IsActive { get; private set; } = true;
        [Required]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public string Role { get; private set; } = nameof(Admin);

        public Admin(int countryId, string email, string firstname, string lastname, string password)
        {
            CountryId = countryId;
            Email = email;
            Firstname = firstname;
            Lastname = lastname;
            Password = password;
        }

        //navigational property for Country
        public Country Country { get; private set; }
    }
}
