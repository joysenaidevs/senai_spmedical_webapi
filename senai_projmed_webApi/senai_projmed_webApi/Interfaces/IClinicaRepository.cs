using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositório Clinica (ClinicaRepository)
    /// </summary>
    public interface IClinicaRepository
    {
        // TipoRetorno  NomeMetodo(TipoParametro parametro);

        /// <summary>
        /// retorna todas as clinicas
        /// </summary>
        /// <returns>Lista de clinicas</returns>
        List<ClinicasDomain> ListarClinicas();


        /// <summary>
        /// Busca uma clinica através do seu id 
        /// </summary>
        /// <param name="id">id da clnica que será buscada</param>
        /// <returns>um objeto do tipo ClinicasDomain que foi buscado</returns>
        ClinicasDomain BuscarPorId(int id);

        /// <summary>
        /// cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto novaClinica que sera cadastrada</param>
        void Cadastrar(ClinicasDomain novaClinica);

        /// <summary>
        /// Atualiza uma nova clinica existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="clinicas">objeto clinica que sera atualizada</param>
        void AtualizarIdUrl(int id, ClinicasDomain clinicaAtualizada);

        /// <summary>
        /// deleta um genêro
        /// </summary>
        /// <param name="id">id da clinica  que será deletada</param>
        void Deletar(int id);

        
    }
}
