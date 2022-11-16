using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("~/api/connect/token"), Produces("application/json")]
        public async Task<IActionResult> Token([ModelBinder(BinderType = typeof(OpenIddictMvcBinder))] OpenIdConnectRequest request)
        {
            try
            {

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
