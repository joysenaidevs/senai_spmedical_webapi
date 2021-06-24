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
        w
        public void Cadastrar(ClinicasDomain novaClinica)
        {
            ctx.Cons
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
                string querySelectAll = "SELECT idClinica, nomeFantasia FROM Clinicas ";
                
                con.open();

                // declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // declara o sqlCommand cmd passando a query q será executada e a conexão com parametros
                using(SqlCommand cmd = new SqlCommand(querySelectAll, con))
	            {
                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto tiver registros para serem lidos no rdr o laço se repete
                    while (rdr.Read())
	                {
                        ClinicasDomain clinica = new ClinicasDomain()
                        {
                            // atribui a propiedade idClinica com o valor da primeira coluna da tabela do banco de dados
                            idClinica = Convert.ToInt32(rdr[0]),

                            //atribui à propiedade nome o valor da segunda coluna da tabela do banco de dados
                            nomeFantasia = rdr[1].ToString()
                        };

                        // adiciona o objeto Clinica a lista listaClinica
                        listaClinicas.Add(clinica);
	                }
	            }
            }

            return listaClinicas;
        }
    }
}
