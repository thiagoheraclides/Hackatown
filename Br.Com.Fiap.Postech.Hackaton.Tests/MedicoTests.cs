using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Medico;
using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Tests
{
    public class MedicoTests
    {
        [Fact]
        public void ModeloEhValido()
        {
            //ARRANGE
            var model = new MedicoDTO { Nome = "Nome do Paciente", Cpf = "99999999999", Crm = "CRM/SP 999999", Email = "medico@medico.com.br",
                Senha = "123456", CodigoEspecialidade = 1, DescricaoEspecialidade = "Clinica Geral" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.Empty(validationResult);

        }

        [Fact]
        public void CpfInvalido()
        {
            //ARRANGE
            var model = new MedicoDTO { Nome = "Nome do Paciente", Cpf = "9999999999999", Crm = "CRM/SP 999999", Email = "medico@medico.com.br",
                Senha = "123456", CodigoEspecialidade = 1, DescricaoEspecialidade = "Clinica Geral" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.NotEmpty(validationResult);

        }

        [Fact]
        public void EmailfInvalido()
        {
            //ARRANGE
            var model = new MedicoDTO { Nome = "Nome do Paciente", Cpf = "999999999999", Crm = "CRM/SP 999999", Email = "medico",
                Senha = "123456", CodigoEspecialidade = 1, DescricaoEspecialidade = "Clinica Geral" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.NotEmpty(validationResult);

        }
    }
}
