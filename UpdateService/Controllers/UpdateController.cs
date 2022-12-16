using Microsoft.AspNetCore.Mvc;
using UpdateService.Domain.Exceptions;
using UpdateService.Domain.Services.Interfaces;

namespace UpdateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int major, [FromQuery] int minor, [FromQuery] int bugfix)
        {
            if (major < 0 || minor < 0 || bugfix < 0)
            {
                return BadRequest("Version numbers need to be greater than or equal to 0");
            }

            try
            {
                byte[] data = await _updateService.UpdateAsync(new Version(major, minor, bugfix));

                return File(data, "application/vnd.microsoft.portable-executable");
            }
            catch (VersionDoesNotExistException)
            {
                return NotFound("Version does not exist");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
