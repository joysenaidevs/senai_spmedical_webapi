using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        //a string de conexao vai aqui
        private string stringConexao = "Data Source=LAB08DESK115999\\SQLEXPRESS; initial catalog=medicalGroup; integrated security=true";

        public void Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT idUsuario, idTipoUsuario, nomeUsuario, email, senha FROM usuarios WHERE email = @email AND senha = @senha;";

                // Define o comando cmd passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso dados tenham sido obtidos
                    if (rdr.Read())
                    {
                        // Cria um objeto do tipo UsuarioDomain
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas do banco de dados
                            idUsuario   = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email       = rdr["email"].ToString(),
                            senha       = rdr["senha"].ToString(),
                            nomeUsuario = rdr["nomeUsuario"].ToString()
                 
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listarUsuarios =  new List<UsuarioDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idUsuario, idTipoUsuario, nomeUsuario, email, senha FROM usuarios ";

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
                        UsuarioDomain usuarios = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),

                            // atribui a propiedade idClinica com o valor da primeira coluna da tabela do banco de dados
                            idTipoUsuario = Convert.ToInt32(rdr[1]),

                            nomeUsuario = rdr[2].ToString(),

                            //atribui à propiedade nome o valor da segunda coluna da tabela do banco de dados
                            email = rdr[3].ToString(),

                            senha = rdr[4].ToString()
                        };

                        // adiciona o objeto Clinica a lista listaClinica
                        listarUsuarios.Add(usuarios);
                    }
                }
            }

            return listarUsuarios;
        }
    }
    
}
    

