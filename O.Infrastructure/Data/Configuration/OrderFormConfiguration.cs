using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O.Entities.Entities;

namespace O.Infrastructure.Data.Configuration
{
    public class OrderFormConfiguration : IEntityTypeConfiguration<OrderForm>
    {
        public void Configure(EntityTypeBuilder<OrderForm> builder)
        {
            builder.HasKey(ab => ab.Id);
            builder.HasMany(ab => ab.OrderServices).WithOne(ab => ab.OrderForm).HasForeignKey(ab => ab.OrderFormId);
            builder.Property(o => o.AddressFrom).HasMaxLength(500);
            builder.Property(o => o.AddressTo).HasMaxLength(500);
            builder.Property(o => o.AdditionNotes).HasMaxLength(4000);
        }
    }
}
