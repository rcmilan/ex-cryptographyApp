using CryptographyApp.DTOs;
using CryptographyApp.Entities;
using CryptographyApp.Mapper.Maps;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CryptographyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        [HttpPost("ILMapper")]
        public async Task<IActionResult> PostILMapper([FromServices] ICryptographyMapper mapper, EncryptInput input)
        {
            var res = mapper.Map<EncryptInput, CCardData>(input);

            return Ok(res);
        }

        [HttpPost("TypeConverter")]
        public async Task<IActionResult> PostTypeConverter(EncryptInput input)
        {
            var converter = TypeDescriptor.GetConverter(typeof(CCardData));

            var toEntity = (CCardData)converter.ConvertFrom(input)!;

            return Ok(toEntity);
        }
    }
}