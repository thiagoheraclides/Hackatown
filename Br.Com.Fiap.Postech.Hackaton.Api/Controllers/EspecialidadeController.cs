using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("especialidade")]
    public class EspecialidadeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Obter()
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
