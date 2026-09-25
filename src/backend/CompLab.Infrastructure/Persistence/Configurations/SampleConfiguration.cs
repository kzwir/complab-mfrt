using CompLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompLab.Infrastructure.Persistence.Configurations;

public sealed class SampleConfiguration
    : IEntityTypeConfiguration<Sample>
{
    public void Configure(
        EntityTypeBuilder<Sample> builder)
    {
        builder.ToTable("Samples");

        builder.HasKey(x => x.SampleId);

        builder.Property(x => x.SampleId)
            .ValueGeneratedNever();

        builder.Property(x => x.SampleNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.ProductionDate)
            .IsRequired();

        builder.HasIndex(x => x.SampleNumber)
            .IsUnique();

        builder.HasOne(x => x.Mixture)
            .WithMany(x => x.Samples)
            .HasForeignKey(x => x.MixtureId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Tests)
            .WithOne(x => x.Sample)
            .HasForeignKey(x => x.SampleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
