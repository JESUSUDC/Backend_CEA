using Microsoft.AspNetCore.Authorization;

namespace API.Controladores
{
    [Route("cellphone")]
    [Authorize]
    public class CellphoneController : ApiController
    {
    }
}
