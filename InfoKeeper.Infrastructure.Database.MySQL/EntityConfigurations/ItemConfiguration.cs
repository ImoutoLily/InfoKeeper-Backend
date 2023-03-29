using InfoKeeper.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoKeeper.Infrastructure.Database.MySQL.EntityConfigurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(10_000);

        builder.Property(x => x.CreationDateTime)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Items);
    }
}