using CasaDoCodigo.Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDoCodigo.Clone.DatabaseAccess.Mappings;

public class EmailEntityMap : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Value)
            .IsRequired();
        builder.HasIndex(p => p.Value).IsUnique();

        builder.ToTable("Email");
    }
}
