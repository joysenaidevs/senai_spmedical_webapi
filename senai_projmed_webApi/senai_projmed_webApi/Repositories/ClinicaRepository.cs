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
            //try
            //{
            //    return Ok(_clinicaRepository.BuscarPorId(id));
            //}
            //catch (Exception erro)
            //{
            //    return BadRequest(erro);
            //}
        }
        
        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="novaClinica">objeto novaClinica com as informações que serão cadastradas</param>
        public void Cadastrar(ClinicasDomain novaClinica)
        {
            //ctx.Clinicas.Add(novaClinica);

            //ctx.SaveChanges();

            // declara a sqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                                        // INSERT INTO Clinicas(nomeFantasia) VALUES ('PLENA');
                                        // INSERT INTO Clinicas(nomeFantasia) VALUES ('Joana D'Arc ');
                string queryInsert = "INSERT INTO Clinicas(nomeFantasia) VALUES ('" + novaClinica.nomeFantasia + "')";
                                        //nao usar dessa forma para n causar efeito joana D'Arc

                //  declara o SqlCommandQuery que era executada ea conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //abre a conexao com o banco de dados
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todas as clinicas existentes
        /// </summary>
        /// <returns>Lista das clinicas e um StatusCode 200 (Ok)</returns>
        public List<ClinicasDomain> ListarTodos()
        {
            // cria uma lista onde serão armazenados os dados, listaClinicas
            List<ClinicasDomain> listaClinicas = new List<ClinicasDomain>();

            // Criando uma nova conexao e um objeto que vai me permitir essa conexão (con)
            using (SqlConnection con = new SqlConnection(stringConexao) )
            {
                string querySelectAll = "SELECT idClinica, nomeFantasia FROM Clinicas ";

                //abre conexão com o banco de dados
                con.Open();

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
