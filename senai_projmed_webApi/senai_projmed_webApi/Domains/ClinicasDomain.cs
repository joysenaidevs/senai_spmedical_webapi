using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Domains
{
    public class ClinicasDomain
    {
        public int idClinica { get; set; }
        public int cnpj { get; set; }
        public string nomeFantasia { get; set; }
        public string razaoSocial { get; set; }
        public string endereco { get; set; }
        public int horarioFuncionamento { get; set; }
    }
}
