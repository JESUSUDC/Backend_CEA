
using Application.Dto.Command.Cellphones;
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;
using Domain.Cellphones.Entity;

namespace Application.Service.Cellphones
{
    public class DeleteCellphoneService : IDeleteCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public DeleteCellphoneService(ICellphoneRepositoryPort cellphoneRepositoryPort, IUnitOfWork unitOfWork)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> DeleteCellphone(DeleteCellphoneCommand command)
        {
            if (await _cellphoneRepositoryPort.FindById(new CellphoneId(command.Id)) is not Cellphone cellphone)
            {
                return Error.NotFound("Celular.Encontrado", "No se encontro el celular.");
            }

            _cellphoneRepositoryPort.Delete(cellphone);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
