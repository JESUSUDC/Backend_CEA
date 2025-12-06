
namespace Application.Dto.Command.Cellphones
{
    public record DeleteCellphoneCommand() : IRequest<ErrorOr<Unit>>;
}
