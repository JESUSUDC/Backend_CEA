
using Domain.Users.Entity;

namespace Domain.Cellphones.Entity
{
    public class Cellphone : GenericEntity<CellphoneId>
    {
        public UserId UserId { get; set; }
        // Basic identifiers
        public string Brand { get; private set; }
        public string Imei { get; private set; }

        // Display and camera
        public double Inches { get; private set; }
        public double Megapixels { get; private set; }
        public int CamerasCount { get; private set; }

        // Memory and storage (sizes in GB)
        public int RamGb { get; private set; }
        public int PrimaryStorageGb { get; private set; }
        public int? SecondaryStorageGb { get; private set; }

        // Software / operator / radio tech
        public string OperatingSystem { get; private set; }
        public string Carrier { get; private set; }
        public string BandTechnology { get; private set; }

        // Connectivity & sensors
        public bool HasWifi { get; private set; }
        public bool HasBluetooth { get; private set; }
        public bool HasNfc { get; private set; }
        public bool HasFingerprint { get; private set; }
        public bool HasInfrared { get; private set; }

        // CPU
        public string CpuBrand { get; private set; }
        public double CpuSpeedGhz { get; private set; }

        // Other
        public bool HasWaterResistance { get; private set; }
        public int SimCount { get; private set; }

        public User? User { get; private set; }

        public Cellphone(
            CellphoneId id,
            UserId userId,
            string brand,
            string imei,
            double inches,
            double megapixels,
            int camerasCount,
            int ramGb,
            int primaryStorageGb,
            int? secondaryStorageGb,
            string operatingSystem,
            string carrier,
            string bandTechnology,
            bool hasWifi,
            bool hasBluetooth,
            bool hasNfc,
            bool hasFingerprint,
            bool hasInfrared,
            string cpuBrand,
            double cpuSpeedGhz,
            bool hasWaterResistance,
            int simCount
        ) : base(id)
        {
            UserId = userId;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Imei = imei ?? throw new ArgumentNullException(nameof(imei));
            Inches = inches;
            Megapixels = megapixels;
            CamerasCount = camerasCount;
            RamGb = ramGb;
            PrimaryStorageGb = primaryStorageGb;
            SecondaryStorageGb = secondaryStorageGb;
            OperatingSystem = operatingSystem ?? throw new ArgumentNullException(nameof(operatingSystem));
            Carrier = carrier ?? throw new ArgumentNullException(nameof(carrier));
            BandTechnology = bandTechnology ?? throw new ArgumentNullException(nameof(bandTechnology));
            HasWifi = hasWifi;
            HasBluetooth = hasBluetooth;
            HasNfc = hasNfc;
            HasFingerprint = hasFingerprint;
            HasInfrared = hasInfrared;
            CpuBrand = cpuBrand ?? throw new ArgumentNullException(nameof(cpuBrand));
            CpuSpeedGhz = cpuSpeedGhz;
            HasWaterResistance = hasWaterResistance;
            SimCount = simCount;
        }

        public void Update(
            UserId userId,
            string brand,
            string imei,
            double inches,
            double megapixels,
            int camerasCount,
            int ramGb,
            int primaryStorageGb,
            int? secondaryStorageGb,
            string operatingSystem,
            string carrier,
            string bandTechnology,
            bool hasWifi,
            bool hasBluetooth,
            bool hasNfc,
            bool hasFingerprint,
            bool hasInfrared,
            string cpuBrand,
            double cpuSpeedGhz,
            bool hasWaterResistance,
            int simCount
        )
        {
            UserId = userId;
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
            Imei = imei ?? throw new ArgumentNullException(nameof(imei));
            Inches = inches;
            Megapixels = megapixels;
            CamerasCount = camerasCount;
            RamGb = ramGb;
            PrimaryStorageGb = primaryStorageGb;
            SecondaryStorageGb = secondaryStorageGb;
            OperatingSystem = operatingSystem ?? throw new ArgumentNullException(nameof(operatingSystem));
            Carrier = carrier ?? throw new ArgumentNullException(nameof(carrier));
            BandTechnology = bandTechnology ?? throw new ArgumentNullException(nameof(bandTechnology));
            HasWifi = hasWifi;
            HasBluetooth = hasBluetooth;
            HasNfc = hasNfc;
            HasFingerprint = hasFingerprint;
            HasInfrared = hasInfrared;
            CpuBrand = cpuBrand ?? throw new ArgumentNullException(nameof(cpuBrand));
            CpuSpeedGhz = cpuSpeedGhz;
            HasWaterResistance = hasWaterResistance;
            SimCount = simCount;
            UpdateAt = DateTime.Now;
        }

    }
}
