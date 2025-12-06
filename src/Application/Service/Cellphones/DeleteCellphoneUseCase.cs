
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;
using Application.Port.Out.UnitOfWork;
using Application.Port.Out.Users;

namespace Application.Service.Cellphones
{
    public class DeleteCellphoneUseCase : IDeleteCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;
        public IUnitOfWork _unitOfWork;

        public DeleteCellphoneUseCase(ICellphoneRepositoryPort cellphoneRepositoryPort, IUnitOfWork unitOfWork)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
            _unitOfWork = unitOfWork;
        }

        public Task<ErrorOr<Unit>> DeleteCellphone(DeleteCellphoneCommand command)
        {
            if (await _cellphoneRepositoryPort.FindById(new CellphoneId(comando.Id)) is Cellphone cellphone)
            {
                return Error.NotFound("Celular.Encontrado", "No se encontro el celular.");
            }

            _cellphoneRepositoryPort.Delete(cellphone);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
