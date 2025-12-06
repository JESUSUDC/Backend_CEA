
namespace Application.Dto.Command.Cellphones
{
    public record DeleteCellphoneCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
