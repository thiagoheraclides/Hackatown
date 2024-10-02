using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("paciente")]
    public class PacienteController : ControllerBase
    {
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(PacienteDTO pacienteDTO)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [HttpPost("consulta/agendar")]
        public IActionResult AgendarConsulta(ConsultaMedicaDTO consultaMedicaDTO)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }
    }
}
