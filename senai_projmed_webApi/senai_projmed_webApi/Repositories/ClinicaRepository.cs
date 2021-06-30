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
        /// <summary>
        ///string de conexao Joyce
        /// </summary>
       // private string stringConexao = "Data Source=WINDOWS\\SQLEXPRESS; initial catalog=medicalGroup; user Id=sa; pwd=adm@132";


        /// <summary>
        /// string de conexão do SENAI
        /// </summary>
        string stringConexao = "Data Source=LAB08DESK115999\\SQLEXPRESS; initial catalog=medicalGroup; integrated security=true";


        /// <summary>
        /// Atualiza a clinica passando o id pela url
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <param name="clinicaAtualizada">objeto clinica com as novas infomações</param>
        public void AtualizarIdUrl(int id, ClinicasDomain clinicaAtualizada)
        {
            // string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //query declarada a ser executada
                string updateUrl = "UPDATE clinicas SET nomeFantasia = @nomeFantasia, cnpj = @cnpj, razaoSocial = @razaoSocial, endereco = @endereco, horarioFuncionamento = @horarioFuncionamento WHERE idClinica = @ID";

                // declara a sqlcommand cmd passando a qeury aser executada e a conexao com parametros
                using (SqlCommand cmd = new SqlCommand(updateUrl, con))
                {
                    // passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("nomeFantasia", clinicaAtualizada.nomeFantasia);
                    cmd.Parameters.AddWithValue("cnpj", clinicaAtualizada.cnpj);
                    cmd.Parameters.AddWithValue("razaoSocial", clinicaAtualizada.razaoSocial);
                    cmd.Parameters.AddWithValue("endereco", clinicaAtualizada.endereco);
                    cmd.Parameters.AddWithValue("horarioFuncionamento", clinicaAtualizada.horarioFuncionamento);

                    con.Open();

                    // execução do comando
                    cmd.ExecuteNonQuery();
                }
            }

            //Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            //if (clinicaAtualizada.RazaoSocial != null)
            //{
            //    clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            //}
            //if (clinicaAtualizada.NomeFantasia != null)
            //{
            //    clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
            //}
            //if (clinicaAtualizada.Endereco != null)
            //{
            //    clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            //}

            //clinicaBuscada.HorarioAbertura = clinicaAtualizada.HorarioAbertura;

            //clinicaBuscada.HorarioFechamento = clinicaAtualizada.HorarioFechamento;

            //if (clinicaAtualizada.CNPJ != null)
            //{
            //    clinicaBuscada.CNPJ = clinicaAtualizada.CNPJ;
            //}
            //if (clinicaAtualizada.Site != null)
            //{
            //    clinicaBuscada.Site = clinicaAtualizada.Site;
            //}

            //ctx.Clinicas.Update(clinicaBuscada);

            //ctx.SaveChanges();
        }

        /// <summary>
        /// Busca umca clinica através do seu id
        /// </summary>
        /// <param name="id">id da clinica</param>
        /// <returns>retorna a clinica buscada ou null caso nao seja encontrada</returns>
        public ClinicasDomain BuscarPorId(int id)
        {
            // Declaramos a sqlconnection passando a stringConexao COMO Parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // query executada
                string buscarById = "SELECT idClinica, nomeFantasia, cnpj, razaoSocial, horarioFuncionamento, endereco FROM clinicas WHERE idClinica = @ID ";

                con.Open();

                // declara o DataReader para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o sqlcommand passando a query que será executada e a conexão como parametro
                using (SqlCommand cmd = new SqlCommand(buscarById, con))
                {
                    // passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);
                  
                    // executa a query e vai ler no banco através do cmd e o que voltar irá ser armazenado no rdr
                    rdr = cmd.ExecuteReader();

                    con.Open();

                    //condicional para verificar algo
                    // se eu consigo ler um valor no rdr: Verifica o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // se sim instancia um novo objeto chamado clinicaBuscada do tipo ClinicasDomain
                        ClinicasDomain clinicaBuscada = new ClinicasDomain
                        {
                            // atribui o valor da coluna idClinica da tabela do banco de dados
                            idClinica = Convert.ToInt32(rdr["idClinica"]),

                            // atribui o valor da coluna nome da tabela do banco de dados
                            nomeFantasia = rdr["nomeFantasia"].ToString(),

                            cnpj = Convert.ToInt32(rdr["cnpj"]),

                            razaoSocial = rdr["razaoSocial"].ToString(),

                            horarioFuncionamento = Convert.ToInt32(rdr["horarioFuncionamento"]),

                            endereco = rdr["endereco"].ToString()


                        };

                        // retorna clinicaBuscada com os dados obtidos
                        return clinicaBuscada;
                    }

                    // se nao encontrar, retorna null
                    return null;
                }
            }


            // Retorna a primeira instituição encontrada para o ID informado
           // return ctx.Clinicas.FirstOrDefault(i => i.IdClinica == id);
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
                                                                    // declara a query que sera executada
                                                                    // INSERT INTO Clinicas(nomeFantasia) VALUES ('PLENA');
                                                                    // INSERT INTO Clinicas(nomeFantasia) VALUES ('Joana D'Arc ');
                                                                    // INSERT INTO Clinicas(nomeFantasia) VALUES ('')DROP TABLE Clinicas--');
                                    // Ao cadastrar o comando acima, irá deletar a tabela do banco de dados
                                    //string queryInsert = "INSERT INTO Clinicas(nomeFantasia) VALUES ('" + novaClinica.nomeFantasia + "')";
                                    //nao usar dessa forma para n causar efeito joana D'Arc
                                    // além de permitir SQL Injection
                                    //por exemplo
                                    // "nome" : "')DROP TABLE Clinicas--"
                                    // SQL INJECTION -- 

                string queryInsert = "INSERT INTO clinicas(cnpj, nomeFantasia, razaoSocial, horarioFuncionamento, endereco) VALUES (@cnpj, @nomeFantasia, @razaoSocial, @horarioFuncionamento, @endereco)";

                //  declara o SqlCommandQuery que era executada ea conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@cnpj", novaClinica.cnpj);
                    cmd.Parameters.AddWithValue("@nomeFantasia", novaClinica.nomeFantasia);
                    cmd.Parameters.AddWithValue("@razaoSocial", novaClinica.razaoSocial);
                    cmd.Parameters.AddWithValue("@horarioFuncionamento", novaClinica.horarioFuncionamento);
                    cmd.Parameters.AddWithValue("@endereco", novaClinica.endereco);

                    //abre a conexao com o banco de dados
                    con.Open();

                    // executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleta uma clinica através de seu ID
        /// </summary>
        /// <param name="id">id da clinica que será deletada</param>
        public void Deletar(int id)
        {
            // Remove a instituição que foi buscada
            //ctx.Instituicoes.Remove(BuscarPorId(id));

            // Salva as alterações
            //ctx.SaveChanges();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declaramos a query a ser executada passando valor como parâmetro
                string delete = "DELETE FROM clinicas WHERE idClinica = @ID";

                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    // passamos o valor do parâmetro
                    cmd.Parameters.AddWithValue("@ID", id);

                    //abre a conexao
                    con.Open();

                    //executa a query(delete)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todas as clinicas existentes
        /// </summary>
        /// <returns>Lista das clinicas e um StatusCode 200 (Ok)</returns>
        public List<ClinicasDomain> ListarClinicas()
        {
            // Retorna uma lista com todas as informações das instituições
           // return ctx.Clinicas.ToList();


            // cria uma lista onde serão armazenados os dados, listaClinicas
            List<ClinicasDomain> listaClinicas = new List<ClinicasDomain>();

            // Criando uma nova conexao e um objeto que vai me permitir essa conexão (con)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT cnpj, nomeFantasia, razaoSocial, horarioFuncionamento, endereco FROM clinicas ";

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
                        ClinicasDomain clinicas = new ClinicasDomain()
                        {
                            // atribui a propiedade idClinica com o valor da primeira coluna da tabela do banco de dados
                            idClinica = Convert.ToInt32(rdr[0]),

                            cnpj = Convert.ToInt32(rdr[1]),

                            //atribui à propiedade nome o valor da segunda coluna da tabela do banco de dados
                            nomeFantasia = rdr[2].ToString(),

                            razaoSocial = rdr[3].ToString(),

                            endereco = rdr[4].ToString(),

                            horarioFuncionamento = Convert.ToInt32(rdr[5])
                        };

                        // adiciona o objeto Clinica a lista listaClinica
                        listaClinicas.Add(clinicas);
	                }
	            }
            }

            return listaClinicas;
        }
    }
}
