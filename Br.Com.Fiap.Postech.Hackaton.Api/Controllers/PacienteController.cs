using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente;
using Br.Com.Fiap.Postech.Hackaton.Api.Tools;
using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Br.Com.Fiap.Postech.Hackaton.Api.Controllers
{
    [ApiController]
    [Route("paciente")]
    public class PacienteController(IPacienteService pacienteService) : ControllerBase
    {

        private readonly IPacienteService _pacienteService = pacienteService;

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody]PacienteDTO pacienteDTO)
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

                var paciente = new UsuarioPaciente { Nome = pacienteDTO.Nome, CPF = pacienteDTO.Cpf, Email = pacienteDTO.Email,
                    Senha = Hasher.Hash(pacienteDTO.Senha) };

                await _pacienteService.Cadastrar(paciente);

                return Created();

            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [HttpPost("consulta/horarios")]
        public async Task<IActionResult> Obter([FromBody]PesquisaDisponibilidadeDTO pesquisaDisponibilidadeDTO)
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

                var horariosDisponiveis = await _pacienteService.Obter(pesquisaDisponibilidadeDTO.CodigoMedico, pesquisaDisponibilidadeDTO.Data);

                return Ok(horariosDisponiveis.Select(h => new { h.Codigo, Data = h.Data.ToString("yyyy-MM-dd"), InicioConsulta = h.HoraInicial,
                    FimConsulta = h.HoraFinal }).ToList());
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }

        [HttpPost("consulta/agendar")]
        public async Task<IActionResult> AgendarConsulta([FromBody]ConsultaMedicaDTO consultaMedicaDTO)
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
                
                await _pacienteService.Agendar(consultaMedicaDTO.CodigoPaciente, consultaMedicaDTO.CodigoHorarioDisponivel);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(new { Resultado = "Erro", Mensagem = e.Message });
            }
        }
    }
}
