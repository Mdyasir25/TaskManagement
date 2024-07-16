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
                    context.Employees.Add(new Domain.Entities.Employee("Admin@gmail.com", "Admin", "Admin", "Password", Employee.ROLE.Admin));
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
