using FinExChange.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FinExChange.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasColumnType("nvarchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .HasColumnType("nvarchar(256)")
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(u => u.PhoneNumber)
                .HasColumnType("nvarchar(15)")
                .HasMaxLength(15);

            builder.Property(u => u.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Configuração de relacionamento com a entidade Transaction, se necessário
            // builder.HasMany(u => u.Transactions)
            //     .WithOne(t => t.User)
            //     .HasForeignKey(t => t.UserId);
        }
    }
}
