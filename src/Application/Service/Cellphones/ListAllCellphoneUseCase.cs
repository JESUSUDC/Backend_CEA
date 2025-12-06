
using Application.Dto.Command.Cellphones;
using Application.Dto.Response.Cellphones;
using Application.Mapper;
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;

namespace Application.Service.Cellphones
{
    public class ListAllCellphoneUseCase : IListAllCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;

        public ListAllCellphoneUseCase(ICellphoneRepositoryPort cellphoneRepositoryPort)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
        }

        public async Task<ErrorOr<IReadOnlyList<CellphoneResponse>>> ListAllCellphone(CreateCellphoneCommand command)
        {
            var cellphones = await _cellphoneRepositoryPort.ListAll()
                .Select(cellphones => CellphoneMapper.Map(cell))
                .ToList(); ;

            return cellphones;
        }
    }
}
