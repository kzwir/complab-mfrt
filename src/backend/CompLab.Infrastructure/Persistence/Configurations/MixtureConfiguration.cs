using CompLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompLab.Infrastructure.Persistence.Configurations;

public sealed class MixtureConfiguration
    : IEntityTypeConfiguration<Mixture>
{
    public void Configure(
        EntityTypeBuilder<Mixture> builder)
    {
        builder.ToTable("Mixtures");

        builder.HasKey(x => x.MixtureId);

        builder.Property(x => x.MixtureId)
            .ValueGeneratedNever();

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PolymerPercent)
            .HasPrecision(5, 2);

        builder.Property(x => x.QuartzitePercent)
            .HasPrecision(5, 2);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasMany(x => x.Samples)
            .WithOne(x => x.Mixture)
            .HasForeignKey(x => x.MixtureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
