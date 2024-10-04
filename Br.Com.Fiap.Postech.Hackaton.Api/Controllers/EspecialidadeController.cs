using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("medico-especialista")]
    public class EspecialidadeController(IEspecialidadeService especialidadeService) : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService = especialidadeService;

        [Authorize(Roles = "PACIENTE")]
        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var especialidades = await _especialidadeService.ObterAsync();
                return Ok(especialidades.Select(esp => new { esp.Codigo, esp.Descricao }).ToList());
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }
    }
}
