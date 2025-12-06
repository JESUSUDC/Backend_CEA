using Application.Dto.Query.Users;
using Application.Port.In.Users;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace API.Controladores
{
    [Route("autentication")]
    [Authorize]
    public class AutenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IRefreshTokenUseCase _refreshTokenUseCase;
        private readonly IUserDataUseCase _userDataUseCase;

        public AutenticationController(
            ISender mediator,
            ILoginUseCase loginUseCase,
            IRefreshTokenUseCase refreshTokenUseCase,
            IUserDataUseCase userDataUseCase)
        {
            _mediator = mediator;
            _loginUseCase = loginUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _userDataUseCase = userDataUseCase;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> IniciarSesion([FromBody] LoginQuery query)
        {
            var resultadoDeIniciarSesion = await _loginUseCase.Login(query);

            return resultadoDeIniciarSesion.Match(
                auth => Ok(auth),
                errores => Problem(errores)
            );
        }

        [HttpGet("refresh-token")]
        [Authorize]
        public async Task<IActionResult> RefescarToken()
        {
            var resultado = await _refreshTokenUseCase.RefreshToken(new RefreshTokenQuery());

            return resultado.Match(
                auth => Ok(auth),
                errores => Problem(errores)
            );
        }

        [HttpGet("user-data")]
        [Authorize]
        public async Task<IActionResult> ListarDatosUsuario()
        {
            var resultadoDeListarDatosUsuario = await _userDataUseCase.UserData(new UserDataQuery());

            return resultadoDeListarDatosUsuario.Match(
                usuarioid => Ok(usuarioid),
                errores => Problem(errores)
            );
        }

    }
}
