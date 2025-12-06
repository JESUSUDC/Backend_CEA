using Microsoft.AspNetCore.Authorization;

namespace API.Controladores
{
    [Route("user")]
    [Authorize]
    public class UserController : ApiController
    {

    }
}
