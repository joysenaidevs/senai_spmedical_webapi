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
    /// controllers responsavel pelos end points dos usuarios
    /// </summary>
    /// 

    // http://localhost:5000/api/usuarios
    [Route("api/[controller]")]

    [ApiController]

    
    public class LoginController : ControllerBase
    {

        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        /// dominio/api/Login
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

            //Caso encontre, prossegue para a criação do token

            // nesta fase da API pegarei as informações d token de login no POSTMAN

             //declaramos a variavel do tipo ARRAY
             //definindo dados que serão fornecidos no token -Payload
            var claim = new[]
            {
                // formato para trazer uma claim (tipoDaClaim, valorDaClaim)
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                
                // utilizaremos JTI Para especificar o ID DO USUARIO
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

                // utilizaremos ClaimTypes para definir quais metodos o usuario pode acessar
                //Role = para condição
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())

                // criando uma claim personalizada
                // new Claim("Claim Personalizada", "Valor da Claim")
            };

            //Define a chave de acesso para o token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("key-authentication"));

            // credenciais do token            chave     tipo de criptografia
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // gerando o token  tipoDoToken
            var gerarToken = new JwtSecurityToken(

                // propiedades

                // quem emite o token , quem criou o token
                issuer: "senai_projMedical",               // emissor (gerando token)
                audience: "senai_projmed_webApi",           // quem recebe o token
                claims: claim,                              // representa OS DADOS DA CLAIM ACIMA
                                                            //       (Now: data e hora do sistema)
                expires: DateTime.Now.AddMinutes(30),       // tempo de expiração
                signingCredentials: creds                   // credenciais do token
            );

            // retornaremos status code - 200 Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(gerarToken)
            });

            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}

        }

    }

}

    