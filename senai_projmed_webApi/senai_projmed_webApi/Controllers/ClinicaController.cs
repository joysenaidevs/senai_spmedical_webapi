using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Controller responsavel pelos endpoints()  
namespace senai_projmed_webApi.Controllers
{

    [Produces("application/json")]


    // A rota de uma requisiçãi será no formato dominio\api\nomeController
    // http:\\localhost:5000\api\Clinicas
    [Route("api/[controller]")]


    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para qye haja referencia aos métodos no repositório
        /// </summary>
        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Lista de clinicas e status code 200</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            // cria a lista listaClinica para receber os dados
            List<ClinicaDomain> listaClinica = _clinicaRepository.ListarTodos();

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
        /// cadastr auma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto que é recebido na requisição</param>
        /// <returns>retorna um StatusCode (201 - Created)</returns>
        /// http://localhost:5000/api/clinicas
        //end point para cadastrar (POST)
        [Authorize(Roles =  "1")]
        [HttpPost]
        public IActionResult Post(clinicasDomain novaClinica)
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
    }
