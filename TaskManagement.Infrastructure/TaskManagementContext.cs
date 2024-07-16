using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.SeedWork;

namespace TaskManagement.Infrastructure
{
    public class TaskManagementContext : DbContext, IUnitOfWork
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TeamLead> TeamLeads { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TaskWork> TaskWorks { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
        {

        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
        {
            //Handle exceptions
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
