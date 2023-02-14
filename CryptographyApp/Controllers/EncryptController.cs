using CryptographyApp.DTOs;
using CryptographyApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CryptographyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(EncryptInput input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(CCardData));

            var toEntity = (CCardData)converter.ConvertFrom(input)!;

            return Ok(toEntity);
        }
    }
}