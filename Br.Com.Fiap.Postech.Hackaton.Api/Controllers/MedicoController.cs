using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Medico;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("medico")]
    public class MedicoController : ControllerBase
    {
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar(MedicoDTO medicoDTO)
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

        [HttpPost("agenda/cadastrar")]
        public IActionResult CadastrarAgenda(AgendaDTO agendaDTO)
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


        [HttpGet("especialidade/{codigo}")]
        public IActionResult ObterMedicoPorExpecialidade(int codigo)
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
