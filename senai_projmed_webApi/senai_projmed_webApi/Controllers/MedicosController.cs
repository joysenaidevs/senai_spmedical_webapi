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

namespace senai_projmed_webApi.Controllers
{
    /// <summary>
    /// Controllers responsavel pelos endpoints referentes a medicos
    /// </summary>
    [Produces("Application/json")]

    [Route("api/[controller]")]

    [ApiController]

    [Authorize(Roles = "1")]
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicosRepository { get; set; }

        // instancia medico
        public MedicosController()
        {
            _medicosRepository = new MedicoRepository();
        }


        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Retorna um statusCode 200 - Ok</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            List<MedicosDomain> listaMedicos = _medicosRepository.ListarTodos();

            return Ok(listaMedicos);
        }

    }
}
