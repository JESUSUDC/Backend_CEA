
using Application.Dto.Command.Cellphones;

namespace Application.Port.In.Cellphones
{
    public interface IUpdateCellphoneUseCase
    {
        Task<ErrorOr<Unit>> UpdateCellphone(UpdateCellphoneCommand command);
    }
}
