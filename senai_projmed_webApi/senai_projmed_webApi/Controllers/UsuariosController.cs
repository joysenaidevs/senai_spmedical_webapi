using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        /// <summary>
        /// Lista todas os usuarios 
        /// </summary>
        /// <returns>status code  e lista de usuarios</returns>
        /// o usuario precisa estar logado para listar todos os generos
       // [Authorize]         // verificar se o usuario está logado
        [HttpGet]
        public IActionResult Get()
        {
            // cria a lista listaClinica para receber os dados
            List<UsuarioDomain> listarUsuarios = _usuarioRepository.Listar();

            // retorna status code 200 (ok) com a lista no formato JSON
            return Ok(listarUsuarios);

        }


        /// <summary>
        /// cadastrum novo usuario
        /// </summary>
        /// <param name="novoUsuario">objeto que é recebido na requisição</param>
        /// <returns>retorna um StatusCode (201 - Created)</returns>
        /// http://localhost:5000/api/usuarios
        //end point para cadastrar (POST)
        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            // Faz a chamada do metodo Cadastrar()
            _usuarioRepository.Cadastrar(novoUsuario);

            // retorna entao, statusCode 201
            return StatusCode(201);


            //try
            //{
            //    _clinicaRepository.Cadastrar(novaClinica);

            //    return StatusCode(201);
            //}
            //catch (Exception erro)
            //{
            //    return BadRequest(erro);
            //}
        }


        ///// <summary>
        ///// Valida o usuário
        ///// </summary>
        ///// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        ///// <returns>Retorna um token com as informações do usuário</returns>
        ///// dominio/api/Login
        //[HttpPost("Login")]
        //public IActionResult Login(UsuarioDomain login)
        //{
        //    // busca usuario por Email e senha
        //    UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

        //    // caso nao encontre nenhum usuario com o email e senha informados
        //    if (usuarioBuscado == null)
        //    {
        //        // retorna NotFound com mensagem personalizada
        //        return NotFound("Email e senha inválidos!");
        //    }

        //    //Caso encontre, prossegue para a criação do token

        //    //declaramos a variavel do tipo ARRAY
        //    //definindo dados que serão fornecidos no token -Payload
        //    var claim = new[]
        //    {
        //        // formato para trazer uma claim (tipoDaClaim, valorDaClaim)
        //        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),

        //        // utilizaremos JTI Para especificar o ID DO USUARIO
        //        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

        //        // utilizaremos ClaimTypes para definir quais metodos o usuario pode acessar
        //        //Role = para condição
        //        new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

        //        // criando uma claim personalizada
        //        // new Claim("Claim Personalizada", "Valor da Claim")
        //    };

        //    //Define a chave de acesso para o token
        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-autentication"));

        //    // credenciais do token            chave     tipo de criptografia
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    // gerando o token  tipoDoToken
        //    var gerarToken = new JwtSecurityToken(

        //        // propiedades

        //        // quem emite o token , quem criou o token
        //        issuer: "senai_projMedical",               // emissor (gerando token)
        //        audience: "senai_projmed_webApi",           // quem recebe o token
        //        claims: claim,                              // representa OS DADOS DA CLAIM ACIMA
        //                                                    //       (Now: data e hora do sistema)
        //        expires: DateTime.Now.AddMinutes(30),       // tempo de expiração
        //        signingCredentials: creds                   // credenciais do token
        //    );

        //    // retornaremos status code - 200 Ok com o token criado
        //    return Ok(new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(gerarToken)
        //    });


    }
    
}

