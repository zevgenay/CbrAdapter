using CbrAdapter.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CbrAdapter.Database.Configurations
{
    public class KeyRateConfigurations : IEntityTypeConfiguration<KeyRate>
    {
        public void Configure(EntityTypeBuilder<KeyRate> builder)
        {
            builder.ToTable("KeyRates");
            builder.HasKey(u => u.Id);
        }
    }
}
