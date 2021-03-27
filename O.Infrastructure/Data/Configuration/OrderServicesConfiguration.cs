using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using O.Entities.Entities;

namespace O.Infrastructure.Data.Configuration
{
    public class OrderServicesConfiguration : IEntityTypeConfiguration<OrderServices>
    {
        public void Configure(EntityTypeBuilder<OrderServices> builder)
        {

        }
    }
}
