using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.Fiap.Postech.Hackaton.Domain.Entidades
{
    public partial class UsuarioMedico
    {
        //Identificador único do usuário medico
        public int? Id { get; set; }

        //Nome completo do usuário medico
        public string Nome { get; set; }

        //Email do usuário medico
        public string Email { get; set; }

        //CPF do usuário medico
        public string CPF { get; set; }

        //CRM do usuário medico
        public string CRM { get; set; }

        //Hash da senha para autenticação
        public string Senha { get; set; }
    }
}
