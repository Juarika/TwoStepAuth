using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.Property(p => p.Id)
        .IsRequired();

        builder.Property(p => p.UserName)
        .IsRequired()
        .HasColumnName("username")
        .HasColumnType("varchar")
        .HasMaxLength(50);

        builder.Property(p => p.Password)
       .IsRequired()
       .HasColumnName("password")
       .HasColumnType("varchar")
       .HasMaxLength(50);

        builder.Property(p => p.Email)
        .IsRequired()
        .HasColumnName("email")
        .HasColumnType("varchar")
        .HasMaxLength(60);

        builder.Property(p => p.TwoSecret)
        .IsRequired()
        .HasColumnName("twostepsecret");

        builder.Property(p => p.Phone)
        .IsRequired()
        .HasColumnName("phone")
        .HasColumnType("varchar")
        .HasMaxLength(15);
    }
}