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
    public class TaskWorkConfiguration : IEntityTypeConfiguration<TaskWork>
    {
        public void Configure(EntityTypeBuilder<TaskWork> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(TaskWork.Notes));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
