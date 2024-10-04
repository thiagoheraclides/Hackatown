using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Autenticacao;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("autenticacao")]
    public class AutenticacaoController(ITokenService tokenService, IMedicoService medicoService, 
        IPacienteService pacienteService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly IMedicoService _medicoService = medicoService;
        private readonly IPacienteService _pacienteService = pacienteService;

        [AllowAnonymous]
        [HttpPost("paciente/login")]
        public async Task<IActionResult> LoginPaciente(LoginDTO loginDTO)
        {
            try
            {
                var paciente = await _pacienteService.Obter(loginDTO.Email, loginDTO.Senha);
                var token = _tokenService.GetToken(paciente);

                return Ok(new { loginDTO.Email, Token = token });
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("medico/login")]
        public async Task<IActionResult> LoginMedico(LoginDTO loginDTO)
        {
            try
            {
                var medico = await _medicoService.Obter(loginDTO.Email, loginDTO.Senha);
                var token = _tokenService.GetToken(medico);

                return Ok(new { loginDTO.Email, Token = token });
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }
    }
}
