using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Domains
{
    public class MedicosDomain
    {
        public int idMedico { get; set; }
        public int idEspecialidade { get; set; }
        public int idClinica { get; set; }
        public int idUsuario { get; set; }
        public string nomeMedico { get; set; }
        public string email { get; set; }
    }
}
