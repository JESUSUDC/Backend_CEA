
namespace Application.Dto.Command.Cellphones
{
    public record UpdateCellphoneCommand(
        Guid Id,
        Guid UserId,
        string Brand,
        string Imei,
        double Inches,
        double Megapixels,
        int CamerasCount,
        int RamGb,
        int PrimaryStorageGb,
        int? SecondaryStorageGb,
        string OperatingSystem,
        string Carrier,
        string BandTechnology,
        bool HasWifi,
        bool HasBluetooth,
        bool HasNfc,
        bool HasFingerprint,
        bool HasInfrared,
        string CpuBrand,
        double CpuSpeedGhz,
        bool HasWaterResistance,
        int SimCount
    ) : IRequest<ErrorOr<Unit>>;
}
