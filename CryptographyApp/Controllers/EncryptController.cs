using CryptographyApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CryptographyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(EncryptInput input)
        {
            return Ok();
        }
    }
}