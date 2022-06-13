using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EfCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable(nameof(Inventory));
            builder.HasKey(x => x.Id);
            builder.OwnsMany(s => s.InventoryOperations, modelbuilder =>
            {
                modelbuilder.ToTable(nameof(InventoryOperation));
                modelbuilder.HasKey(x => x.Id);
                modelbuilder.Property(s => s.Description).HasMaxLength(1000);
                modelbuilder.WithOwner(s => s.Inventory).HasForeignKey(s => s.InventoryId);
            });
        }
    }
}
