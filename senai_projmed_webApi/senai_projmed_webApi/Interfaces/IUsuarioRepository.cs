using senai_projmed_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_projmed_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> ListarTodos();
        UsuarioDomain BuscarPorId(int id);
        void Cadastrar(UsuarioDomain novaConsulta);
        void AtualizarIdCorpo(UsuarioDomain consulta);
        void Deletar(int id);
    }
}
