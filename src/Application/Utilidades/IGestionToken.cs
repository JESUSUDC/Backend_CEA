using Domain.ObjetosDeValor;
using Domain.Usuarios;

namespace Application.Utilidades
{
    public interface IGestionToken
    {
        string EncryptSHA256(string texto);
        string GenerateJWT(Usuario usuario, int opcion);
        DatosUsuarioDTO? DecodeJWT();
    }
}
