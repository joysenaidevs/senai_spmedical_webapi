using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IUsuarioRepository
    {
       interface IUsuarioRepository
       {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">email do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo UsuarioDomain que foi buscado</returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
       }
    }
}
