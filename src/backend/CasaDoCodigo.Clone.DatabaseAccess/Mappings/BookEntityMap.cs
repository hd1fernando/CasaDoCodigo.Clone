using CasaDoCodigo.Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDoCodigo.Clone.DatabaseAccess.Mappings;

public class BookEntityMap : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
           .IsRequired();
        builder.Property(b => b.Abstract)
           .IsRequired()
           .HasMaxLength(500);
        builder.Property(b => b.Summary);
        builder.Property(b => b.Price)
            .IsRequired();
        builder.Property(b => b.NumOfPages)
            .IsRequired();
        builder.Property(b => b.ISBN)
            .IsRequired();
        builder.Property(b => b.PublicationDate)
            .IsRequired();

        builder.HasIndex(b => b.ISBN)
            .IsUnique();
        builder.HasIndex(b => b.Title)
            .IsUnique();

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .IsRequired();
        builder.HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .IsRequired();

        builder.ToTable("Book");
    }
}
