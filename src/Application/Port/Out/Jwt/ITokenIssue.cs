using Domain.ObjetosDeValor;
using Domain.Usuarios;

namespace Application.Port.Out.Jwt
{
    public interface ITokenIssue
    {
        string EncryptSHA256(string texto);
        string GenerateJWT(Usuario usuario, int opcion);
        DatosUsuarioDTO? DecodeJWT();
    }
}
