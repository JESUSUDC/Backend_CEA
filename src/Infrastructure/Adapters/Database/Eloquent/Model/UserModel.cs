using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Users.Entity;

namespace Infrastructure.Adapters.Database.Eloquent.Model
{
    public class UserModel : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasConversion(
                gene => gene.Value,
                valor => new UserId(valor));

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.PasswordHash)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasMany(t => t.Cellphones)
                .WithOne()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.CreateAt)
                .IsRequired();

            builder.Property(t => t.UpdateAt)
                .IsRequired();
        }
    }
}
