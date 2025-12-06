

using Application.Dto.Command.Cellphones;
using Application.Dto.Response.Cellphones;
using Application.Mapper;
using Application.Port.In.Cellphones;
using Application.Port.Out.Cellphones;

namespace Application.Service.Cellphones
{
    public class FindByIdCellphoneUseCase : IFindByIdCellphoneUseCase
    {
        public ICellphoneRepositoryPort _cellphoneRepositoryPort;

        public FindByIdCellphoneUseCase(ICellphoneRepositoryPort cellphoneRepositoryPort)
        {
            _cellphoneRepositoryPort = cellphoneRepositoryPort;
        }

        public async Task<ErrorOr<CellphoneResponse>> FindByIdCellphone(CreateCellphoneCommand command)
        {
            if (await _cellphoneRepositoryPort.FindById(new CellphoneId(comando.Id)) is Cellphone cellphone)
            {
                return Error.NotFound("Celular.Encontrado", "No se encontro el celular.");
            }

            return CellphoneMapper.Map(cellphone);
        }
    }
}
