
using Application.Dto.Response.Cellphones;

namespace Application.Dto.Query.Cellphones
{
    public record FindByIdCellphoneQuery(Guid Id) : IRequest<ErrorOr<CellphoneResponse>>;
}
