
using Application.Dto.Command.Cellphones;

namespace Application.Port.In.Cellphones
{
    public interface IDeleteCellphoneUseCase
    {
        Task<ErrorOr<Unit>> DeleteCellphone(DeleteCellphoneCommand command);
    }
}
