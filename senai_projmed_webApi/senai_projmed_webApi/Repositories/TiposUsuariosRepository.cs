using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Repositories
{
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {

        /// <summary>
        ///string de conexao Joyce
        /// </summary>
        //private string stringConexao = "Data Source=WINDOWS\\SQLEXPRESS; initial catalog=medicalGroup; user Id=sa; pwd=adm@132";


        //string de conexao
        string stringConexao = "Data Source=LAB08DESK115999\\SQLEXPRESS; initial catalog=medicalGroup; integrated security=true";


        public void AtualizarIdCorpo(tiposUsuariosDomain tiposUsuariosAtualizado)
        {
            throw new NotImplementedException();
        }

        public tiposUsuariosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(tiposUsuariosDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO tipoUsuarios(nomeTipoUsuario) VALUES (@nomeTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //cmd.Parameters.AddWithValue("@idTipoUsuario", novoTipoUsuario.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@nomeTipoUsuario", novoTipoUsuario.nomeTipoUsuario);

                    // abre a conexao
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declaramos a query a ser executada passando valor como parâmetro
                string delete = "DELETE FROM tipoUsuarios WHERE idTipoUsuario = @ID";

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

        public List<tiposUsuariosDomain> ListarTodos()
        {
            // cria uma lista onde será armazenados os tipos usuarios
            List<tiposUsuariosDomain> listarTiposUsuarios = new List<tiposUsuariosDomain>();

            // Criando uma nova conexao e um objeto que vai me permitir essa conexão (con)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, nomeTipoUsuario FROM tipoUsuarios";

                //abre conexão com o banco de dados
                con.Open();

                // declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // declara o sqlCommand cmd passando a query q será executada e a conexão com parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto tiver registros para serem lidos no rdr o laço se repete
                    while (rdr.Read())
                    {
                        tiposUsuariosDomain tiposUsuarios = new tiposUsuariosDomain()
                        {
                            //atribui a propiedade idTipoUsuario com o valor da primeira coluna da tabela do banco
                            idTipoUsuario = Convert.ToInt32(rdr[0]),


                            // atribui a propiedade nomeTipoUsuario com o valor da segunda coluna da tabela do banco de dados
                            nomeTipoUsuario = rdr[1].ToString()

                         };
                        // adiciona o objeto Clinica a lista listaClinica
                        listarTiposUsuarios.Add(tiposUsuarios);
                    }
                }
            }

            return listarTiposUsuarios;
        }
    }
}
