using Application.Dto.Command.Cellphones;
using Application.Dto.Query.Cellphones;
using Application.Port.In.Cellphones;
using Microsoft.AspNetCore.Authorization;

namespace API.Controladores
{
    [Route("cellphone")]
    [Authorize]
    public class CellphoneController : ApiController
    {
        private readonly ISender _mediator;
        private readonly ICreateCellphoneUseCase _createCellphoneUseCase;
        private readonly IDeleteCellphoneUseCase _deleteCellphoneUseCase;
        private readonly IUpdateCellphoneUseCase _updateCellphoneUseCase;
        private readonly IFindByIdCellphoneUseCase _findByIdCellphoneUseCase;
        private readonly IListAllCellphoneUseCase _listAllCellphoneUseCase;

        public CellphoneController(
            ISender mediator,
            ICreateCellphoneUseCase createCellphoneUseCase,
            IDeleteCellphoneUseCase deleteCellphoneUseCase,
            IUpdateCellphoneUseCase updateCellphoneUseCase,
            IFindByIdCellphoneUseCase findByIdCellphoneUseCase,
            IListAllCellphoneUseCase listAllCellphoneUseCase
        )
        {
            _mediator = mediator;
            _createCellphoneUseCase = createCellphoneUseCase;
            _deleteCellphoneUseCase = deleteCellphoneUseCase;
            _updateCellphoneUseCase = updateCellphoneUseCase;
            _findByIdCellphoneUseCase = findByIdCellphoneUseCase;
            _listAllCellphoneUseCase = listAllCellphoneUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CreateCellphoneCommand command)
        {
            var resultado = await _createCellphoneUseCase.CreateCellphone(command);

            return resultado.Match(
                _ => Ok(),
                errores => Problem(errores)
            );
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateCellphoneCommand command)
        {
            var resultado = await _updateCellphoneUseCase.UpdateCellphone(command);

            return resultado.Match(
                _ => Ok(),
                errores => Problem(errores)
            );
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultado = await _deleteCellphoneUseCase.DeleteCellphone(new DeleteCellphoneCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var resultado = await _findByIdCellphoneUseCase.FindByIdCellphone(new FindByIdCellphoneQuery(id));

            return resultado.Match(
                celular => Ok(celular),
                errores => Problem(errores)
            );
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _listAllCellphoneUseCase.ListAllCellphone(new ListAllCellphoneQuery());

            return resultado.Match(
                lista => Ok(lista),
                errores => Problem(errores)
            );
        }

    }
}
