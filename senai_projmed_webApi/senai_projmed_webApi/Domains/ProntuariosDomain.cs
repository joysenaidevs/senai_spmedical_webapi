using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Domains
{
    public class ProntuariosDomain
    {
        public int idPronturario { get; set; }
        public int idUsuario { get; set; }
        public string nomeProntuario { get; set; }
        public int dataNascimento { get; set; }
        public int telefone { get; set; }
        public int rg { get; set; }
        public int cpf { get; set; }
        public string endereco { get; set; }
    }
}
