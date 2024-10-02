using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    public partial class UsuarioPaciente
    {
        //Identificador único do usuário paciente
        public int? Id { get; set; }

        //Nome completo do usuário paciente
        public string Nome { get; set; }

        //Email do usuário paciente
        public string Email { get; set; }

        //CPF do usuário paciente
        public string CPF { get; set; }

        //Hash da senha para autenticação
        public string Senha { get; set; }
    }
}
