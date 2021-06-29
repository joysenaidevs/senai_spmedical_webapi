using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Domains
{
    public class ConsultaDomain
    {
        public int idConsulta { get; set; }
        public int idProntuario { get; set; }
        public int idMedico { get; set; }
        public DateTime dataConsulta { get; set; }
        public string situacao { get; set; }

    }
}
