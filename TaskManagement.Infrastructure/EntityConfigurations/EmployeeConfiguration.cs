using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var navigationSO = builder.Metadata.FindNavigation(nameof(Employee.Subordinates));
            navigationSO.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationTW = builder.Metadata.FindNavigation(nameof(Employee.TaskWorks));
            navigationTW.SetPropertyAccessMode(PropertyAccessMode.Field);

            var navigationNotes = builder.Metadata.FindNavigation(nameof(Employee.Notes));
            navigationNotes.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
