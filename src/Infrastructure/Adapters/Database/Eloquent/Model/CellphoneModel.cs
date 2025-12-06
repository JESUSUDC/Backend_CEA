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
                .IsRequired(false);

            builder.Property(t => t.Imei)
                .HasMaxLength(50)
                .IsRequired(false);

            // Display and camera
            builder.Property(t => t.Inches)
                .IsRequired(false);

            builder.Property(t => t.Megapixels)
                .IsRequired(false);

            builder.Property(t => t.CamerasCount)
                .IsRequired(false);

            // Memory and storage
            builder.Property(t => t.RamGb)
                .IsRequired(false);

            builder.Property(t => t.PrimaryStorageGb)
                .IsRequired(false);

            builder.Property(t => t.SecondaryStorageGb)
                .IsRequired(false);

            // Software / operator / radio tech
            builder.Property(t => t.OperatingSystem)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(t => t.Carrier)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(t => t.BandTechnology)
                .HasMaxLength(100)
                .IsRequired(false);

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
                .IsRequired(false);

            builder.Property(t => t.CpuSpeedGhz)
                .IsRequired(false);

            // Other
            builder.Property(t => t.HasWaterResistance)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.SimCount)
                .IsRequired();

            // Indexes
            builder.HasIndex(t => t.Imei)
                .HasDatabaseName("IX_Cellphones_Imei");

            builder.Property(t => t.CreateAt)
                .IsRequired();

            builder.Property(t => t.UpdateAt)
                .IsRequired();
        }
    }
}
