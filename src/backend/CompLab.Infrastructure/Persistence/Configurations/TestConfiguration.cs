using CompLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompLab.Infrastructure.Persistence.Configurations;

public sealed class TestConfiguration
    : IEntityTypeConfiguration<Test>
{
    public void Configure(
        EntityTypeBuilder<Test> builder)
    {
        builder.ToTable("Tests");

        builder.HasKey(x => x.TestId);

        builder.Property(x => x.TestId)
            .ValueGeneratedNever();

        builder.Property(x => x.TestType)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MeasurementValue)
            .HasPrecision(18, 4)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.Sample)
            .WithMany(x => x.Tests)
            .HasForeignKey(x => x.SampleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
