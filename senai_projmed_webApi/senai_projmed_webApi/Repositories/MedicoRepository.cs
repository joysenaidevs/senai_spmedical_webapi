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
    /// classe responsavel pelo repósitório dos medicos
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {

        //string de conexao
         string stringConexao = "Data Source=LAB08DESK115999\\SQLEXPRESS; initial catalog=medicalGroup; integrated security=true";


        public void AtualizarIdCorpo(MedicosDomain consulta)
        {
            throw new NotImplementedException();
        }

        public MedicosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(MedicosDomain novaConsulta)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicosDomain> ListarTodos()
        {
            // cria uma lista onde serão armazenados os dados, listaClinicas
            List<MedicosDomain> listarMedicos = new List<MedicosDomain>();

            // Criando uma nova conexao e um objeto que vai me permitir essa conexão (con)
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idEspecialidade, idClinica, idUsuario, nomeMedico, email FROM medicos ";

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
                        MedicosDomain medicos = new MedicosDomain()
                        {
                            // atribui a propiedade idClinica com o valor da primeira coluna da tabela do banco de dados
                            idClinica = Convert.ToInt32(rdr[0]),

                            //atribui à propiedade nome o valor da segunda coluna da tabela do banco de dados
                            idEspecialidade = Convert.ToInt32(rdr[1]),

                            idUsuario = Convert.ToInt32(rdr[2]),

                            nomeMedico = rdr[3].ToString(),

                            email = rdr[4].ToString()
                        };

                        // adiciona o objeto Clinica a lista listaClinica
                        listarMedicos.Add(medicos);
                    }
                }
            }

            return listarMedicos;
        }
    }
}
