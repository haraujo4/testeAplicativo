using BLL.DTO;
using BLL.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServices _services;

        public PacienteController(IPacienteServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _services.GetAllPacientesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _services.GetPacienteByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet("Email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var result = await _services.GetByEmailAsync(email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreatePacienteDTO paciente)
        {
            try
            {
                var result = await _services.AddPacienteAsync(paciente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdatePacienteDTO paciente)
        {
            try
            {
                var result = await _services.UpdatePacienteAsync(id, paciente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _services.DeletePacienteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
