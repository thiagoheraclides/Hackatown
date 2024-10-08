﻿using Br.Com.Fiap.Postech.Hackaton.Domain.Entidades;
using Br.Com.Fiap.Postech.Hackaton.Domain.Interfaces;
using Br.Com.Fiap.Postech.Hackaton.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.Fiap.Postech.Hackaton.Application.Services
{
    public class MedicoService(Context data) : IMedicoService
    {
        private readonly Context _data = data;

        public async Task Cadastrar(UsuarioMedico medico)
        {
            var especialidadeExistente = await _data.Especialidades
                .AnyAsync(especialidade => especialidade.Codigo == medico.CodigoEspecialidade);

            if (!especialidadeExistente)
                throw new Exception("Esta filial da clínica não atende a esta especialidade.");

            await _data.Medicos.AddAsync(medico);

            await _data.SaveChangesAsync();
            
        }

        public async Task CadastrarAgenda(IList<Agenda> horarios)
        {
            await _data.Agendas.AddRangeAsync(horarios);
            await _data.SaveChangesAsync();
        }

        public async Task<UsuarioMedico> Obter(string email, string senha)
        {
            var medico = await _data.Medicos
                .Where(med => med.Email == email && med.Senha == senha)
                .FirstOrDefaultAsync()
                ?? throw new Exception("Usuário não encontrado.");

            return medico;
        }

        public async Task<IEnumerable<UsuarioMedico>> ObterPorCodigoEspecialidade(int codigo)
        {
            var especializadade = await _data.Especialidades
                .Where(especialidade => especialidade.Codigo == codigo)
                .SingleOrDefaultAsync()
                ?? throw new Exception("Especialidade não encontrada.");

            var medicosPorEspecialidade = await _data.Medicos
                .Include(med => med.Especialidade)
                .Where(medico => medico.Especialidade.Codigo.Equals(codigo)).ToListAsync();

            return medicosPorEspecialidade;

        }
    }
}
