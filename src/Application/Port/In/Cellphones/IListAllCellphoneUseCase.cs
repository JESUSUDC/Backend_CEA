
using Application.Dto.Query.Cellphones;
using Application.Dto.Response.Cellphones;

namespace Application.Port.In.Cellphones
{
    public interface IListAllCellphoneUseCase
    {
        Task<ErrorOr<IReadOnlyList<CellphoneResponse>>> ListAllCellphone(ListAllCellphoneQuery query);
    }
}
