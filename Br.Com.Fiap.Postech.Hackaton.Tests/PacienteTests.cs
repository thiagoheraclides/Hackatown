using Br.Com.Fiap.Postech.Hackaton.Api.DTO.Paciente;
using System.ComponentModel.DataAnnotations;

namespace Br.Com.Fiap.Postech.Hackaton.Tests
{
    public class PacienteTests
    {
        [Fact]
        public void ModeloEhValido()
        {
            //ARRANGE
            var model = new PacienteDTO { Nome = "Nome do Paciente", Cpf = "99999999999", Email = "paciente@paciente.com.br", Senha = "123456" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.Empty(validationResult);
            
        }

        [Fact]
        public void CpfInvalido()
        {
            //ARRANGE
            var model = new PacienteDTO { Nome = "Nome do Paciente", Cpf = "999999999999", Email = "paciente@paciente.com.br", Senha = "123456" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.NotEmpty(validationResult);

        }

        [Fact]
        public void EmailfInvalido()
        {
            //ARRANGE
            var model = new PacienteDTO { Nome = "Nome do Paciente", Cpf = "99999999999", Email = "paciente", Senha = "123456" };

            //ACT
            var validationResult = ModelValidationHelper.ValidateModel(model);

            //ASSERT
            Assert.NotEmpty(validationResult);

        }


    }
}