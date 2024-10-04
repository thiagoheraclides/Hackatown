using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Medico;
using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("medico")]
    public class MedicoController(IMedicoService medicoService) : ControllerBase
    {

        private readonly IMedicoService _medicoService = medicoService;
        
        [AllowAnonymous]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody]MedicoDTO medicoDTO)
        {
            try
            {
                if (!ModelState.IsValid) 
                {
                    var errors = ModelState.Values.SelectMany(error =>  error.Errors);
                    return BadRequest(new { Resultado = "Erro", Descricao = "Ocorreram erros de validação na requisição.",
                        Detalhes = string.Join(" ", errors.Select(e => e.ErrorMessage)) });
                }
                
                UsuarioMedico medico = new() { Nome = medicoDTO.Nome, CPF = medicoDTO.Cpf, CRM = medicoDTO.Crm, Email = medicoDTO.Email,
                            Senha = medicoDTO.Senha, CodigoEspecialidade = medicoDTO.CodigoEspecialidade };

                await _medicoService.Cadastrar(medico);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [Authorize(Roles = "MEDICO")]
        [HttpPost("agenda/cadastrar")]
        public async Task<IActionResult> CadastrarAgenda(AgendaDTO agendaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(error => error.Errors);
                    return BadRequest(new
                    {
                        Resultado = "Erro",
                        Descricao = "Ocorreram erros de validação na requisição.",
                        Detalhes = string.Join(" ", errors.Select(e => e.ErrorMessage))
                    });
                }

                var horariosParaAtendimento = agendaDTO.HorariosDisponiveis.Select(hd => new Agenda { 
                    CodigoMedico = agendaDTO.CodigoMedico, Data = hd.HoraInicial.Date, HoraInicial = TimeSpan.Parse(hd.HoraInicial.ToString("HH:mm:ss")),
                    HoraFinal = TimeSpan.Parse(hd.HoraFinal.ToString("HH:mm:ss"))
                })
                    .ToList();

                await _medicoService.CadastrarAgenda(horariosParaAtendimento);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [Authorize(Roles = "PACIENTE")]
        [HttpGet("especialidade/{codigo}")]
        public async Task<IActionResult> ObterMedicoPorEspecialidade(int codigo)
        {
            try
            {
                var respostaServico = await _medicoService.ObterPorCodigoEspecialidade(codigo);
                var especialidade = respostaServico.Select(e => e.Especialidade).FirstOrDefault();
                var medicosPorEspecialidade = respostaServico.Select(m => new { m.Nome, m.CRM, m.Email });
                
                return Ok(medicosPorEspecialidade.Select(medico => 
                        new { Especialidade = especialidade!.Descricao, Medicos = medicosPorEspecialidade}));
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

    }
}
