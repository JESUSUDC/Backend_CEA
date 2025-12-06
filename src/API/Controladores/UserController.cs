using Application.Dto.Command.Users;
using Application.Dto.Query.Users;
using Application.Port.In.Cellphones;
using Application.Port.In.Users;
using Application.Service.Users;
using Microsoft.AspNetCore.Authorization;

namespace API.Controladores
{
    [Route("user")]
    [Authorize]
    public class UserController : ApiController
    {
        private readonly ISender _mediator;
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;
        private readonly IUpdateUserUseCase _updateUserUseCase;
        private readonly IFindByIdUserUserCase _findByIdUserUseCase;
        private readonly IListAllUserUseCase _listAllUserUseCase;
        private readonly IResetPasswordUseCase _resetPasswordUseCase;

        public UserController(
            ISender mediator,
            ICreateUserUseCase createUserUseCase,
            IDeleteUserUseCase deleteUserUseCase,
            IUpdateUserUseCase updateUserUseCase,
            IFindByIdUserUserCase findByIdUserUseCase,
            IListAllUserUseCase listAllUserUseCase,
            IResetPasswordUseCase resetPasswordUseCase
        )
        {
            _mediator = mediator;
            _createUserUseCase = createUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
            _updateUserUseCase = updateUserUseCase;
            _findByIdUserUseCase = findByIdUserUseCase;
            _listAllUserUseCase = listAllUserUseCase;
            _resetPasswordUseCase = resetPasswordUseCase;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Crear([FromBody] CreateUserCommand command)
        {
            var resultado = await _createUserUseCase.CreateUser(command);

            return resultado.Match(
                _ => Ok(),
                errores => Problem(errores)
            );
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] UpdateUserCommand command)
        {
            var resultado = await _updateUserUseCase.UpdateUser(command);

            return resultado.Match(
                _ => Ok(),
                errores => Problem(errores)
            );
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultado = await _deleteUserUseCase.DeleteUser(new DeleteUserCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errores => Problem(errores)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObtenerPorId(Guid id)
        {
            var resultado = await _findByIdUserUseCase.FindByIdUser(new FindByIdUserQuery(id));

            return resultado.Match(
                usuario => Ok(usuario),
                errores => Problem(errores)
            );
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _listAllUserUseCase.ListAllUsers(new ListAllUserQuery());

            return resultado.Match(
                lista => Ok(lista),
                errores => Problem(errores)
            );
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var resultado = await _resetPasswordUseCase.ResetPassword(command);

            return resultado.Match(
                _ => Ok(),
                errores => Problem(errores)
            );
        }
    }
}
