using senai_projmed_webApi.Domains;
using senai_projmed_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        //a string de conexao vai aqui


        
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão con passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define o comando a ser executado no banco de dados
                string querySelect = "SELECT idUsuario, email, senha, permissao FROM Usuarios WHERE email = @email AND senha = @senha;";

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
                            email       = rdr["email"].ToString(),
                            senha       = rdr["senha"].ToString(),
                            permissao   = rdr["nomeUsuario"].ToString()
                        };

                        // Retorna o usuário buscado
                        return usuarioBuscado;
                    }

                    // Caso não encontre um email e senha correspondente, retorna null
                    return null;
                }
            }
        }
    }
}
    
}
