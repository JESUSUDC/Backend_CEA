
using Application.Dto.Command.Cellphones;
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Cellphones.Entity;
using Domain.Users.Entity;

namespace Application.Service.Cellphones
{
    public class UpdateCellphoneUseCase : IUpdateCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;
        public IUserRepositoryPort _userRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public UpdateCellphoneUseCase(
            ICellphoneRepositoryPort cellphoneRepositoryPort,
            IUserRepositoryPort userRepositoryPort,
            IUnitOfWork unitOfWork)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
            _userRepositoryPort = userRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> UpdateCellphone(UpdateCellphoneCommand command)
        {
            if (await _cellphoneRepositoryPort.FindById(new CellphoneId(command.Id)) is not Cellphone cellphone)
            {
                return Error.NotFound("Celular.Encontrado", "No se encontro el celular.");
            }

            if (await _userRepositoryPort.FindById(new UserId(command.UserId)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            cellphone.Update(
                user.Id,
                command.Brand,
                command.Imei,
                command.Inches,
                command.Megapixels,
                command.CamerasCount,
                command.RamGb,
                command.PrimaryStorageGb,
                command.SecondaryStorageGb,
                command.OperatingSystem,
                command.Carrier,
                command.BandTechnology,
                command.HasWifi,
                command.HasBluetooth,
                command.HasNfc,
                command.HasFingerprint,
                command.HasInfrared,
                command.CpuBrand,
                command.CpuSpeedGhz,
                command.HasWaterResistance,
                command.SimCount
            );

            _cellphoneRepositoryPort.Update(cellphone);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
