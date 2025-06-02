using API.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OTPController : Controller
    {
        private readonly IOTPService _otp;

        public OTPController(IOTPService otp)
        {
            _otp = otp;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Index([FromQuery] string phoneNumber)
        {
            try
            {
                var response = await _otp.SendAsync(phoneNumber);

                return response.Status == "success" ? Ok() : BadRequest(response); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
