using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure
{
    public class TaskManagementContextSeed
    {
        public static async Task SendAsync(TaskManagementContext context)
        {
            try
            {
                if (!context.Employees.Any())
                {
                    context.Employees.Add(new Domain.Entities.Employee("Admin@admin.com", "AdminFirstName", "AdminLastName", "10d6993f3b19c9a801ab0c1c89d98d2f59598324aa7500471f5d9ed42668ad68"));
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }
        }
    }
}
