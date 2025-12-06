
using Application.Dto.Command.Cellphones;

namespace Application.Port.In.Cellphones
{
    public interface ICreateCellphoneUseCase
    {
        public Task<ErrorOr<Unit>> CreateCellphone(CreateCellphoneCommand command);
    }
}
