using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
            builder.HasKey(s=>s.Id);
            builder.Property(s=>s.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(s=>s.Accounts).WithOne(s=>s.Role).HasForeignKey(s=>s.RoleId);
        }
    }
}
