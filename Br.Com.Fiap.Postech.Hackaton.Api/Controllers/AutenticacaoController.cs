using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Autenticacao;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("autenticacao/login")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
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
