using Application.Dto.Response.Cellphones;
using Domain.Cellphones.Entity;

namespace Application.Mapper
{
    public class CellphoneMapper
    {
        public static CellphoneResponse Map(Cellphone cellphone)
        {
            if (cellphone == null) throw new ArgumentNullException(nameof(cellphone));
            return new CellphoneResponse
            {
                Id = cellphone.Id.Value,
                UserId = cellphone.UserId.Value,
                Brand = cellphone.Brand,
                Imei = cellphone.Imei,
                Inches = cellphone.Inches,
                Megapixels = cellphone.Megapixels,
                CamerasCount = cellphone.CamerasCount,
                RamGb = cellphone.RamGb,
                PrimaryStorageGb = cellphone.PrimaryStorageGb,
                SecondaryStorageGb = cellphone.SecondaryStorageGb,
                OperatingSystem = cellphone.OperatingSystem,
                Carrier = cellphone.Carrier,
                BandTechnology = cellphone.BandTechnology,
                HasWifi = cellphone.HasWifi,
                HasBluetooth = cellphone.HasBluetooth,
                HasNfc = cellphone.HasNfc,
                HasFingerprint = cellphone.HasFingerprint,
                HasInfrared = cellphone.HasInfrared,
                CpuBrand = cellphone.CpuBrand,
                CpuSpeedGhz = cellphone.CpuSpeedGhz,
                HasWaterResistance = cellphone.HasWaterResistance,
                SimCount = cellphone.SimCount
            };
        }
    }
}
