using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Cellphones.Entity;
using Domain.Users.Entity;

namespace Infrastructure.Adapters.Database.Eloquent.Model
{
    public class CellphoneModel : IEntityTypeConfiguration<Cellphone>
    {
        public void Configure(EntityTypeBuilder<Cellphone> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).HasConversion(
                gene => gene.Value,
                valor => new CellphoneId(valor));

            builder.Property(t => t.UserId).HasConversion(
                gene => gene.Value,
                valor => new UserId(valor));

            // Basic identifiers
            builder.Property(t => t.Brand)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Imei)
                .HasMaxLength(50)
                .IsRequired();

            // Display and camera
            builder.Property(t => t.Inches)
                .IsRequired();

            builder.Property(t => t.Megapixels)
                .IsRequired();

            builder.Property(t => t.CamerasCount)
                .IsRequired();

            // Memory and storage
            builder.Property(t => t.RamGb)
                .IsRequired();

            builder.Property(t => t.PrimaryStorageGb)
                .IsRequired();

            builder.Property(t => t.SecondaryStorageGb)
                .IsRequired();

            // Software / operator / radio tech
            builder.Property(t => t.OperatingSystem)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Carrier)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.BandTechnology)
                .HasMaxLength(100)
                .IsRequired();

            // Connectivity & sensors
            builder.Property(t => t.HasWifi)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.HasBluetooth)
                .IsRequired()
                .HasDefaultValue(false);


            builder.Property(t => t.HasNfc)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.HasFingerprint)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.HasInfrared)
                .IsRequired()
                .HasDefaultValue(false);

            // CPU
            builder.Property(t => t.CpuBrand)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.CpuSpeedGhz)
                .IsRequired();

            // Other
            builder.Property(t => t.HasWaterResistance)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.SimCount)
                .IsRequired();

            // Indexes
            builder.HasIndex(t => t.Imei)
                .HasDatabaseName("IX_Cellphones_Imei");

            // Configuración explícita de la relación 1:N (Cellphone -> User)
            builder.HasOne(t => t.User) // La propiedad de navegación en Cellphone
                .WithMany(u => u.Cellphones) // La propiedad de navegación en User
                .HasForeignKey(t => t.UserId); // **Usar la propiedad UserId ya mapeada/convertida**

            builder.Property(t => t.CreateAt)
                .IsRequired();

            builder.Property(t => t.UpdateAt)
                .IsRequired();
        }
    }
}
