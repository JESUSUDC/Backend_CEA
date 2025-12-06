
using Application.Dto.Response.Cellphones;

namespace Application.Dto.Query.Cellphones
{
    public record ListAllCellphoneQuery() : IRequest<ErrorOr<IReadOnlyList<CellphoneResponse>>>;
}
