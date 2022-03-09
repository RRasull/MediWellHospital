using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Models;

namespace Data.Configurations
{
    class WelcomeConfiguration : IEntityTypeConfiguration<Welcome>
    {
        public void Configure(EntityTypeBuilder<Welcome> builder)
        {
            builder.Property(w => w.Title).IsRequired().HasMaxLength(255);
            builder.Property(w => w.Content).IsRequired().HasMaxLength(255);
            builder.Property(w => w.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}
