using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using senai_projmed_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Controllers
{
    /// <summary>
    /// Controllers responsaveis pelos endpoints usuarios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]


    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class UsuariosController : ControllerBase
    {

        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IuUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();

        }



        [HttpGet]
        public IActionResult Get()
        {
            // cria a lista listaClinica para receber os dados
            List<UsuarioDomain> listarUsuarios = _usuarioRepository.Listar();

            // retorna status code 200 (ok) com a lista no formato JSON
            return Ok(listarUsuarios);


        }


        ///// <summary>
        ///// Valida o usuário
        ///// </summary>
        ///// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        ///// <returns>Retorna um token com as informações do usuário</returns>
        ///// dominio/api/Login
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            // busca usuario por Email e senha
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            // caso nao encontre nenhum usuario com o email e senha informados
            if (usuarioBuscado == null)
            {
                // retorna NotFound com mensagem personalizada
                return NotFound("Email e senha inválidos!");
            }

            return Ok(usuarioBuscado);

            
        }
    }
}

