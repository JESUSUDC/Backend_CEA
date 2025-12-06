
using Application.Dto.Command.Cellphones;
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Cellphones.Entity;
using Domain.Users.Entity;

namespace Application.Service.Cellphones
{
    public class CreateCellphoneService : ICreateCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;
        public IUserRepositoryPort _userRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public CreateCellphoneService(
            ICellphoneRepositoryPort cellphoneRepositoryPort,
            IUserRepositoryPort userRepositoryPort,
            IUnitOfWork unitOfWork)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
            _userRepositoryPort = userRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> CreateCellphone(CreateCellphoneCommand command)
        {
            if (await _userRepositoryPort.FindById(new UserId(command.UserId)) is not User user)
            {
                return Error.NotFound("Usuario.Encontrado", "No se encontro el usuario.");
            }

            var cellphone = new Cellphone(
                new CellphoneId(Guid.NewGuid()),
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

            _cellphoneRepositoryPort.Create(cellphone);
            await _unitOfWork.SaveChangesAsync();
            
            return Unit.Value;
        }

    }
}
