using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));

            builder.HasKey(x => x.Id);

            builder.Property(s => s.FullName).HasMaxLength(100).IsRequired();
            builder.Property(s => s.UserName).HasMaxLength(100).IsRequired();
            builder.Property(s => s.Password).HasMaxLength(1000).IsRequired();
            builder.Property(s => s.Mobile).HasMaxLength(20).IsRequired();
            builder.Property(s => s.ProfilePhoto).HasMaxLength(500).IsRequired();

            builder.HasOne(s => s.Role).WithMany(s => s.Accounts).HasForeignKey(s => s.RoleId);
        }
    }
}
