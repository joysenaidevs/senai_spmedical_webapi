using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio das clinicas
    /// instalar nesta fase da API                  System.Data.SqlClient
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        //                              servidor(DESKTOP-SP7RV1S\\SQLEXPRESS) initialCatalog=nome do banco de dados
        private string stringConexao = "Data Source=; initialCatalog=SpMedical; user Id=sa; pwd=adm@132" ;
        public void AtualizarIdCorpo(ClinicasDomain clinicas)
        {
            throw new NotImplementedException();
        }

        public ClinicasDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ClinicasDomain novaClinica)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClinicasDomain> ListarTodos()
        {
            // cria uma lista onde serão armazenados os dados, listaClinicas
            List<ClinicasDomain> listaClinicas = new List<ClinicasDomain>();

            // Criando uma nova conexao e um objeto que vai me permitir essa conexão (con)
            using (SqlConnection con = new SqlConnection(stringConexao) )
            {

            }
        }
    }
}
