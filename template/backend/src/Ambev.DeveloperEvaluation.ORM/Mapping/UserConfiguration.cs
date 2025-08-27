using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

/// <summary>
/// Entity Framework configuration for the User entity.
/// Maps entity properties and owned value objects to the Users table.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Phone)
            .HasMaxLength(20);

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt);

        builder.OwnsOne(u => u.Name, name =>
        {
            name.Property(n => n.Firstname)
                .HasColumnName("Firstname")
                .HasMaxLength(50);

            name.Property(n => n.Lastname)
                .HasColumnName("Lastname")
                .HasMaxLength(50);
        });

        builder.OwnsOne(u => u.Address, address =>
        {
            address.Property(a => a.City)
                .HasColumnName("City")
                .HasMaxLength(100);

            address.Property(a => a.Street)
                .HasColumnName("Street")
                .HasMaxLength(100);

            address.Property(a => a.Number)
                .HasColumnName("AddressNumber");

            address.Property(a => a.Zipcode)
                .HasColumnName("Zipcode")
                .HasMaxLength(20);

            address.OwnsOne(a => a.Geolocation, geo =>
            {
                geo.Property(g => g.Lat)
                    .HasColumnName("Latitude")
                    .HasPrecision(10, 8);

                geo.Property(g => g.Long)
                    .HasColumnName("Longitude")
                    .HasPrecision(11, 8);
            });
        });
    }
}
