using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using senai_projmed_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Controller responsavel pelos endpoints()  
namespace senai_projmed_webApi.Controllers
{
    /// <summary>
    /// Controllers responsaveis pelos endpoints (url) referente a clinicas
    /// </summary>
    
    // resposta da api no formato json
    [Produces("application/json")]


    // A rota de uma requisiçãi será no formato dominio\api\nomeController
    // http:\\localhost:5000\api\Clinicas
    [Route("api/[controller]")]

    // define que é um controlador api
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    [Authorize(Roles = "1")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para que haja referencia aos métodos no repositório
        /// </summary>
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Lista de clinicas e status code 200</returns>
        //[Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            // cria a lista listaClinica para receber os dados
            List<ClinicasDomain> listaClinica = _clinicaRepository.ListarTodos();

            // retorna status code 200 (ok) com a lista no formato JSON
            return Ok(listaClinica);


            //try
            //{
            //    return Ok(_IClinicaRepository.Read());
            //}
            //catch (Exception error)
            //{

            //    return BadRequest(error)

            //}
        }


        /// <summary>
        /// Busca uma clinica através do seu id
        /// </summary>
        /// <param name="id">id da clinica que será buscada</param>
        /// <returns>uma clinica buscada ou notFound caso nenhum genero seja encontrado</returns>
        /// http://localhost:5000/api/clinicas
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            ClinicasDomain clinicaBuscada = _clinicaRepository.BuscarPorId(id);

            // verifica se nenhum genero foi encontrado
            if (clinicaBuscada == null)
            {
                // caso n seja encontrada retorna um StatusCode(404) com a mensagem personalizada
                return NotFound("Nenhuma clinica foi encontrada!");
            }

            // caso seja encontrada retorna um statuscode 200 - Ok
            return Ok(clinicaBuscada);


            //try
            //{
            //    // Retora a resposta da requisição fazendo a chamada para o método
            //    return Ok(_clinicaRepository.BuscarPorId(id));
            //}
            //catch (Exception erro)
            //{
            //    return BadRequest(erro);
            //}

            // Retorna a primeira instituição encontrada para o ID informado
           //  return ctx.Clinicas.FirstOrDefault(i => i.IdClinica == id);
        }


        /// <summary>
        /// cadastruma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto que é recebido na requisição</param>
        /// <returns>retorna um StatusCode (201 - Created)</returns>
        /// http://localhost:5000/api/clinicas
        //end point para cadastrar (POST)
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ClinicasDomain novaClinica)
        {
            // Faz a chamada do metodo Cadastrar()
            _clinicaRepository.Cadastrar(novaClinica);

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



        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="id">id da clinica atualizada</param>
        /// <param name="clinicaAtualizada"> objeto com as novas informações</param>
        /// <returns>StatusCode 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ClinicasDomain clinicaAtualizada)
        {
            // faz a chamada para o método .AtualizarIdUrl passando os parÂmetros
            _clinicaRepository.AtualizarIdUrl(id, clinicaAtualizada);
            
            // retorna um No Content
            return StatusCode(204);

            //try
            //{
            //    _clinicaRepository.AtualizarIdUrl(id, clinicaAtualizada);

            //    return StatusCode(204);
            //}
            //catch (Exception erro)
            //{
            //    return BadRequest(erro);
            //}
        }
        


        /// <summary>
        /// deleta uma clinica existente
        /// </summary>
        /// <param name="id">id da clinica que sera deletada</param>
        /// <returns>StatusCode(204) - No content</returns>
        /// http://localhost:5000/api/clinicas/4
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _clinicaRepository.Deletar(id);

            return StatusCode(204);

            //try
            //{
            //    // Faz a chamada para o método
            //    //_clinicaRepository.Deletar(id);

            //    // Retorna um status code
            //    //return StatusCode(204);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex);
            //}
        }
    
    }
}
