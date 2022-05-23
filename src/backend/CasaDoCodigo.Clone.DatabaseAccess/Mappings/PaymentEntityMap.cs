using CasaDoCodigo.Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasaDoCodigo.Clone.DatabaseAccess.Mappings;

public class PaymentEntityMap : IEntityTypeConfiguration<PaymentEntity>
{
    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();
        builder.Property(x => x.LastName)
            .IsRequired();
        builder.Property(x => x.FiscalCode)
            .IsRequired();
        builder.Property(x => x.Address)
            .IsRequired();
        builder.Property(x => x.AddressComplement)
            .IsRequired();
        builder.Property(x => x.City)
            .IsRequired();
        builder.Property(x => x.PhoneNumber)
            .IsRequired();
        builder.Property(x => x.ZipCode)
            .IsRequired();

        builder.HasOne(x => x.Email)
            .WithOne(e => e.Payment)
            .HasForeignKey<PaymentEntity>(pk => pk.EmailId)
            .IsRequired();
        builder.HasOne(x => x.Country)
            .WithMany(c => c.Purposes)
            .IsRequired();
        builder.HasOne(x => x.State)
            .WithMany(s => s.Purposes);

        builder.ToTable("Payment");
    }
}
