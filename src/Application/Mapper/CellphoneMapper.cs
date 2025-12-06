using Application.Dto.Response.Cellphones;
using Domain.Cellphones.Entity;

namespace Application.Mapper
{
    public class CellphoneMapper
    {
        public static CellphoneResponse Map(Cellphone cellphone)
        {
            if (cellphone == null) throw new ArgumentNullException(nameof(cellphone));
            return new CellphoneResponse(
                cellphone.Id.Value,
                cellphone.UserId.Value,
                cellphone.Brand,
                cellphone.Imei,
                cellphone.Inches,
                cellphone.Megapixels,
                cellphone.CamerasCount,
                cellphone.RamGb,
                cellphone.PrimaryStorageGb,
                cellphone.SecondaryStorageGb,
                cellphone.OperatingSystem,
                cellphone.Carrier,
                cellphone.BandTechnology,
                cellphone.HasWifi,
                cellphone.HasBluetooth,
                cellphone.HasNfc,
                cellphone.HasFingerprint,
                cellphone.HasInfrared,
                cellphone.CpuBrand,
                cellphone.CpuSpeedGhz,
                cellphone.HasWaterResistance,
                cellphone.SimCount
            );
        }
    }
}
