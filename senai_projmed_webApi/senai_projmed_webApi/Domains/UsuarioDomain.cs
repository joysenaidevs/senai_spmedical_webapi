using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }

        //[Required(ErrorMessage = "Insira o nome de usuario!")]
        public string nomeUsuario { get; set; }

        [Required(ErrorMessage ="Insira o seu email!")]
        public string email { get; set; }

        //campo obrigatório de no minimo 6 caracteres
        [StringLength(20,MinimumLength =6, ErrorMessage ="O campo senha precisa ter no minimo 6 caracteres")]
        [Required(ErrorMessage ="campo senha obrigatório")]
        public string senha { get; set; }
    }
}
