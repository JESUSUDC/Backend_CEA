
using Application.Dto.Query.Cellphones;
using Application.Dto.Response.Cellphones;
using Application.Dto.Response.Users;

namespace Application.Port.In.Cellphones
{
    public interface IFindByIdCellphoneUseCase
    {
        Task<ErrorOr<CellphoneResponse>> FindByIdCellphone(FindByIdCellphoneQuery query);
    }
}
