
using Application.Dto.Command.Cellphones;
using Application.Dto.Query.Cellphones;
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

        public async Task<ErrorOr<IReadOnlyList<CellphoneResponse>>> ListAllCellphone(ListAllCellphoneQuery query)
        {
            var cellphones = _cellphoneRepositoryPort.ListAll()
                .Select(cellphone => CellphoneMapper.Map(cellphone))
                .ToList();

            return cellphones;
        }

    }
}
