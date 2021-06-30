using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using senai_projmed_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private ITiposUsuariosRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuariosController()
        {
            _tipoUsuarioRepository = new TiposUsuariosRepository();

        }

        /// <summary>
        /// Lista todos os tiposUsuarios
        /// </summary>
        /// <returns>Retorna um statusCode 200 - Ok</returns>
        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            List<tiposUsuariosDomain> listarTiposUsuarios = _tipoUsuarioRepository.ListarTodos();

            return Ok(listarTiposUsuarios);
        }



        /// <summary>
        /// Cadastra um novo tipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">objeto recebido na requisicao</param>
        /// <returns>retorna um statusCode (201 - created )</returns>
        ///  http://localhost:5000/api/tiposUsuarios
        [HttpPost]
        public IActionResult Post(tiposUsuariosDomain novoTipoUsuario)
        {
            // Faz a chamada do metodo Cadastrar()
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            // retorna entao, statusCode 201
            return StatusCode(201);
        }
    }
}
