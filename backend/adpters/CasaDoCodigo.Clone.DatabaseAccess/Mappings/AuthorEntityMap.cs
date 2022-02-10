using CasaDoCodigo.Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDoCodigo.Clone.DatabaseAccess.Mappings
{
    public class AuthorEntityMap : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(400);
            builder.Property(p => p.Email)
                .IsRequired();
            builder.Property(p => p.RegistrationTime)
                .IsRequired();

            builder.ToTable("Author");
        }
    }
}